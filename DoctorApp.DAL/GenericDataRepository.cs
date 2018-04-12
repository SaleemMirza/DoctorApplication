using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DoctorApp.DAL.Interface;

namespace DoctorApp.DAL
{
    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class
    {


       // public virtual IList<T> Get(Func<T, bool> filter, int page, int pageSize, string[] includePaths = null,
         //   params SortExpression<T>[] sortExpressions)

             public virtual IList<T> Get(Func<T, bool> filter, int page, int pageSize, string[] includePaths = null)
        {
            List<T> list;
            using (var context = new DocAppContext())
            {
                IQueryable<T> dbQuery = context.Set<T>();
                if (includePaths != null)
                {
                    for (var i = 0; i < includePaths.Count(); i++)
                    {
                        dbQuery = dbQuery.Include(includePaths[i]);
                    }
                }
                if (filter != null)
                {
                    dbQuery = dbQuery.Where(filter).AsQueryable();
                }
                IOrderedEnumerable<T> orderedQuery = null;
                //for (var i = 0; i < sortExpressions.Count(); i++)
                //{
                    //if (i == 0)
                    //{
                    //    if (sortExpressions[i].SortDirection == ListSortDirection.Ascending)
                    //    {
                    //        orderedQuery = dbQuery.OrderBy(sortExpressions[i].SortBy);
                    //    }
                    //    else
                    //    {
                    //        orderedQuery = dbQuery.OrderByDescending(sortExpressions[i].SortBy);
                    //    }
                    //}
                    //else
                    //{
                    //    if (sortExpressions[i].SortDirection == ListSortDirection.Ascending)
                    //    {
                    //        orderedQuery = orderedQuery.ThenBy(sortExpressions[i].SortBy);
                    //    }
                    //    else
                    //    {
                    //        orderedQuery = orderedQuery.ThenByDescending(sortExpressions[i].SortBy);
                    //    }
                    //}
                    //dbQuery = orderedQuery.AsQueryable();
               // }
                dbQuery = dbQuery.Skip(((int) page - 1)*(int) pageSize);
                dbQuery = dbQuery.Take((int) pageSize);

                list = dbQuery
                    .ToList<T>();

            }
            return list;

        }

        public virtual IList<T> Get()
        {
            List<T> list;
            using (var context = new DocAppContext())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                list = dbQuery
                    .ToList<T>();
            }
            return list;

        }

        public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;
            using (var context = new DocAppContext())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                item = dbQuery
                    .AsNoTracking() //Don't track any changes for the selected item
                    .FirstOrDefault(where); //Apply where clause
            }
            return item;
        }

        public void Add(params T[] items)
        {
            using (var context = new DocAppContext())
            {
                DbSet<T> dbSet = context.Set<T>();
                foreach (T item in items)
                {
                    dbSet.Add(item);
                }
                context.SaveChanges();
            }
        }

        public int GetNumberOfRecords(Func<T, bool> filter)
        {
            using (var context = new DocAppContext())
            {
                IEnumerable<T> dbQuery = context.Set<T>();

                if (filter != null)
                {
                    dbQuery = dbQuery.Where(filter).AsQueryable();
                }
                return dbQuery.Count();
            }
        }


        public virtual void Update(params T[] items)
        {
            using (var context = new DocAppContext())
            {

                DbSet<T> dbSet = context.Set<T>();
                foreach (T item in items)
                {
                    context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }

                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {

                }


            }
        }

        public virtual void Update<P>(Expression<Func<T, P>> excludeColumn, params T[] items)
        {

            using (var context = new DocAppContext())
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = EntityState.Modified;
                    context.Entry(item).Property(excludeColumn).IsModified = false;
                }
                context.SaveChanges();

            }

        }


        //---------- Remove interface


        public virtual void Remove(params T[] items)
        {
            using (var context = new DocAppContext())
            {

                DbSet<T> dbSet = context.Set<T>();
                foreach (T item in items)
                {
                    context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                }

                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {

                }


            }
        }
    }
}
