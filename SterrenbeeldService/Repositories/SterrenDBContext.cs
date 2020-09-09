using Microsoft.EntityFrameworkCore;
using SterrenbeeldService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SterrenbeeldService.Repositories
{
    public class SterrenDBContext : DbContext
    {
        public SterrenDBContext(DbContextOptions<SterrenDBContext> options) : base(options)
        {
        }

        public DbSet<Sterrenbeeld> Sterrenbeelden { get; set; }
    }
}
