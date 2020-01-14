using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using react_calculator.Models;

namespace Calculator
{
    public class HistoryContext : DbContext
    {
        public DbSet<Expression> Expressions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-S2L9C420;Database=CalculateHistory;Integrated Security=True;");
        }
    }
}
