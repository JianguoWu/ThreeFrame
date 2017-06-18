using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataDal
{
    /// <summary>
    /// 业务层调用的是数据会话层的接口
    /// </summary>
    public interface IDBSession
    {
        DbContext Db { get; }
        IDepartmentDal DepartmentDal { get; set; }
        bool SaveChanges();
    }
}