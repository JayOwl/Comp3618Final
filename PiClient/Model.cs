﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PiClient
{
    public class PerformanceContext : DbContext
    {
        public DbSet<Speed> Speeds { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=speed.db");
    }

    public class Speed
    {
        public int SpeedId { get; set; }
        public string SpeedMS { get; set; }
        public string Type { get; set; }

    }
}
