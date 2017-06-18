using EntityModel;
using IDataDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDal
{
    //先继承父类，后实现节后
    public class DepartmentDal : BaseDal<Department>, IDepartmentDal
    {
    }
}
