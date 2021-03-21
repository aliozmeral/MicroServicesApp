using System;
using DotNetCore.CAP;

namespace consumerAPI.Business
{
   public class ConsumerService : ICapSubscribe
   {
      [CapSubscribe("producer.transaction", Group = "group2")]
      public void Consumer(DateTime date)
      {
         Console.WriteLine("Servis : " + date);
      }
   }
}