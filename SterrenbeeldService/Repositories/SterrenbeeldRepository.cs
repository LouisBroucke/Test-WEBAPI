using SterrenbeeldService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SterrenbeeldService.Repositories
{
    public class SterrenbeeldRepository : ISterrenRepository
    {
        private readonly SterrenDBContext context;
        public SterrenbeeldRepository(SterrenDBContext context)
        {
            this.context = context;
        }        

        public Sterrenbeeld FindByDagmaand(string dagmaand)
        {
            return context.Sterrenbeelden.Find(FindId(dagmaand));
        }

        private int FindId(string dagmaand)
        {
            string[] gesplitsteDatum = dagmaand.Split('-');
            int dag = int.Parse(gesplitsteDatum[0]);
            int maand = int.Parse(gesplitsteDatum[1]);

            Sterrenbeeld sterrenbeeld = context.Sterrenbeelden.Where(s => s.StartMaand == maand).First();

            if (sterrenbeeld.StartDag > dag)
            {
                int id = sterrenbeeld.ID - 1;

                if (id == 0)
                {
                    return 12;
                }
                else
                {
                    return id;
                }
            }
            else
            {
                return sterrenbeeld.ID;
            }
        }
    }
}
