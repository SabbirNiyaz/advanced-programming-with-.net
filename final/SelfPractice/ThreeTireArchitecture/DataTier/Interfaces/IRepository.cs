using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier.Interfaces
{
    public interface IRepository <CLASS> where CLASS : class
    {
        bool Create(CLASS obj);
        bool Update(CLASS obj);
        List<CLASS> GetAll();
        CLASS GetById(int id);
        bool Delete(int id);
    }
}
