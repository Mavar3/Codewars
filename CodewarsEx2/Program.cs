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
            Console.WriteLine("\n");

            //Третья задача.
            //https://www.codewars.com/kata/513e08acc600c94f01000001/train/csharp
            string Rgb(int r, int g, int b)
            {
                int[] rgbInt = { r, g, b };
                string rgbHex = "";
                for (int i = 0; i < rgbInt.Length; i++)
                {
                    if (0 <= rgbInt[i] && rgbInt[i] <= 255)
                    {
                        if (rgbInt[i] < 16)
                        {
                            rgbHex += "0";
                        }
                        rgbHex += Convert.ToString(rgbInt[i], 16).ToUpper();
                    }
                    else
                    {
                        if (rgbInt[i] < 0)
                        {
                            rgbHex += "00";
                        }
                        else
                        {
                            rgbHex += "FF";
                        }
                    }
                }
                return rgbHex;
            }
            Console.WriteLine(Rgb(255, 255, 255));  // returns FFFFFF
            Console.WriteLine(Rgb(255, 255, 300));  // returns FFFFFF
            Console.WriteLine(Rgb(0, 0, 0));        // returns 000000
            Console.WriteLine(Rgb(148, 0, 211));    // returns 9400D3
            Console.ReadKey();
            Console.WriteLine("\n");

            //Четвёртая задача
            //https://www.codewars.com/kata/520b9d2ad5c005041100000f/train/csharp

            string PigIt(string text)
            {
                string[] word = text.Split();
                text = "";
                for (int i = 0; i < word.Length; i++)
                {
                    char[] letter = word[i].ToCharArray();
                    char firstLetter = letter[0];
                    for (int j = 1; j < letter.Length; j++)
                    {
                        text += letter[j];
                    }
                    text += firstLetter;
                    if (firstLetter != '!' && firstLetter != '?' && firstLetter != '.' && i != word.Length - 1)
                    {
                        text += "ay ";
                    }
                    else
                    {
                        if (i == word.Length - 1)
                        {
                            text += "ay";
                        }
                    }
                }
                return text;
            }
            Console.WriteLine(PigIt("Pig latin is cool")); // igPay atinlay siay oolcay
            Console.WriteLine(PigIt("Hello world !"));     // elloHay orldway !
            Console.ReadKey();
        }
    }
}
