﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataDal
{
    /// <summary>
    /// 数据访问接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseDal<T> where T : class, new()
    {
        //条件查询
        IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda);

        //数据分页并排序
        IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, s>> orderbyLambda, bool isAsc);

        // 删除
        bool DeleteEntity(T entity);

        // 修改更新
        bool EditEntity(T entity);

        // 添加
        T AddEntity(T entity);
    }
}