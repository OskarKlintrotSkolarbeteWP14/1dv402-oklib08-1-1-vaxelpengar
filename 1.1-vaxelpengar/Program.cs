using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1_vaxelpengar
{
    class Program
    {
        private class ToLittleException : Exception
        {
        }
        static void Main(string[] args)
        {
            //Consol window
            ConsoleKeyInfo escp;
            Console.Title = Strings.Console_Title;
            
            uint[] denominations = new uint[7] { 500, 100, 50, 20, 10, 5, 1 };

            do
            {
                Console.Clear();

                //Sum to get paid for
                double subtotal = ReadPositiveDouble(Strings.Sum_Prompt.PadRight(20) + ": ");

                //Cash from customer
                uint cash = ReadUint(Strings.Cash_Prompt.PadRight(20) + ": ", Convert.ToUInt32(subtotal));

                //Rounding off the price
                uint total = (uint)Math.Round(subtotal + 0.001);
                double roundingOffAmount = total - subtotal;

                //View receipt
                uint change = cash - total;
                uint[] notes = SplitIntoDenominations(change, denominations);
                ViewReceipt(subtotal, roundingOffAmount, total, cash, change, notes, denominations);

                //Again?
                ViewMessage(Strings.Continue_Prompt);
                escp = Console.ReadKey();
            } while (escp.Key != ConsoleKey.Escape);
        }
        private static double ReadPositiveDouble(string prompt)
        {
            double amountToBePaid;
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    amountToBePaid = double.Parse(Console.ReadLine());
                    if (amountToBePaid < 0.5 || amountToBePaid > UInt32.MaxValue)
                        throw new OverflowException();
                    break;
                }
                catch
                {
                    Console.Clear();
                    ViewMessage(Strings.Error_Message, true);
                }
            }
            return amountToBePaid;
        }
        private static uint ReadUint(string prompt, uint minValue)
        {
            uint cash;
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    cash = uint.Parse(Console.ReadLine());
                    if (cash < minValue)
                    {
                        throw new ToLittleException();
                    }
                    break;
                }
                catch(ToLittleException)
                {
                    ViewMessage(Strings.ToLittleCash_Prompt, true);
                }
                catch
                {
                    ViewMessage(Strings.Error_Message, true);
                }
            }
            return cash;
        }
        private static uint[] SplitIntoDenominations(uint change, uint[] denominations)
        {
            uint[] leftOver = new uint[7];
            uint[] SplitIntoDenominations = new uint[7];
            Console.WriteLine();
            for (int i = 0; i < denominations.Length; i++)
            {
                leftOver[i] = change % denominations[i];
                SplitIntoDenominations[i] = change / denominations[i];
                change = leftOver[i];
            }
            return SplitIntoDenominations;
        }
        private static void ViewMessage(string message, bool isError = false)
        {
            if (isError)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine(message);
            Console.ResetColor();
        }
        private static void ViewReceipt(double subtotal, double roundningOffAmount, uint total, uint cash, uint change, uint[] notes, uint[] denominations)
        {
            //Receipt
            Console.WriteLine("KVITTO");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Totalt".PadRight(15) + ":" + "{0, 15:C}", subtotal);
            Console.WriteLine("Öresutjämning".PadRight(15) + ":" + "{0, 15:C}", roundningOffAmount);
            Console.WriteLine("Att betala".PadRight(15) + ":" + "{0, 15:C}", total);
            Console.WriteLine("Kontant".PadRight(15) + ":" + "{0, 15:C}", cash);
            Console.WriteLine("Tillbaka".PadRight(15) + ":" + "{0, 15:C}", change);
            Console.WriteLine("-------------------------------");
            Console.WriteLine();

            //Change back to customer
            int count = 0;
            foreach (int element in notes)
            {
                if (element > 0 && denominations[count] >= 20)
                {
                    Console.WriteLine(Strings.Paper_Prompt, denominations[count], element);
                }
                if (element > 0 && denominations[count] < 20)
                {
                    Console.WriteLine(Strings.Coins_Prompt, denominations[count], element);
                }
                count++;
            }
        }

    }
}
