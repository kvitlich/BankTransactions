using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    public class Account
    {
        public string Name { get; private set; }
        public int Summ { get; private set; } = 1000;
       
        public Account(string name)
        {
            Name = name;
        }

        public void ProcessSumm(int summ)
        {
            Summ += summ;
            Console.WriteLine($"{this.Name}: {Summ}");
        }

        public void Send(object arg)
        {
            var args = arg as object[];
            Account dest = (Account)args[0];
            int summ = (int)args[1];
            if (summ <= 0)
                return;
            this.ProcessSumm(-summ);
            dest.ProcessSumm(summ);
        }
    }
}
