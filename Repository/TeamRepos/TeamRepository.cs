using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SportEntities;
using Repository.GenericRepos;
using System.Data.Entity;

namespace Repository.TeamRepos
{
    public class TeamRepository : GenericEFRepository<teams>, ITeamRepository
    {
        public TeamRepository(DbContext newctx) : base(newctx)
        {
        }

        public override teams GetById(int id)
        {
            return GetAll().SingleOrDefault(act => act.team_id == id);
        }

        public int GetTeamId()
        {
            var rawQuery = context.Database.SqlQuery<int>("select next value for seq_teams");
            return rawQuery.Single();
        }

        public override void Insert(teams newentity)
        {
            newentity.team_id = GetTeamId();
            base.Insert(newentity);
        }
    }
}
