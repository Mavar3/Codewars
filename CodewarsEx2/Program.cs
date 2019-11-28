using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodewarsEx2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Первое задание
            //https://www.codewars.com/kata/515decfd9dcfc23bb6000006/train/csharp
            bool is_valid_IP(string ipAddres)
            {
                /*The best solution
                 *
                    IPAddress ip;
                    bool validIp = IPAddress.TryParse(IpAddres, out ip);
                    return validIp && ip.ToString()==IpAddres;
                 *
                 */ 
                string[] Numbers = ipAddres.Split('.');
                if (Numbers.Length != 4)
                    return false;
                else
                    for (int i = 0; i < 4; i++)
                    {
                        if (Numbers[i].Length == 0)
                            return false;
                        for (int j = 0; j < Numbers[i].Length; j++)
                        {
                            if (char.IsWhiteSpace(Numbers[i][j]))
                                return false;
                        }
                        if (Int32.TryParse(Numbers[i], out int Num) & Numbers[i][0] != '-')
                            if (Numbers[i].Length > 1 & Int32.Parse(Numbers[i][0].ToString()) == 0 |
                                Convert.ToInt32(Numbers[i]) < 0 | Convert.ToInt32(Numbers[i]) > 255)
                                return false;
                            else
                                continue;
                        else
                            return false;
                    }
                return true;
            }
            Console.WriteLine("Must True");
            Console.WriteLine(is_valid_IP("0.0.0.0"));
            Console.WriteLine(is_valid_IP("12.255.56.1"));
            Console.WriteLine(is_valid_IP("137.255.156.100") + "\n\n");
            Console.WriteLine("Must False");
            Console.WriteLine(is_valid_IP(""));
            Console.WriteLine(is_valid_IP("abc.def.ghi.jkl"));
            Console.WriteLine(is_valid_IP("123.456.789.0"));
            Console.WriteLine(is_valid_IP("12.34.56"));
            Console.WriteLine(is_valid_IP("12.34.56.00"));
            Console.WriteLine(is_valid_IP("12.34.56.7.8"));
            Console.WriteLine(is_valid_IP("12.34.256.78"));
            Console.WriteLine(is_valid_IP("1234.34.56"));
            Console.WriteLine(is_valid_IP("pr12.34.56.78"));
            Console.WriteLine(is_valid_IP("12.34.56.78sf"));
            Console.WriteLine(is_valid_IP("12.34.56 .1"));
            Console.WriteLine(is_valid_IP("12.34.56.-1"));
            Console.WriteLine(is_valid_IP("123.045.067.089"));
            Console.ReadKey();
            Console.WriteLine("\n");

            //Второе задание
            //https://www.codewars.com/kata/5277c8a221e209d3f6000b56/train/csharp

            bool validBraces(String braces)
            {
                char[] counter = braces.ToCharArray();
                int d = 0;
                for (int i = 0; i < counter.Length; i++)
                {
                    switch (counter[i])
                    {
                        case ')':
                            int j = i - 1;
                            int count;
                            if (j >= 0)
                                count = 0;
                            else
                                count = 1000;
                            while (j >= 0 && counter[j] != '(')
                            {
                                if (counter[j] == '[' | counter[j] == '{')
                                    count++;
                                else
                                    if (counter[j] != 'z')
                                    count--;
                                j--;
                            }
                            if (count != 0)
                                return false;
                            counter[i] = 'z';
                            if (j >= 0)
                            {
                                counter[j] = 'z';
                            }
                            else
                            {
                                counter[j + 1] = 'z';
                            }
                            break;
                        case ']':
                            j = i - 1;
                            if (j >= 0)
                                count = 0;
                            else
                                count = 1000;
                            while (j >= 0 && counter[j] != '[')
                            {
                                if (counter[j] == '(' | counter[j] == '{')
                                    count++;
                                else
                                    if (counter[j] != 'z')
                                    count--;
                                j--;
                            }
                            if (count != 0)
                                return false;
                            counter[i] = 'z';
                            if (j >= 0)
                            {
                                counter[j] = 'z';
                            }
                            else
                            {
                                counter[j + 1] = 'z';
                            }
                            break;
                        case '}':
                            j = i - 1;
                            if (j >= 0)
                                count = 0;
                            else
                                count = 1000;
                            while (j >= 0 && counter[j] != '{')
                            {
                                if (counter[j] == '(' | counter[j] == '[')
                                    count++;
                                else
                                    if (counter[j] != 'z')
                                    count--;
                                j--;
                            }
                            if (count != 0)
                                return false;
                            counter[i] = 'z';
                            if (j >= 0)
                            {
                                counter[j] = 'z';
                            }
                            else
                            {
                                counter[j + 1] = 'z';
                            }
                            break;
                        default:
                            d++;
                            break;
                    }
                }
                if (d != counter.Length)
                    return true;
                else
                    return false;
            }

            Console.WriteLine(validBraces("(){}[]"));     
            Console.WriteLine(validBraces("([{}])"));     
            Console.WriteLine(validBraces("}(}"));  
            Console.WriteLine(validBraces("[(])"));     
            Console.WriteLine(validBraces("[({})](]"));
            Console.WriteLine(validBraces("))"));
            Console.ReadKey();
        }
    }
}
