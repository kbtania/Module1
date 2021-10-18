using System;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        public interface ITaxiOrder
        {
            public void OrderTaxi();
        }

        public class LimeJetTaxi
        {
            public List<object> fromAddress;
            public List<object> toAddress;

            public LimeJetTaxi(List<object> fromAddress, List<object> toAddress)
            {
                this.fromAddress = fromAddress;
                this.toAddress = toAddress;
            }

            public void OrderLimeJetTaxi() 
            {
                Console.WriteLine($"You ordered LimeJet Taxi from {fromAddress[1]} to {toAddress[1]}");
            }
        }

        public class SovaTaxi
        {
            public string fromAddress;
            public string toAddress;
            public DateTime orderTime;
            public SovaTaxi(string fromAddress, string toAddress, DateTime orderTime)
            {
                this.fromAddress = fromAddress;
                this.toAddress = toAddress;
                this.orderTime = orderTime;
            }

            public void OrderSovaTaxi()
            {
                Console.WriteLine($"You ordered Sova Taxi from {fromAddress} to {toAddress} at {orderTime}");
            }
        }

        public class Taxi : ITaxiOrder
        {
            public int taxiType;
            public string fromAddress;
            public string toAddress;
            public Taxi(int taxiType, string fromAddress, string toAddress)
            {
                this.taxiType = taxiType;
                this.fromAddress = fromAddress;
                this.toAddress = toAddress;
            }
            public void OrderTaxi()
            {
                if (taxiType == 1)
                {
                    List<object> from = new List<object> { true, fromAddress };
                    List<object> to = new List<object> { false, toAddress };
                    LimeJetTaxi taxi = new LimeJetTaxi(from, to);
                    taxi.OrderLimeJetTaxi();
                }
                else if (taxiType == 2)
                {
                    DateTime orderTime = DateTime.Now;
                    SovaTaxi taxi = new SovaTaxi(fromAddress, toAddress, orderTime);
                    taxi.OrderSovaTaxi();
                }
                else
                {
                    Console.WriteLine("Only 2 types of taxi are available. Try again!");
                }
            }
        }
        static void Main(string[] args)
        {
            // Testing Example
            Taxi taxiExample = new Taxi(2, "221B Baker Street, London", "Platform 9 and 3/4, King's Cross Station, London");
            taxiExample.OrderTaxi();


            Console.WriteLine("");
            Console.WriteLine("Which taxi would you like to order?\n 1 - LimeJet Taxi " +
                                                                    "\n 2 - Sova Taxi");
            int taxiType = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Where do you need to take a taxi from?");
            string from = Console.ReadLine();
            Console.WriteLine("What is your destination?");
            string to = Console.ReadLine();
            Taxi taxi = new Taxi(taxiType, from, to);
            taxi.OrderTaxi();
        }
    }
}
