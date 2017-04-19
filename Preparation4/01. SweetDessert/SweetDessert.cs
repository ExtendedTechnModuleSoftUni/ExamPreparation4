namespace _01.SweetDessert
{
    using System;

    public class SweetDessert
    {
        public static void Main()
        {
            var money = decimal.Parse(Console.ReadLine());
            var guestsNumber = int.Parse(Console.ReadLine());
            var bananasPrice = decimal.Parse(Console.ReadLine());
            var eggsPrice = decimal.Parse(Console.ReadLine());
            var barriesPricePerKilo = decimal.Parse(Console.ReadLine());

            var portionsNeeded = (int)Math.Ceiling(guestsNumber / 6.0);

            decimal totalMoneyNeeded =
                portionsNeeded * (2 * bananasPrice)
                + portionsNeeded * (4 * eggsPrice)
                + portionsNeeded * (0.2M * barriesPricePerKilo);

            if (money >= totalMoneyNeeded)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {totalMoneyNeeded:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {(totalMoneyNeeded - money):f2}lv more.");
            }
        }
    }
}
