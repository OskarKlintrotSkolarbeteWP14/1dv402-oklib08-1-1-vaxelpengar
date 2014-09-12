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
            ConsoleKeyInfo escp;
            Console.Title = "Växelpengar - nivå C";
            do
            {
                Console.Clear();
                double sum = ReadPositiveDouble(Strings.Sum_Prompt.PadRight(20) + ": ");
                Console.WriteLine(sum);
                //uint temp2 = Convert.ToUInt32(sum);
                //ReadUint(Strings.Cash_Prompt.PadRight(20) + ": ", Convert.ToUInt32(sum));
                uint temp2 = ReadUint(Strings.Cash_Prompt.PadRight(20) + ": ", Convert.ToUInt32(sum));
                Console.WriteLine(temp2);
                Console.WriteLine(Strings.Continue_Prompt);
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
                    if (amountToBePaid < 0.5)
                        throw new OverflowException();
                    break;
                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Felaktig inmatning, försök igen!");
                    Console.ResetColor();
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("För lite kontanter!");
                    Console.ResetColor();
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Felaktig inmatning, försök igen!");
                    Console.ResetColor();
                }
            }
            return cash;
        }
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
