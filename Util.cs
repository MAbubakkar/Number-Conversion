using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberConversion
{
    class Util
    {
        public long dec2bin(int number)
        {
            string result = "";
            while (number > 0)
            {
                int remainder = number % 2;
                result = remainder.ToString() + result;
                number /= 2;
            }
            return Convert.ToInt64(result);
        }
        public long dec2oct(int number)
        {
            string result = "";
            while (number > 0)
            {
                int remainder = number % 8;
                result = remainder.ToString() + result;
                number /= 8;
            }
            return Convert.ToInt64(result);
        }
        public string dec2hex(int number)
        {            
            int dn = 0, m, l;
            int tmp;
            int s;
            string result="";

            for (l = number; l > 0; l = l / 16)
            {
                tmp = l % 16;
                if (tmp < 10)
                    tmp = tmp + 48;
                else
                    tmp = tmp + 55;
                    dn = dn * 100 + tmp;
            }
            
            for (m = dn; m > 0; m = m / 100)
            {
                s = m % 100;                
                char val = (char)s;
                result = result + val.ToString();
            }
            return result;
        }

        public long bin2dec(int number)
        {
            int decimalValue = 0;
            // initializing base1 value to 1, i.e 2^0 
            int base1 = 1;

            while (number > 0)
            {
                int remainder = number % 10;
                number = number / 10;
                decimalValue += remainder * base1;
                base1 = base1 * 2;
            }
            return decimalValue;
        }
        public long bin2oct(int number)
        {
            string binary = number.ToString();
            int pad = binary.Length % 3;
            binary = new string('0', 3 - pad) + binary;
            int n = binary.Length / 3;
            char[] bin_digits = binary.ToCharArray();
            char[] oct_digits = new char[n];
            for (int i = 0; i < n; i++)
            {
                int digit = bin_digits.Skip(3 * i).Take(3).Aggregate(0,
                    (x, v) => (int)v - (int)'0' + 2 * x);
                // x is the value accumulation
                // v is a char '0' or '1' representing a bit and is converted to int 0, 1
                oct_digits[i] = (char)(digit + (int)'0');
                // convert int to char digit
            }
            string oct_value = new string(oct_digits);
            return Convert.ToInt64(oct_value);
        }
        public string bin2hex(int number)
        {
            int[] hexaDecimal = new int[1000];
            int a = 1, b = 0, r, Decimal = 0;
            string result = "";
            
            while (number > 0)
            {
                r = number % 2;
                Decimal = Decimal + r * a;
                a = a * 2;
                number = number / 10;
            }
            a = 0;
            while (Decimal != 0)
            {
                hexaDecimal[a] = Decimal % 16;
                Decimal = Decimal / 16;
                a++;
            }
            
            for (b = a - 1; b >= 0; b--)
            {
                if (hexaDecimal[b] > 9)
                {                    
                    char val = (char)(hexaDecimal[b] + 55);
                    result = result + val.ToString();
                }
                else
                {
                    result = result + hexaDecimal[b].ToString();
                }
            }
            return result;
        }

        public long oct2bin(int number)
        {
            int p = 1;
            int dec = 0, i = 1, j, d;
            int binno = 0;

            for (j = number; j > 0; j = j / 10)
            {
                d = j % 10;
                if (i == 1)
                    p = p * 1;
                else
                    p = p * 8;

                dec = dec + (d * p);
                i++;
            }

            /*------------------------------------------------------------------------------*/
            i = 1;

            for (j = dec; j > 0; j = j / 2)
            {
                binno = binno + (dec % 2) * i;
                i = i * 10;
                dec = dec / 2;
            }

            return binno;
        }
        public long oct2dec(int number)
        {
            int 
                temp, p = 1, k, ch = 1;
            int dec = 0, i = 1, j, d;

            temp = number;

            for (; number > 0; number = number / 10)
            {
                k = number % 10;
                if (k >= 8)
                {
                    ch = 0;
                }
            }

            switch (ch)
            {
                case 0:
                    return 0;
                    break;
                case 1:
                    number = temp;
                    for (j = number; j > 0; j = j / 10)
                    {
                        d = j % 10;
                        if (i == 1)
                            p = p * 1;
                        else
                            p = p * 8;

                        dec = dec + (d * p);
                        i++;
                    }
                    break;
            }
            return dec;
        }
        public string oct2hex(int number)
        {
            int dec_value = Convert.ToInt32(oct2dec(number));
            string result = dec2hex(dec_value);
            return result;
        }

        public long hex2bin(string number)
        {
            int decimalNumber, a = 1, b;
            int[] binaryNumber = new int[100];
            string result = "";
            decimalNumber = Convert.ToInt32(hex2dec(number));
            // converting decimal number to binary number
            while (decimalNumber != 0)
            {
                binaryNumber[a++] = decimalNumber % 2;
                decimalNumber = decimalNumber / 2;
            }
            
            for (b = a - 1; b > 0; b--)
            {
                result = result + binaryNumber[b].ToString();
            }
            return Convert.ToInt64(result);
        }
        public long hex2oct(string number)
        {
            int binary = Convert.ToInt32(hex2bin(number));
            long result = bin2oct(binary);
            return result;
        }
        public long hex2dec(string number)
        {
            String strDigits = "0123456789ABCDEF";
            number = number.ToUpper();
            int val = 0;
            for (int a = 0; a < number.Length; a++)
            {
                char c = number[a];
                int d = strDigits.IndexOf(c);
                val = 16 * val + d;
            }
            return val;
        }


    }
}
