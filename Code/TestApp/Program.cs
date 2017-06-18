using Business;
using EntityModel;
using IBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IDepartmentBusiness idb = new DepartmentBusiness();
            List<Department> list = idb.LoadEntities(s => true).ToList();
            foreach (var dep in list)
            {
                Console.WriteLine(dep.DNo + "-------------" + dep.DName);
            }
            Console.ReadKey();
        }
    }
}
