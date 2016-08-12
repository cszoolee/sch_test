using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repository;
using SportEntities;

namespace Console
{

    class Program
    {
        static Repository.TeamRepos.ITeamRepository teamRepo;
        static Repository.ResultRepos.IResultRepository resultsRepo;

        static Program()
        {
            SportEntities.DatabaseEntities nhl = new SportEntities.DatabaseEntities();
            teamRepo = new Repository.TeamRepos.TeamRepository(nhl);
            resultsRepo = new Repository.ResultRepos.ResultRepository(nhl);
        }


        static void Main(string[] args)
        {
            foreach (var akt in teamRepo.GetAll())
            {
                System.Console.WriteLine("{0} = {1}", akt.team_id, akt.team_name);
            }

            teams Detroit = new teams();
            Detroit.team_name = "Detroit Red Wings";
            teamRepo.Insert(Detroit);

            foreach (var akt in teamRepo.GetAll())
            {
                System.Console.WriteLine("{0} = {1}", akt.team_id, akt.team_name);
            }

            System.Console.ReadLine();
        }
    }
}
