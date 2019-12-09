using System;
using System.Collections.Generic;
using System.Threading;

namespace BankSystem
{
    class Program
    {
        private static object SyncObject = new object();
        public static List<Account> Accounts = new List<Account>();

        static void Main(string[] args)
        {
            Accounts.Add(new Account("Kvit"));
            Accounts.Add(new Account("Sarsen"));
            Accounts.Add(new Account("Bekbolat"));
            Accounts.Add(new Account("Sax"));
            Accounts.Add(new Account("Adolf"));

            int randomSumm = new Random().Next(100, 1000);

            for (int i = 0; i < 1000; i++) // Сто раз перекидывают по 1000 чего-то друг другу на баланс
            {
                for (int j = 0; j < Accounts.Count; j++)
                {
                    object[] arguments;
                    lock (SyncObject)
                    {
                        if (j == Accounts.Count - 1)
                            arguments = new object[] { Accounts[0], randomSumm };
                        else
                            arguments = new object[] { Accounts[j + 1], randomSumm };
                        ThreadPool.QueueUserWorkItem(Accounts[j].Send, arguments);  //Переводим следующему позьзователю 100
                    }
                }
            }
            //   Thread.Sleep(1000);
            Console.ReadKey();
            Console.WriteLine("******************");
            Console.WriteLine("Счета: ");
            for (int j = 0; j < Accounts.Count; j++)
            {
                Console.WriteLine($"{Accounts[j].Name}: {Accounts[j].Summ}");
            }

        }
    }
}
