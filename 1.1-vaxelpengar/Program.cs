using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1_vaxelpengar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Växelpengar - nivå C";
            Console.Clear();
            string prompt = "test";
            double temp = Program.ReadPositiveDouble(prompt);
            Console.WriteLine(temp);
        }

        private static double ReadPositiveDouble(string prompt)
        {
            double amountToBePaid;
            while (true)
            {
                try
                {
                    Console.Write(Strings.Sum_Prompt.PadRight(20) + ": ");
                    amountToBePaid = double.Parse(Console.ReadLine());
                    if (amountToBePaid < 0.5)
                        throw new OverflowException();
                    break;
                }
                catch
                {
                    Console.WriteLine("FEL");
                }
            }
            return amountToBePaid;
        }
        //private static uint ReadUint(string prompt, uint minValue)
        //{
        //    console.write(strings.cash_prompt.padright(20) + ": ");
        //    return 
        //}
        //private static uint SplitIntoDenominations(uint change, uint[] denominations)
        //{

        //}
        //private static void ViewMessage(string message, bool isError = false) 
        //{
            
        //}
        //private static void ViewReceipt(double subtotal, double roundningOffAmount, uint total, uint cash, uint change, uint[] notes, uint[] denominations) 
        //{

        //}

    }
}
