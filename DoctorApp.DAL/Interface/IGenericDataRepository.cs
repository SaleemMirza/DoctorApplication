using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApp.DAL.Interface
{
    public interface IGenericDataRepository<T> where T : class
    {
        int GetNumberOfRecords(Func<T, bool> filter);
      //  IList<T> Get(Func<T, bool> filter, int page, int pageSize, string[] includePaths = null, params SortExpression<T>[] sortExpressions);

        IList<T> Get();



       // IList<T> GetRefrences();
        //IList<T> getPieChart(string SQLQuery);

        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        void Add(params T[] items);
        void Update(params T[] items);
        void Update<P>(Expression<Func<T, P>> excludeColumn, params T[] items);
        void Remove(params T[] items);

    }
}

