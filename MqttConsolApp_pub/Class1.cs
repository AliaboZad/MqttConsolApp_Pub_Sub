using MQTTnet;
using MQTTnet.Client;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MqttConsolApp_pub
{
    public class Class1
    {
        //static async Task Main(string[] args)
        //{
        //    var factory = new MqttFactory();
        //    var mqttClient = factory.CreateMqttClient();

        //    var options = new MqttClientOptionsBuilder()
        //        .WithTcpServer("mqtt.eclipse.org")
        //        .Build();
        //    //UseConnectedHandler
        //    mqttClient.UseConnectedHandler(e =>
        //    {
        //        Console.WriteLine("Connected to MQTT broker!");
        //        mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic("your/topic").Build());
        //    });

        //    mqttClient.UseApplicationMessageReceivedHandler(e =>
        //    {
        //        // Handle incoming MQTT message
        //        string payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
        //        Console.WriteLine($"Received message: {payload}");

        //        // Extract data and insert into SQL Server
        //        InsertDataIntoSqlServer(payload);
        //    });

        //    await mqttClient.ConnectAsync(options, CancellationToken.None);

        //    // Keep the application running
        //    Console.ReadLine();
        //}

        //static void InsertDataIntoSqlServer(string data)
        //{
        //    // Establish connection to SQL Server (replace with your connection string)
        //    using (var connection = new System.Data.SqlClient.SqlConnection("YourConnectionString"))
        //    {
        //        connection.Open();

        //        // Define SQL command to insert data (replace with your table and columns)
        //        using (var command = new System.Data.SqlClient.SqlCommand("INSERT INTO YourTable (ColumnName) VALUES (@Data)", connection))
        //        {
        //            command.Parameters.AddWithValue("@Data", data);
        //            command.ExecuteNonQuery();
        //        }
        //    }

        //    Console.WriteLine("Data inserted into SQL Server!");
        //}
    } 
}
