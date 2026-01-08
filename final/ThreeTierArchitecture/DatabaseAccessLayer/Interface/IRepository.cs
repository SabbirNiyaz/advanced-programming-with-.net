using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Interface
{
    public interface IRepository <CLASS> where CLASS : class
    {
        bool Create(CLASS obj);
        bool Update(CLASS obj);
        List<CLASS> Get();
        CLASS Get(int id);
        bool Delete(int id);
    }
}
