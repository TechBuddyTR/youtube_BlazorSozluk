using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorSozluk.Common.Infrastructure;
public static class QueueFactory
{
    public static void SendMessageToExchange(string exchangeName,
                                             string exchangeType,
                                             string queueName,
                                             object obj)
    {
        var channel = CreateBasicConsumer()
                        .EnsureExchange(exchangeName, exchangeType)
                        .EnsureQueue(queueName, exchangeName)
                        .Model;

        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(obj));

        channel.BasicPublish(exchange: exchangeName,
                             routingKey: queueName,
                             basicProperties: null,
                             body: body);

    }

    public static EventingBasicConsumer CreateBasicConsumer()
    {
        var factory = new ConnectionFactory() { HostName = SozlukConstants.RabbitMQHost };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        return new EventingBasicConsumer(channel);
    }

    public static EventingBasicConsumer EnsureExchange(this EventingBasicConsumer consumer,
                                                       string exchangeName,
                                                       string exchangeType = SozlukConstants.DefaultExchangeType)
    {
        consumer.Model.ExchangeDeclare(exchange: exchangeName,
                                       type: exchangeType,
                                       durable: false,
                                       autoDelete: false);
        return consumer;
    }

    public static EventingBasicConsumer EnsureQueue(this EventingBasicConsumer consumer,
                                                       string queueName,
                                                       string exchangeName)
    {
        consumer.Model.QueueDeclare(queue: queueName,
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    null);

        consumer.Model.QueueBind(queueName, exchangeName, queueName);

        return consumer;
    }

    public static EventingBasicConsumer Receive<T>(this EventingBasicConsumer consumer, Action<T> act)
    {
        consumer.Received += (m, eventArgs) => 
        {
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            var model = JsonSerializer.Deserialize<T>(message);

            act(model);
            consumer.Model.BasicAck(eventArgs.DeliveryTag, false);
        };

        return consumer;
    }

    public static EventingBasicConsumer StartConsuming(this EventingBasicConsumer consumer, string queueName)
    {
        consumer.Model.BasicConsume(queue: queueName,
                                    autoAck: false,
                                    consumer: consumer);

        return consumer;
    }
}
