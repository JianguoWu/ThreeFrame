using DataDal;
using IDataDal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDALFactory
{
    public class DBSession : IDBSession
    {
        //获取EF实例，保证EF线程唯一
        public DbContext Db
        {
            get
            {
                return DBContextFactory.CreateDbContext();
            }
        }

        public IDepartmentDal _DepartmentDal;
        public IDepartmentDal DepartmentDal
        {
            get
            {
                if (_DepartmentDal == null)
                {
                    //_StudentDal = new StudentDal();
                    _DepartmentDal = AbstractFactory.CreateDepartmentDal();//通过抽象工厂封装了类的实例创建
                }
                return _DepartmentDal;
            }
            set
            {
                _DepartmentDal = value;
            }
        }

        /// <summary>
        /// 重写接口中的SaveChanges方法
        /// 一个业务中经常涉及到多张表操作，我们希望连接一次数据库，完成多张表的数据操作，提高性能
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return Db.SaveChanges() > 0;
        }
    }
}