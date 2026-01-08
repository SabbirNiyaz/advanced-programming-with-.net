using DataTier.EF;
using DataTier.EF.Models;
using DataTier.Interfaces;
using DataTier.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class DataAccessFactory
    {
        DatabaseRepresentContext db;
        public DataAccessFactory(DatabaseRepresentContext db) 
        {
            this.db = db;
        }
        public IRepository<Category> CategoryData()
        {
            return new CategoryRepoV2(db);
        }
    }
}
