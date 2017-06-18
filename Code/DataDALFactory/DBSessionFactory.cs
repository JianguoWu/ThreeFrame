using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DataDALFactory
{/// <summary>
 /// EF线程唯一
 /// </summary>
    public class DBSessionFactory
    {
        public static IDataDal.IDBSession CreateDBSession()
        {
            IDataDal.IDBSession DbSession = (IDataDal.IDBSession)CallContext.GetData("dbSession");
            if (DbSession == null)
            {
                DbSession = new
                DataDALFactory.DBSession();
                CallContext.SetData("dbSession", DbSession);
            }
            return DbSession;
        }
    }
}
