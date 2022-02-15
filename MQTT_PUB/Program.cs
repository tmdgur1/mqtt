using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MQTT_PUB
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] topics = new string[] { "Client" };
            byte[] qos_type = new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE };
            string broker_host = "localhost";
            string client_id = "Client";
            MqttProtocolVersion version = MqttProtocolVersion.Version_3_1;







            try
            {
                MqttClient client = new MqttClient(broker_host);
                client.ProtocolVersion = version;

                client.MqttMsgPublished += Client_MqttMsgPublished;
                client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
                client.MqttMsgSubscribed += Client_MqttMsgSubscribed;
                client.MqttMsgUnsubscribed += Client_MqttMsgUnsubscribed;
                client.ConnectionClosed += Client_ConnectionClosed;

                client.Connect(client_id);

                while (true) 
                {
                    Console.Write("insert string: ");
                    string str = Console.ReadLine();
                    client.Publish("Client", Encoding.UTF8.GetBytes(str), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, true);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void Client_ConnectionClosed(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private static void Client_MqttMsgUnsubscribed(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgUnsubscribedEventArgs e)
        {
            // throw new NotImplementedException();
        }

        private static void Client_MqttMsgSubscribed(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgSubscribedEventArgs e)
        {
            // throw new NotImplementedException();
        }

        private static void Client_MqttMsgPublishReceived(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
        {
            // throw new NotImplementedException();
            Console.WriteLine(e.Topic);
            Console.WriteLine(Encoding.UTF8.GetString(e.Message));
        }

        private static void Client_MqttMsgPublished(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishedEventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
