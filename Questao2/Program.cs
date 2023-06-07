using Newtonsoft.Json;
using System.Text;
using System;
using System.Text.Json.Nodes;
using Questao2;

public class Program
{
    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static int GetGoals(string teamName, int year, string numberOfTeam)
    {
        int totalGoals = 0;
        int page = 1;
        int totalPages = 1;

        while (page <= totalPages)
        {
            var client = new HttpClient();

            var uri = string.Concat(@"https://jsonmock.hackerrank.com/api/football_matches?"
            , "year=", year, "&", numberOfTeam, "=", teamName, "&page=", page);
            var result = client.GetAsync(uri);
            result.Wait();

            string resultadoJson = result.Result.Content.ReadAsStringAsync().Result;

            dynamic results = JsonConvert.DeserializeObject(resultadoJson);

            foreach (var item in results.data)
            {
                if (numberOfTeam == "team1")
                {
                    totalGoals += Convert.ToInt32(item.team1goals);
                }
                else if (numberOfTeam == "team2") 
                {
                    totalGoals += Convert.ToInt32(item.team2goals);
                }

            }

            totalPages = results.total_pages;

            page++;
        }

        return totalGoals;
    }

    public static int getTotalScoredGoals(string team, int year)
    {
        int totalGoals = 0;

        totalGoals += GetGoals(team, year, "team1");

        totalGoals += GetGoals(team, year, "team2");

        return totalGoals;
    }

}