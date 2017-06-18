using EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DataDal
{
    /// <summary>
    /// EF线程内唯一:负责创建EF数据操作上下文实例，必须线程内唯一
    /// </summary>
    public class DBContextFactory
    {
        public static DbContext CreateDbContext()
        {
            DbContext dbContext = (DbContext)CallContext.GetData("dbContext");
            if (dbContext == null)
            {
                dbContext = new EntityDbContext();
                CallContext.SetData("dbContext", dbContext);
            }
            return dbContext;
        }
    }
}