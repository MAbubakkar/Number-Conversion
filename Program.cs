using System;

namespace NumberConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Util utilObj = new Util();
                // check  to see  i f  we w i l l go  for  another round
                Console.Write("Enter Q to exit, N to continue:[N]");
                string exit = Console.ReadLine();
                if (exit == "Q" || exit == "q")
                    Environment.Exit(0);

                // get  the  base  to convert  from
                Console.Write("Please enter the base to convert from [2 | 8 | 10 | 16] :");

                string n2 = Console.ReadLine();
                int from = int.Parse(n2);

                //  get  the ”number” to  convert
                Console.Write("Please enter the integer to convert :");
                string n1 = Console.ReadLine();
                bool success = Int32.TryParse(n1, out int number);
                if (success)
                    Console.WriteLine($"Number:{ number},base :{ from}\n");
                else
                    Console.WriteLine($"Number:{ n1},base :{ from}\n");
                long result = 0;
                string str_result = "";

                if (from == 10)
                {
                    result = utilObj.dec2bin(number);
                    Console.WriteLine($" binary conversion is{ result}");
                    result = utilObj.dec2oct(number);
                    Console.WriteLine($" octal conversion is{ result}");
                    str_result = utilObj.dec2hex(number);
                    Console.WriteLine($"hex conversion is{ str_result}");
                }

                else if (from == 2)
                {
                    result = utilObj.bin2dec(number);
                    Console.WriteLine($" decimal conversion is{ result}");
                    result = utilObj.bin2oct(number);
                    Console.WriteLine($" octal conversion is{ result}");
                    str_result = utilObj.bin2hex(number);
                    Console.WriteLine($"hex conversion is{ str_result}");
                }

                else if (from == 8)
                {
                    result = utilObj.oct2bin(number);
                    Console.WriteLine($" binary conversion is{ result}");
                    result = utilObj.oct2dec(number);
                    Console.WriteLine($" decimal conversion is{ result}");
                    str_result = utilObj.oct2hex(number);
                    Console.WriteLine($"hex conversion is{ str_result}");
                }

                else if (from == 16)
                {
                    result = utilObj.hex2bin(n1);
                    Console.WriteLine($" binary conversion is{ result}");
                    result = utilObj.hex2oct(n1);
                    Console.WriteLine($" octal conversion is{ result}");
                    result = utilObj.hex2dec(n1);
                    Console.WriteLine($"decimal conversion is{ result}");
                }

                else
                {
                    Console.WriteLine("Error in base to convert from");
                }

            }
        }
    }
}
