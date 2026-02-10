using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindsBookingSystem
{
    public interface InterfaceCRUD
    {
        void Add();
        void Remove();
        void Update();
        String View(int id);
        DataSet RetrieveAll();
    }
}
