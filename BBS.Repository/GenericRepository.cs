using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace BBS.Repository
{
    public class GenericRepository<TDBContext>
        where TDBContext : DbContext, new()
    {
        public GenericRepository()
        {
        }

        #region private methods
        private string FullyQualifiedEntityName<TEntity>(TDBContext currentDBContext, TEntity currentItem)
        where TEntity : class, new()
        {
            ObjectContext currentContext = ((IObjectContextAdapter)currentDBContext).ObjectContext;
            ObjectSet<TEntity> currentObjectset = currentContext.CreateObjectSet<TEntity>();
            return currentObjectset.EntitySet.Name;
        }
        #endregion

        #region Insert Update Delete
        /// <summary>
        /// Edward Norris
        /// Inserts an Entity into a datastore
        /// </summary>
        /// <typeparam name="TEntity">The Entity type you are working with</typeparam>
        /// <param name="currentItem">The actual entity item</param>
        /// <returns>An object of type TEntity</returns>
        public TEntity Insert<TEntity>(TEntity currentItem)
        where TEntity : class, new()
        {
            using (DbContext thisDBcontext = new TDBContext())
            {
                thisDBcontext.Configuration.ProxyCreationEnabled = false;
                DbSet<TEntity> dbSet = thisDBcontext.Set<TEntity>();
                dbSet.Add(currentItem);
                thisDBcontext.SaveChanges();
                return currentItem;
            }
        }


        /// <summary>
        /// Edward Norris 
        /// Updates an Entity and saves it back into a datastore
        /// </summary>
        /// <typeparam name="TEntity">The Entity type you are working with</typeparam>
        /// <param name="currentItem">The actual entity item</param>
        /// <returns>An object of type TEntity. If Identity columns are used they are populated and returned.</returns>
        public TEntity Update<TEntity>(TEntity currentItem)
        where TEntity : class, new()
        {
            using (DbContext thisDBcontext = new TDBContext())
            {
                thisDBcontext.Configuration.ProxyCreationEnabled = false;
                DbSet<TEntity> dbSet = thisDBcontext.Set<TEntity>();
                dbSet.Attach(currentItem);
                thisDBcontext.Entry(currentItem).State = EntityState.Modified;
                thisDBcontext.SaveChanges();
                return currentItem;
            }
        }

        /// <summary>
        /// Edward Norris
        /// Deletes the Entity from the datastore
        /// </summary>
        /// <typeparam name="TEntity">The Entity type you are working with</typeparam>
        /// <param name="currentItem">The actual entity item</param>
        public void Delete<TEntity>(TEntity currentItem)
        where TEntity : class, new()  //IObjectWithChangeTracker,
        {
            using (DbContext thisDBcontext = new TDBContext())
            {
                thisDBcontext.Configuration.ProxyCreationEnabled = false;
                DbSet<TEntity> dbSet = thisDBcontext.Set<TEntity>();
                dbSet.Attach(currentItem);
                dbSet.Remove(currentItem);
                thisDBcontext.SaveChanges();
            }
        }

        public void DeleteListOfItems<TEntity>(List<TEntity> currentItems)
            where TEntity : class, new()  //IObjectWithChangeTracker,
        {
            using (DbContext thisDBcontext = new TDBContext())
            {
                thisDBcontext.Configuration.ProxyCreationEnabled = false;
                DbSet<TEntity> dbSet = thisDBcontext.Set<TEntity>();
                foreach (TEntity currentItem in currentItems)
                {
                    dbSet.Attach(currentItem);
                    dbSet.Remove(currentItem);
                    thisDBcontext.SaveChanges();
                }
            }
        }


        ///<summary>
        /// Edward Norris
        /// Checks to see if an entity exists in the data store
        /// </summary>
        /// <typeparam name="TEntity">The Entity Type</typeparam>
        /// <param name="currentItem">The Entity item you are checking</param>
        /// <returns>True if the item exists, false if it does not exist</returns>
        public bool DoesExist<TEntity>(TEntity currentItem)
        where TEntity : class, new()
        {
            using (DbContext thisDBcontext = new TDBContext())
            {
                return thisDBcontext.DoesExists<TEntity>(currentItem);
            }
        }

        #endregion

        #region Select methods
        /// <summary>
        /// Edward Norris 
        /// Returns all records of a specific type from the context
        /// </summary>
        /// <typeparam name="TEntity">The Entity type you are requesting</typeparam>
        /// <returns>Returns a List Of TEntity from the query results</returns>
        public List<TEntity> Select<TEntity>()
        where TEntity : class, new()
        {
            using (DbContext thisDBcontext = new TDBContext())
            {
                thisDBcontext.Configuration.ProxyCreationEnabled = false;
                var queryResults = (from recs in thisDBcontext.Set<TEntity>() select recs).ToList();
                return queryResults;
            }
        }

        /// <summary>
        /// Edward Norris 
        /// Returns all records of a specific type from the context
        /// </summary>
        /// <typeparam name="TEntity">The Entity type you are requesting</typeparam>
        /// <param name="numberToSelect">The number of records to select</param>
        /// <returns>Returns a List Of TEntity from the query results</returns>
        public List<TEntity> Select<TEntity>(int numberToSelect)
        where TEntity : class, new()
        {
            using (DbContext thisDBcontext = new TDBContext())
            {
                thisDBcontext.Configuration.ProxyCreationEnabled = false;
                var queryResults = (from recs in thisDBcontext.Set<TEntity>() select recs).Take(numberToSelect).ToList();
                return queryResults;
            }
        }

        /// <summary>
        /// Edward Norris 
        /// Returns all records of a specific type from the context
        /// </summary>
        /// <typeparam name="TEntity">The Entity type you are requesting</typeparam>
        /// <param name="whereStatement">A Lamda Expression for the .Include() LINQ parameter</param>
        /// <returns>Returns a List of TEntity from the query results</returns>
        public List<TEntity> Select<TEntity>(Expression<Func<TEntity, bool>> whereStatement)
        where TEntity : class, new()
        {
            List<Expression<Func<TEntity, bool>>> whereStatements = new List<Expression<Func<TEntity, bool>>>();
            whereStatements.Add(whereStatement);
            return Select<TEntity>(whereStatements);
        }

        /// <summary>
        /// Edward Norris 
        /// Returns all records of a specific type from the context
        /// </summary>
        /// <typeparam name="TEntity">The Entity type you are requesting</typeparam>
        /// <param name="numberToSelect">The Number of records to select from the results</param>
        /// <param name="whereStatement">A Lamda Expression for the .Include() LINQ parameter</param>
        /// <returns>Returns a List of TEntity from the query results</returns>
        public List<TEntity> Select<TEntity>(int numberToSelect, Expression<Func<TEntity, bool>> whereStatement)
        where TEntity : class, new()
        {
            List<Expression<Func<TEntity, bool>>> whereStatements = new List<Expression<Func<TEntity, bool>>>();
            whereStatements.Add(whereStatement);
            return Select<TEntity>(whereStatements).Take(numberToSelect).ToList();
        }


        /// <summary>
        /// Edward Norris 
        /// Receives a list of typed lambda expressions and applies them to the LINQ Query using a custom extension
        /// </summary>
        /// <typeparam name="TEntity">The Entity type you are working with</typeparam>
        /// <param name="whereStatement">List( Expression (Func (TEntity, bool)))</param>
        /// <returns>A Typed List of the results</returns>
        public List<TEntity> Select<TEntity>(IList<Expression<Func<TEntity, bool>>> whereStatement)
        where TEntity : class, new()
        {
            using (DbContext thisDBcontext = new TDBContext())
            {
                thisDBcontext.Configuration.ProxyCreationEnabled = false;
                var queryResults = (
                    from recs in thisDBcontext.Set<TEntity>()
                    .MultipleWhere(whereStatement)
                    select recs).ToList();
                return queryResults;
            }
        }

        #endregion

        #region GetWithAssociation methods
        /// <summary>
        /// Edward Norris 
        /// Returns all records from the Entity, with the included values
        /// </summary>
        /// <typeparam name="TEntity">The Entity Type</typeparam>
        /// <param name="IncludeAssociations">A non-anonymous string array associations</param>
        /// <returns>A Typed List of all records with the includes applied</returns>
        public List<TEntity> SelectWithAssociations<TEntity>(IList<string> IncludeAssociations)
        where TEntity : class, new()
        {
            using (DbContext thisDBcontext = new TDBContext())
            {
                thisDBcontext.Configuration.ProxyCreationEnabled = false;
                var queryResults = (
                    from recs in thisDBcontext.Set<TEntity>()
                    .WithIncludes<TEntity>(IncludeAssociations)
                    select recs).ToList();
                return queryResults;
            }
        }

        ///<summary>
        /// Edward Norris 
        /// Returns all records from the Entity, with the included values and an applied lamda
        /// </summary>
        /// <typeparam name="TEntity">The Entity Type you are working with</typeparam>
        /// <param name="IncludeAssociations">A List of Strings to define the associations to include</param>
        /// <param name="whereStatement">A Lamda Expression for the .Include()LINQ parameter</param>
        /// <returns>A Typed list with the includes and lambda expression applied</returns>
        public List<TEntity> SelectWithAssociations<TEntity>(IList<string> IncludeAssociations, Expression<Func<TEntity, bool>> whereStatement)
        where TEntity : class, new()
        {
            List<Expression<Func<TEntity, bool>>> whereStatements = new List<Expression<Func<TEntity, bool>>>();
            whereStatements.Add(whereStatement);
            return SelectWithAssociations<TEntity>(IncludeAssociations, whereStatements);
        }

        /// <summary>
        /// Edward Norris 
        /// Receives a list of typed lambda expressions and applies them to the LINQ Query using a custom extension
        /// </summary>
        /// <typeparam name="TEntity">The Entity type you are working with</typeparam>
        /// <param name="IncludeAssociations">A List of Strings to define the associations to include</param>
        /// <param name="whereStatement">List( Expression(Func(TEntity, bool)))</param>
        /// <returns>A Typed List of the query results</returns>
        public List<TEntity> SelectWithAssociations<TEntity>(IList<string> IncludeAssociations, IList<Expression<Func<TEntity, bool>>> whereStatement)
        where TEntity : class, new()
        {
            using (DbContext thisDBcontext = new TDBContext())
            {
                thisDBcontext.Configuration.ProxyCreationEnabled = false;
                var queryResults = (
                    from recs in thisDBcontext.Set<TEntity>()
                    .WithIncludes<TEntity>(IncludeAssociations)
                    .MultipleWhere(whereStatement)
                    select recs).ToList();
                return queryResults;
            }
        }
        #endregion

    }
}
