using IDataDal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataDALFactory
{
    /// <summary>
    /// 通过反射的形式创建类的实例
    /// </summary>
    public class AbstractFactory
    {
        //首先在web.config中配置程序集名称与命名空间的名称
        //<add key="AssemblyPath" value="DAL"/>
        //<add key="NameSpace" value="DAL"/>
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["AssemblyPath"];
        private static readonly string NameSpace = ConfigurationManager.AppSettings["NameSpace"];

        //创建实例方法
        private static object CreateInsertance(string className)
        {
            var assembly = Assembly.Load(AssemblyPath);
            return assembly.CreateInstance(className);
        }

        //创建DepartmentDal实例
        public static IDepartmentDal CreateDepartmentDal()
        {
            string fullClassName = NameSpace + ".DepartmentDal";
            return CreateInsertance(fullClassName) as IDepartmentDal;
        }

    }
}
