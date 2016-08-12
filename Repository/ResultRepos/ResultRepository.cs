using Repository.GenericRepos;
using SportEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Repository.ResultRepos
{
    public class ResultRepository : GenericEFRepository<results>, IResultRepository
    {
        public ResultRepository(DbContext newctx) : base(newctx)
        {
        }

        public List<MatchData> GetAllMatches()
        {
            var q = from result in context.Set<results>()
                    join score1 in context.Set<scores>() on result.result_score1 equals score1.score_id
                    join score2 in context.Set<scores>() on result.result_score2 equals score2.score_id
                    join team1 in context.Set<teams>() on score1.score_team equals team1.team_id
                    join team2 in context.Set<teams>() on score2.score_team equals team2.team_id
                    select new MatchData() { Team1 = team1.team_name, Team2 = team2.team_name, Goal1 = score1.score_goals, Goal2 = score2.score_goals };
            return q.ToList();

        }

        public List<GlobalResults> GetAllResults()
        {
            string sql = @"SELECT sub.num as NumberOfWins, team_name as TeamName
                          FROM(
                                SELECT count(1) as num, score_team
                                FROM score
                                WHERE score_wings=1
                                GROUP BY score_team) sub, teams
                         WHERE sub.score_team=team_id";
            context.Database.SqlQuery<GlobalResults>(sql).ToList();

            var q = from akt in context.Set<scores>()
                    group akt by akt.teams into g
                    select new GlobalResults() { Wins = g.Count(x => x.score_wins == 1), Team = g.Key.team_name };

            return q.ToList();
        }

        public override results GetById(int id)
        {
            return GetAll().SingleOrDefault(akt => akt.result_id == id);
        }
    }

}
