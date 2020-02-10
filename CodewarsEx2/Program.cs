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
            //Linal Test = new Linal();
            ////Ошибка не квадратная матрица
            //Console.WriteLine(Test.Determinant(new int[][] { new[] { 2, 5 }, new[] { 1, -2, -1 }, new[] { 1, 3, 4 } }));
            //
            ////Всё должно пройти
            //Console.WriteLine(Test.Determinant(new int[][] { new[] { 2, 5, 3 }, new[] { 1, -2, -1 }, new[] { 1, 3, 4 } }));
            //Console.WriteLine(Test.Determinant(new double[][] { new[] { 2.0, 5.0, 3.0 }, new[] { 1.0, -2.0, -1.0 }, new[] { 1.0, 3.0, 4.0 } }));
            //
            ////Всё должно пройти
            //Console.WriteLine(Test.Determinant(new int[,] { { 2, 5, 3 }, { 1, -2, -1 }, { 1, 3, 4 } }));
            //Console.WriteLine(Test.Determinant(new double[,] { { 2.0, 5.0, 3.0 }, { 1.0, -2.0, -1.0 }, { 1.0, 3.0, 4.0 } }));
            //Console.ReadKey();
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
            Console.WriteLine("Первая задача!\n");
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
            Console.WriteLine("Вторая задача!\n");
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
            Console.WriteLine("Третья задача!\n");
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
            Console.WriteLine("Четвёртая задача!\n");
            Console.WriteLine(PigIt("Pig latin is cool")); // igPay atinlay siay oolcay
            Console.WriteLine(PigIt("Hello world !"));     // elloHay orldway !
            Console.ReadKey();
            Console.WriteLine("\n");

            //Пятая задача
            //https://www.codewars.com/kata/551dd1f424b7a4cdae0001f0/train/csharp
            string WhoIsNext(string[] names, long n)
            {
                long dlin = 0;
                long score = names.Length;
                long kol = 1;
                while (score < n)
                {
                    kol *= 2;
                    dlin = score;
                    score = score + kol * names.Length;
                }
                long ostOch = n - dlin;
                int ost = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(ostOch) / Convert.ToDouble(kol))) - 1;
                return names[ost];
            }
            string[] namesOfPerson = new string[] { "Sheldon", "Leonard", "Penny", "Rajesh", "Howard" };
            Console.WriteLine("Пятая задача!\n");
            Console.WriteLine(WhoIsNext(namesOfPerson, 1));             //== "Sheldon"
            Console.WriteLine(WhoIsNext(namesOfPerson, 52));            //== "Penny"
            Console.WriteLine(WhoIsNext(namesOfPerson, 7230702951));    //== "Leonard"
            Console.WriteLine(WhoIsNext(namesOfPerson, 5));             //== "Howard"
            Console.ReadKey();
            Console.WriteLine("\n");

            //Шестая задача
            //https://www.codewars.com/kata/52a382ee44408cea2500074c/train/csharp
            int Determinant(int[][] matrix)
            {
                int counter = 0;
                if (matrix.Length == 1)
                {
                    return matrix[0][0];
                }
                else
                {
                    int[][] detMatrix = new int[matrix.Length - 1][];
                    for (int i = 0; i < detMatrix.Length; i++)
                    {
                        detMatrix[i] = new int[detMatrix.Length];
                    }
                    for (int i = 0; i < matrix[0].Length; i++)
                    {
                        for (int j = 1; j < matrix.Length; j++)
                        {
                            int d = 0;
                            for (int k = 0; k < matrix[j].Length; k++)
                            {
                                if (k != i)
                                {
                                    detMatrix[j - 1][k + d] = matrix[j][k];
                                }
                                else
                                {
                                    d = -1;
                                    continue;
                                }
                            }
                        }
                        counter += Convert.ToInt32(Math.Pow(-1, Convert.ToDouble(i))) * matrix[0][i] * Determinant(detMatrix);
                    }
                    return counter;
                }
            }

            Console.WriteLine("Шестая задача!\n");
            Console.WriteLine(Determinant(new int[][] { new[] { 2, 5, 3 }, new[] { 1, -2, -1 }, new[] { 1, 3, 4 } }));
            Console.ReadKey();
            Console.WriteLine("\n");

            //Седьмая задача
            //https://www.codewars.com/kata/5270d0d18625160ada0000e4/train/csharp
            int Score(int[] dice)
            {
                Int16 amountDice = 5;
                Int16 valueDice = 6;
                int finalScore = 0;
                Int16[] diceNumber = new Int16[6] { 0, 0, 0, 0, 0, 0 };

                //Создание массива количества значений на кубиках
                for (Int16 i = 0; i < amountDice; i++)
                    diceNumber[dice[i] - 1]++;

                //Проверка, больше ли трёх одинаковых значений
                for (Int16 i = 0; i < valueDice; i++)
                    if (diceNumber[i] >= 3)
                    {
                        if (i + 1 == 1)                     //Для единицы особый случай
                            finalScore += 1000;
                        else
                            finalScore += (i + 1) * 100;
                        diceNumber[i] -= 3;
                    }

                //Добавляю оставшиеся 1 и 5.
                finalScore += diceNumber[0] * 100 + diceNumber[4] * 50;


                return finalScore;
            }

            Console.WriteLine("Седьмая задача!\n");
            Console.WriteLine("Ответ к седьмой задаче: {0}.", Score(new int[] { 4, 4, 4, 3, 3 }));
            Console.ReadKey();
            Console.WriteLine("\n");

                //Восьмая задача
                //https://www.codewars.com/kata/5263a84ffcadb968b6000513/train/csharp
                int[,] MatrixMultiplication(int[,] a, int[,] b)
                {
                    //a.GetLength(0);                       //Строка a матрицы
                    //a.GetLength(1);                       //Столбец a матрицы
                    if (a.GetLength(1) != b.GetLength(0))   //Основное правило перемножения матриц
                        return null;
                    else
                    {
                        int[,] multiMatrix = new int[b.GetLength(1), a.GetLength(0)];
                        for (int i = 0; i < b.GetLength(1); i++)            // Новая матрица будет количество столбцов второй *
                            for (int j = 0; j < a.GetLength(0); j++)        // на количество строк первой.
                                for (int k = 0; k < a.GetLength(1); k++)    // количество произведений, равное стобцам первой матрицы
                                                                            // или строкам второй. Можно как угодно
                                    multiMatrix[i, j] += a[i, k] * b[k, j]; // O(n^3) WTF?!?!?!?!      
                        return multiMatrix;
                    }
                }

                Console.WriteLine("Восьмая задача!\n");
                int[,] firstMatrix = { { 9, 7 }, { 0, 1 } };
                int[,] secondMatrix = { { 1, 1 }, { 4, 12 } };
                int[,] expected = { { 37, 93 }, { 4, 12 } };
                int[,] actual = MatrixMultiplication(firstMatrix, secondMatrix);
                //Console.WriteLine();
                Console.ReadKey();
                Console.WriteLine("\n");

                //Девятая задача
                //https://www.codewars.com/kata/53db96041f1a7d32dc0004d2/train/csharp
                string DoneOrNot(int[][] board)
                {
                    int[] Check = new int[9];
                    for (int i = 0; i < 9; i++)
                    {
                        board[i].CopyTo(Check, 0);
                        Array.Sort(Check);                              //Сортируем строку        
                        for (int j = 0; j < 9; j++)
                        {
                            if (Check[j] != j + 1)                      //Проверка строк на повторение
                            {
                                return "Try again!";
                            }
                            Check[j] = board[j][i];                     //Если всё нормально, то, перезаполняем Check столбцом
                        }
                        Array.Sort(Check);                              //Сортируем столбец
                        for (int j = 0; j < 9; j++)
                        {
                            if (Check[j] != j + 1)                      //Проверка столбца на повторение
                            {
                                return "Try again!";
                            }
                        }
                    }
                    for (int i = 0; i < 3; i++)                         //Рассматриваем квадраты
                    {
                        Int16 counter = 0;
                        for (int j = 3 * i; j < 3 * (i + 1); j++)       //Строки в квадратах
                        {
                            for (int k = 3 * i; k < 3 * (i + 1); k++)   //Столбцы в квадратах
                            {
                                Check[counter] = board[j][k];           //O(n^3) T.T
                                counter++;
                            }
                        }
                        Array.Sort(Check);
                        for (int j = 0; j < 9; j++)
                        {
                            if (Check[j] != j + 1)                      //Проверка квадрата на повторение
                            {
                                return "Try again!";
                            }
                        }
                    }
                    return "Finished!";
                }

                Console.WriteLine("Девятая задача!\n");
                Console.WriteLine("Ответ к девятой задаче: \"{0}\".", DoneOrNot(new int[][] {
                    new [] {5, 3, 4, 6, 7, 8, 9, 1, 2},
                    new [] {6, 7, 2, 1, 9, 5, 3, 4, 8},
                    new [] {1, 9, 8, 3, 4, 2, 5, 6, 7},
                    new [] {8, 5, 9, 7, 6, 1, 4, 2, 3},
                    new [] {4, 2, 6, 8, 5, 3, 7, 9, 1},
                    new [] {7, 1, 3, 9, 2, 4, 8, 5, 6},
                    new [] {9, 6, 1, 5, 3, 7, 2, 8, 4},
                    new [] {2, 8, 7, 4, 1, 9, 6, 3, 5},
                    new [] {3, 4, 5, 2, 8, 6, 1, 7, 9}}));
                Console.ReadKey();
                Console.WriteLine("\n");

            //Десятая задача
            //https://www.codewars.com/kata/51c8e37cee245da6b40000bd/train/csharp
            string StripComments(string text, string[] commentSymbols)
            {
                string[] rows = text.Split(new char[] { '\n' });
                for( int i = 0; i < rows.Length; i++)
                {
                    int markersPos = rows[i].Length;
                    foreach(string markers in commentSymbols)       //Находим первый символ для коментария
                    {
                        if( (rows[i].IndexOf(markers) != -1) && (markersPos > rows[i].IndexOf(markers)) )
                        {
                            markersPos = rows[i].IndexOf(markers);
                        }
                    }
                    if (markersPos != rows[i].Length)
                    {
                        rows[i] = rows[i].Substring(0, markersPos);
                    }
                    rows[i] = rows[i].TrimEnd();
                }
                return string.Join("\n", rows);
            }
            Console.WriteLine(StripComments("apples, pears # and bananas\ngrapes\nbananas !apples", new[] { "#", "!" }));
            // result should == "apples, pears\ngrapes\nbananas"
            Console.WriteLine(StripComments("a #b\nc\nd $e f g", new string[] { "#", "$" }));
            Console.ReadKey();
        }
    }
}
