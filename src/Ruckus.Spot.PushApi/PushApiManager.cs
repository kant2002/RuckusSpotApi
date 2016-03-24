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
        private string server;
        private string login;
        private string password;

        private MqttClient client;

        public PushApiManager(string server, string login, string password)
        {
            this.server = server;
            this.login = login;
            this.password = password;
            this.client = new MqttClient(server);
        }

        public event Action<LocationMessage> OnLocationReceived;

        public event EventHandler ConnectionClosed;

        public event EventHandler<MqttMsgSubscribedEventArgs> Subscribed;
 
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

            this.client.Subscribe(new string[] { "1.0.0/LOC/SPOT_GPB/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        }

        private void Client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {
            var handler = this.Subscribed;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        private void Client_ConnectionClosed(object sender, EventArgs e)
        {
            var handler = this.ConnectionClosed;
            if (handler != null)
            {
                handler(sender, e);
            }
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
            foreach (var msg in messages)
            {
                handler(msg);
            }
        }
    }
}
