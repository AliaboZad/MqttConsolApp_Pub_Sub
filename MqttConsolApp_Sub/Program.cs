﻿using MQTTnet.Client;
using MQTTnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTTnet.Protocol;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Data.SqlClient;

namespace MqttConsolApp_Sub
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

            if (connectResult.ResultCode == MqttClientConnectResultCode.Success)
            {
                Console.WriteLine("Connected to MQTT broker successfully.");

                

                // Subscribe to a topic
                await mqttClient.SubscribeAsync(topic);
               
                // Callback function when a message is received
                mqttClient.ApplicationMessageReceivedAsync += e =>
                {
                     Console.WriteLine($"Publish Message => {Encoding.UTF8.GetString(e.ApplicationMessage.PayloadSegment)}");
                    return Task.CompletedTask;
                };



                while (true)
                {
                    var message = new MqttApplicationMessageBuilder()
                      .WithTopic(topic)
                      //$"Hello, MQTT! Message number {i}"
                      .WithPayload(Console.ReadLine())
                      .WithQualityOfServiceLevel(0)
                      .WithRetainFlag()
                      .Build();

                    //await mqttClient.PublishAsync(message);
                    //await Task.Delay(1000); 

                    //InsertDataIntoSqlServer($"message{message}");
                }



            }
            else
            {
                Console.WriteLine($"Failed to connect to MQTT broker: {connectResult.ResultCode}");
            }

            //static void InsertDataIntoSqlServer(string data)
            //{
            //    string connectionString = "Server = .; Database = MQTTDatabase_Pub_Sub; User Id = sa; Password = 1111;";

            //    // Establish connection to SQL Server
            //    using (var connection = new SqlConnection(connectionString))
            //    {
            //        connection.Open();

            //        // Define SQL command to insert data
            //        using (var command = new SqlCommand("StringValues (@Data)", connection))
            //        {
            //            command.Parameters.AddWithValue("@Data", data);
            //            command.ExecuteNonQuery();
            //        }
            //    }

            //    Console.WriteLine("Data inserted into SQL Server!");


            //}
        }
    }
}
