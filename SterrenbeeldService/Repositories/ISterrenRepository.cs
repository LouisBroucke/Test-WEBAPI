using SterrenbeeldService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SterrenbeeldService.Repositories
{
    public interface ISterrenRepository
    {
        Sterrenbeeld FindByDagmaand(string dagmaand);
    }
}
