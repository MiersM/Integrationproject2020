using HP_Project.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Project.DAL.Repositories
{
    public class InsightRepository : IInsightRepository
    {
        private readonly AppDbContext _context;

        public InsightRepository(AppDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Insight> GetAll()
        {
            return _context.Insights;
        }

        public Insight Add(Insight insight)
        {
            var newInsight = _context.Insights.Add(insight);

            if (newInsight != null && newInsight.State == EntityState.Added)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return newInsight.Entity;
                }
            }

            return null;
        }
    }
}
