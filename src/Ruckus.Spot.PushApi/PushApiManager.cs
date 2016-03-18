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
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class PushApiManager
    {
        private string server;
        private string login;
        private string password;

        private MqttClient client;

        private DateTime lastUpdateTime = DateTime.UtcNow;

        public PushApiManager(string server, string login, string password)
        {
            this.server = server;
            this.login = login;
            this.password = password;
            this.client = new MqttClient(server);
        }

        public void Connect()
        {
            string clientId = Guid.NewGuid().ToString();

            this.client.Connect(clientId, this.login, this.password);
            this.client.Subscribe(new string[] { "1.0.0/LOC/SPOT_GPB/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
        }
        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            // handle message received 
            var data = Serializer.Deserialize<LocationMessages>(new MemoryStream(e.Message));
            var messages = data.Messages;
            var filteredMessages = messages;
            if (filteredMessages.Count() > 0)
            {
                UpdateMessages(filteredMessages);
            }
        }

        private void UpdateMessages(IEnumerable<LocationMessage> messages)
        {
            if ((this.lastUpdateTime - DateTime.UtcNow).TotalMilliseconds < -300)
            {
                this.lastUpdateTime = DateTime.UtcNow;

            }

            foreach (var msg in messages)
            {
                Console.WriteLine($"{DateTime.UtcNow.ToString("s")};{msg.floor_number};{msg.mac};{msg.x};{msg.y}");
            }
        }
    }
}
