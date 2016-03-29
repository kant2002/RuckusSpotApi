using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Ruckus.Spot.PushApi
{
    /// <summary>
    /// API client for SPoT Push API
    /// </summary>
    public class PushApiManager
    {
        private readonly string[] Topics = new string[] { "1.0.0/LOC/SPOT_GPB/#" };
        private string server;
        private string login;
        private string password;

        private MqttClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="PushApiManager"/> class.
        /// </summary>
        /// <param name="server">Host name or address of the Ruskus Push API server</param>
        /// <param name="login">Login on the server.</param>
        /// <param name="password">Password to the server.</param>
        public PushApiManager(string server, string login, string password)
        {
            this.server = server;
            this.login = login;
            this.password = password;
            this.client = new MqttClient(server);
        }

        /// <summary>
        /// Called when new coordinates calculated by Ruckus Push API
        /// </summary>
        public event Action<LocationMessage> OnLocationReceived;

        /// <summary>
        /// Called when connection to Ruckus Push API terminated.
        /// </summary>
        public event EventHandler ConnectionClosed;

        /// <summary>
        /// Called when connection to Ruckus Push API finished.
        /// </summary>
        public event EventHandler<MqttMsgSubscribedEventArgs> Subscribed;

        /// <summary>
        /// Gets or sets a value indicating whether connection to Ruckus Push API established.
        /// </summary>
        public bool IsConnected
        {
            get { return this.client.IsConnected; }
        }
 
        /// <summary>
        /// Connect to the Ruckus Push API server.
        /// </summary>
        public void Connect()
        {
            string clientId = Guid.NewGuid().ToString();
            this.client.ConnectionClosed += Client_ConnectionClosed;
            this.client.MqttMsgSubscribed += Client_MqttMsgSubscribed;
            this.client.MqttMsgPublishReceived += OnMqttMsgPublishReceived;

            var errorCode = this.client.Connect(clientId, this.login, this.password);
            if (errorCode != 0)
            {
                throw new InvalidOperationException("Could not connect");
            }

            this.client.Subscribe(Topics, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        }

        /// <summary>
        /// Disconnects from the Ruckus Push API server.
        /// </summary>
        public void Disconnect()
        {
            if (!this.client.IsConnected)
            {
                throw new InvalidOperationException();
            }

            this.client.Unsubscribe(Topics);
        }

        private void Client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {
            this.Subscribed?.Invoke(sender, e);
        }

        private void Client_ConnectionClosed(object sender, EventArgs e)
        {
            this.ConnectionClosed?.Invoke(sender, e);
        }

        private void OnMqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            // Handle message received
            var data = Serializer.Deserialize<LocationMessages>(new MemoryStream(e.Message));
            var messages = data.Messages;
            UpdateMessages(messages);
        }

        private void UpdateMessages(IEnumerable<LocationMessage> messages)
        {
            var handler = this.OnLocationReceived;
            if (handler == null)
            {
                return;
            }

            foreach (var msg in messages)
            {
                handler(msg);
            }
        }
    }
}
