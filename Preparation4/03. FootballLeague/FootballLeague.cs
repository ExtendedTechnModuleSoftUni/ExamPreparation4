namespace _03.FootballLeague
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Text;

    public class FootballLeague
    {
        public static void Main()
        {
            var inputKey = Console.ReadLine();
            var escapedCharacters = @".|\/?!+*^$[](){}";
            var key = string.Empty;
            var sb = new StringBuilder();
            var teamResultDict = new Dictionary<string, long>();
            var goalsDict = new Dictionary<string, long>();

            for (int i = 0; i < inputKey.Length; i++)
            {
                if (escapedCharacters.Contains(inputKey[i]))
                {
                    sb.Append("\\" + inputKey[i]);
                }
                else
                {
                    sb.Append(inputKey[i]);
                }
            }

            key = sb.ToString();

            var lines = Console.ReadLine();

            var regex = new Regex(key + "([A-za-z]+|)" + key + ".*" + key + "([A-za-z]+|)" + key + ".*\\s(\\d+):(\\d+)");

            while (lines != "final")
            {
                var match = regex.Match(lines);

                var isMatch = regex.IsMatch(lines);

                if (isMatch)
                {
                    GetTeamsAndResults(teamResultDict, goalsDict, match);
                }

                lines = Console.ReadLine();
            }

            PrintResult(teamResultDict, goalsDict);
        }

        static void GetTeamsAndResults(Dictionary<string, long> teamResultDict, Dictionary<string, long> goalsDict, Match match)
        {
            var firstTeamArr = match.Groups[1].ToString().ToUpper().Reverse().ToArray();
            var firstTeam = string.Join("", firstTeamArr);
            var secondTeamArr = match.Groups[2].ToString().ToUpper().Reverse().ToArray();
            var secondTeam = string.Join("", secondTeamArr);
            var firstTeamGoals = int.Parse(match.Groups[3].ToString());
            var secondTeamGoals = int.Parse(match.Groups[4].ToString());

            if (!teamResultDict.ContainsKey(firstTeam))
            {
                teamResultDict.Add(firstTeam, 0);
                goalsDict.Add(firstTeam, 0);
            }

            goalsDict[firstTeam] += firstTeamGoals;

            if (!teamResultDict.ContainsKey(secondTeam))
            {
                teamResultDict.Add(secondTeam, 0);
                goalsDict.Add(secondTeam, 0);
            }

            goalsDict[secondTeam] += secondTeamGoals;

            if (firstTeamGoals > secondTeamGoals)
            {
                teamResultDict[firstTeam] += 3;
            }
            else if (firstTeamGoals < secondTeamGoals)
            {
                teamResultDict[secondTeam] += 3;
            }
            else
            {
                teamResultDict[firstTeam] += 1;
                teamResultDict[secondTeam] += 1;
            }
        }

        static void PrintResult(Dictionary<string, long> teamResultDict, Dictionary<string, long> goalsDict)
        {
            var counter = 1;

            Console.WriteLine("League standings:");

            foreach (var result in teamResultDict.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{counter}. {result.Key} {result.Value}");
                counter++;
            }

            Console.WriteLine("Top 3 scored goals:");

            foreach (var team in goalsDict.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Take(3))
            {
                Console.WriteLine($"- {team.Key} -> {team.Value}");
            }
        }
    }
}
