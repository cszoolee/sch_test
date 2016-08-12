using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EmpRepos
{
    public class GetAveragesResult
    {
        public decimal ID { get; set; }
        public decimal? AVG { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is GetAveragesResult)
            {
                GetAveragesResult other = obj as GetAveragesResult;
                return this.ID == other.ID && this.AVG == other.AVG;
            }
            else return false;
        }

        public override int GetHashCode()
        {
            //return ID.GetHashCode() + AVG.GetHashCode();
            return 1;
        }
    }
}