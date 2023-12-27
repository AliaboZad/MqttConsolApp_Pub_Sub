using MQTTnet.Client;
using MQTTnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace MqttConsolApp_Pub
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            string broker = "192.168.1.40";
            int port = 1883;
            string clientId = Guid.NewGuid().ToString();
            string topic = "Soil";

            // Create a MQTT client factory
            var factory = new MqttFactory();

            // Create a MQTT client instance
            var mqttClient = factory.CreateMqttClient();

            // Create MQTT client options
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(broker, port) // MQTT broker address and port
                /*.WithCredentials(username, password)*/ // Set username and password
                .WithClientId(clientId)
                .WithCleanSession()
                //.WithTls(o =>
                //{
                //    // The used public broker sometimes has invalid certificates. This sample accepts all
                //    // certificates. This should not be used in live environments.
                //    o.CertificateValidationHandler = _ => true;

                //    // The default value is determined by the OS. Set manually to force version.
                //    o.SslProtocol = SslProtocols.Tls12;

                //    // Please provide the file path of your certificate file. The current directory is /bin.
                //    var certificate = new X509Certificate("/opt/emqxsl-ca.crt", "");
                //    o.Certificates = new List<X509Certificate> { certificate };
                //})

                .Build();

            // Connect to MQTT broker
            var connectResult = await mqttClient.ConnectAsync(options);

            while (true)
            {
                var message = new MqttApplicationMessageBuilder()
                  .WithTopic(topic)
                  //$"Hello, MQTT! Message number {i}"
                  .WithPayload(Console.ReadLine())
                  .WithQualityOfServiceLevel(0)
                  .WithRetainFlag()
                  .Build();

                await mqttClient.PublishAsync(message);
                //await Task.Delay(1000); 

                //InsertDataIntoSqlServer($"message{message}");
            }







        }
    }
}
