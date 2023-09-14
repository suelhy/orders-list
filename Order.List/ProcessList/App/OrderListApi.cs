using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProcessList.Models;

namespace ProcessList
{
    public class OrderListApi
    {
        [FunctionName("ReadOrderList")]
        public async Task Read([ServiceBusTrigger("myqueue", Connection = "ConnectionString")] ServiceBusReceivedMessage msg, ILogger log)
        {
            string functionName = GetType().Namespace.Split('.')[0];
            string msgBody = msg.Body.ToString();
            string timeStamp = DateTime.UtcNow.ToString();

            try
            {
                log.LogInformation($"functionName: {functionName} started at {timeStamp}");

                var listItems = JsonConvert.DeserializeObject<IEnumerable<OrderList>>(msgBody);

                await SendOrder(listItems);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }            
        }

        private async Task SendOrder(IEnumerable<OrderList> listItems)
        {
            //It hasn't implemented yet
        }
    }
}
