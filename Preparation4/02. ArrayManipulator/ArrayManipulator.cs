namespace _02.ArrayManipulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ArrayManipulator
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var command = Console.ReadLine();
            var max = int.MinValue;
            var min = int.MaxValue;
            var count = 0;
            var elements = new List<int>();

            while (command != "end")
            {
                var currentCommand = command.Split(' ').ToArray();
                var index = 0;
                var isDigit = int.TryParse(currentCommand[1], out index);

                switch (currentCommand[0])
                {
                    case "exchange":
                        GetExchangeCommand(arr, index);
                        break;
                    case "max":
                        switch (currentCommand[1])
                        {
                            case "odd":
                                GetMaxOddCommand(arr, max);
                                break;
                            case "even":
                                GetMaxEvenCommand(arr, max);
                                break;
                        }
                        break;
                    case "min":
                        switch (currentCommand[1])
                        {
                            case "odd":
                                GetMinOddCommand(arr, min);
                                break;
                            case "even":
                                GetMinEvenCommand(arr, min);
                                break;
                        }
                        break;
                    case "first":
                        if (index > arr.Count)
                        {
                            Console.WriteLine("Invalid count");
                            command = Console.ReadLine();
                            continue;
                        }
                        switch (currentCommand[2])
                        {
                            case "odd":
                                GetFirstOdd(arr, count, elements, index);
                                break;
                            case "even":
                                GetFirstEven(arr, count, elements, index);
                                break;
                        }
                        break;
                    case "last":
                        if (index > arr.Count)
                        {
                            Console.WriteLine("Invalid count");
                            command = Console.ReadLine();
                            continue;
                        }
                        switch (currentCommand[2])
                        {
                            case "odd":
                                GetLastOddCommnd(arr, count, elements, index);
                                break;
                            case "even":
                                GetLastEvenCommand(arr, count, elements, index);
                                break;
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("[" + string.Join(", ", arr) + "]");
        }

        static void GetLastEvenCommand(List<int> arr, int count, List<int> elements, int index)
        {
            for (int i = arr.Count - 1; i >= 0; i--)
            {
                if (count == index)
                {
                    break;
                }
                if (arr[i] % 2 == 0)
                {
                    elements.Add(arr[i]);
                    count++;
                }
            }

            PrintResult(elements);
        }

        static void GetLastOddCommnd(List<int> arr, int count, List<int> elements, int index)
        {
            for (int i = arr.Count - 1; i >= 0; i--)
            {
                if (count == index)
                {
                    break;
                }

                if (arr[i] % 2 == 1)
                {
                    elements.Add(arr[i]);
                    count++;
                }
            }

            PrintResult(elements);
        }

        static void PrintResult(List<int> elements)
        {
            if (elements.Count > 0)
            {
                Console.Write("[");
                for (int i = elements.Count - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        Console.WriteLine(elements[i] + "]");
                    }
                    else
                    {
                        Console.Write(elements[i] + ", ");
                    }
                }
            }
            else
            {
                Console.WriteLine("[]");
            }

            elements.Clear();
        }

        static void GetFirstEven(List<int> arr, int count, List<int> elements, int index)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                if (count == index)
                {
                    break;
                }
                if (arr[i] % 2 == 0)
                {
                    elements.Add(arr[i]);
                    count++;
                }
            }

            Console.WriteLine("[" + string.Join(", ", elements) + "]");
            elements.Clear(); ;
        }

        static void GetFirstOdd(List<int> arr, int count, List<int> elements, int index)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                if (count == index)
                {
                    break;
                }
                if (arr[i] % 2 == 1)
                {
                    elements.Add(arr[i]);
                    count++;
                }
            }

            Console.WriteLine("[" + string.Join(", ", elements) + "]");
            elements.Clear();
        }

        static void GetMinEvenCommand(List<int> arr, int min)
        {
            var minEvenIndex = 0;
            var isMinEvenElementFound = false;

            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    if (arr[i] <= min)
                    {
                        min = arr[i];
                        minEvenIndex = i;
                        isMinEvenElementFound = true;
                    }
                }
            }

            if (isMinEvenElementFound)
            {
                Console.WriteLine(minEvenIndex);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        static void GetMinOddCommand(List<int> arr, int min)
        {
            var minOddIndex = 0;
            var isMinOddElementFound = false;

            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] % 2 == 1)
                {
                    if (arr[i] <= min)
                    {
                        min = arr[i];
                        minOddIndex = i;
                        isMinOddElementFound = true;
                    }
                }
            }

            if (isMinOddElementFound)
            {
                Console.WriteLine(minOddIndex);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        static void GetMaxEvenCommand(List<int> arr, int max)
        {
            var maxEvenIndex = 0;
            var isMaxEvenElementFound = false;
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    if (arr[i] >= max)
                    {
                        max = arr[i];
                        maxEvenIndex = i;
                        isMaxEvenElementFound = true;
                    }
                }
            }

            if (isMaxEvenElementFound)
            {
                Console.WriteLine(maxEvenIndex);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        static void GetMaxOddCommand(List<int> arr, int max)
        {
            var maxOddIndex = 0;
            var isMaxOddElementFound = false;

            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] % 2 == 1)
                {
                    if (arr[i] >= max)
                    {
                        max = arr[i];
                        maxOddIndex = i;
                        isMaxOddElementFound = true;
                    }
                }
            }

            if (isMaxOddElementFound)
            {
                Console.WriteLine(maxOddIndex);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        static void GetExchangeCommand(List<int> arr, int index)
        {
            if (index < 0 || index > arr.Count - 1)
            {
                Console.WriteLine("Invalid index");
            }
            else
            {
                var rightPart = arr.Skip(index + 1).ToList();
                var leftPart = arr.Take(index + 1).ToList();
                arr.Clear();

                arr.AddRange(rightPart);
                arr.AddRange(leftPart);
            }
        }
    }
}
