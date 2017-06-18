using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDal
{
    public class BaseDal<T> where T : class, new()
    {
        //获取EF实例，保证EF线程唯一
        DbContext Db = DataDal.DBContextFactory.CreateDbContext();

        //条件查询
        public IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return Db.Set<T>().Where<T>(whereLambda);//设置成set，具体操作的数据
        }

        //数据分页并排序
        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
            var temp = Db.Set<T>().Where<T>(whereLambda);
            totalCount = temp.Count();
            if (isAsc)//升序
            {
                temp = temp.OrderBy<T, s>(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            else
            {
                temp = temp.OrderByDescending<T, s>(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            return temp;
        }

        // 删除
        public bool DeleteEntity(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.EntityState.Deleted;
            return true;
        }

        // 修改更新
        public bool EditEntity(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.EntityState.Modified;
            return true;
        }

        // 添加
        public T AddEntity(T entity)
        {
            Db.Set<T>().Add(entity);
            return entity;
        }
    }
}
