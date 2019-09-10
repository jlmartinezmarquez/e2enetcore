using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public static class SeedData
    {
        public static void PopulateTestData(AppDbContext dbContext)
        {
            //SeedData();
            dbContext.SaveChanges();
        }
    }
}
