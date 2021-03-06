﻿using Ruckus.Spot.PushApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ruckus.Spot.Monitor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var manager = new PushApiManager(args[0], args[1], args[2]);
            manager.Connect();
            manager.OnLocationReceived += Manager_OnLocationReceived;
            manager.ConnectionClosed += Manager_ConnectionClosed;
            manager.Subscribed += Manager_Subscribed;
            while (true)
            {
                Thread.Sleep(1000);
            }
        }

        private static void Manager_Subscribed(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgSubscribedEventArgs e)
        {
            Console.WriteLine($"{DateTime.UtcNow.ToString("s")} Subscribed");
        }

        private static void Manager_ConnectionClosed(object sender, EventArgs e)
        {
            Console.WriteLine($"{DateTime.UtcNow.ToString("s")} Connection closed");
        }

        private static void Manager_OnLocationReceived(LocationMessage msg)
        {
            Console.WriteLine($"{DateTime.UtcNow.ToString("s")};{msg.floor_number};{msg.mac};{msg.x};{msg.y}");
        }
    }
}
