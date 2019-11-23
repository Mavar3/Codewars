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
            bool is_valid_IP(string ipAddres)
            {
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
                                Int32.Parse(Numbers[i]) < 0 | Int32.Parse(Numbers[i]) > 255)
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
        }
    }
}
