namespace _04.CubicMessages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Text;

    public class CubicMessages
    {
        public static void Main()
        {
            var message = Console.ReadLine();
            var messageLength = int.Parse(Console.ReadLine());
            var decryptMessage = new StringBuilder();
            var messageVerificationCode = new List<string>();

            while (true)
            {
                var regex = new Regex(@"^(\d+)([A-Za-z]{" + messageLength + "})([^A-Za-z]*)$");

                var isMatch = regex.IsMatch(message);

                if (isMatch)
                {
                    var match = regex.Match(message);
                    var leftIndexes = match.Groups[1].ToString().ToArray();
                    var currentMessage = match.Groups[2].ToString();
                    var rightIndexes = match.Groups[3].ToString().ToArray();

                    for (int i = 0; i < leftIndexes.Length; i++)
                    {
                        var currentIndex = int.Parse(leftIndexes[i].ToString());

                        DecryptingMessage(decryptMessage, currentMessage, currentIndex);
                    }

                    for (int i = 0; i < rightIndexes.Length; i++)
                    {
                        var currentIndex = 0;
                        var isDigit = int.TryParse(rightIndexes[i].ToString(), out currentIndex);

                        if (isDigit)
                        {
                            DecryptingMessage(decryptMessage, currentMessage, currentIndex);
                        }
                    }

                    messageVerificationCode.Add(currentMessage + " == " + decryptMessage.ToString());
                    decryptMessage.Clear();
                }

                message = Console.ReadLine();

                if (message == "Over!")
                {
                    break;
                }

                messageLength = int.Parse(Console.ReadLine());

            }

            foreach (var messageAndCode in messageVerificationCode)
            {
                Console.WriteLine(messageAndCode);
            }
        }

        static void DecryptingMessage(StringBuilder decryptMessage, string currentMessage, int currentIndex)
        {
            if (currentIndex >= currentMessage.Length)
            {
                decryptMessage.Append(' ');
            }
            else
            {
                decryptMessage.Append(currentMessage[currentIndex]);
            }
        }
    }
}
