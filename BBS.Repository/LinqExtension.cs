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
    public static class LINQExtension
    {
        /// <summary>
        /// Edward Norris 
        /// Extension Method for LINQ to allow for multiple associations
        /// </summary>
        /// <typeparam name="T">The Entity Type returned from the query</typeparam>
        /// <param name="source">extension parameter, ignore it</param>
        /// <param name="associations">a non-anonymous string array of associations from the model to include</param>
        /// <returns></returns>
        public static IQueryable<T> WithIncludes<T>(this IQueryable<T> source, IList<string> associations)
            where T:class
        {
            var query = source;
            foreach (var assoc in associations)
            {
                query = query.Include(assoc);
            }
            return query;
        }

        /// <summary>
        /// Edward Norris 
        /// Extension Method to attach multiple where statements to the LINQ query via an IList
        /// </summary>
        /// <typeparam name="T">The Entity Type returned from the query</typeparam>
        /// <param name="source">extension parameter, ignore it</param>
        /// <param name="whereStatements"></param>
        /// <returns></returns>
        public static IQueryable<T> MultipleWhere<T>(this IQueryable<T> source, IList<Expression<Func<T, bool>>> wherestatements)
        {
            var query = (IQueryable<T>)source;
            foreach (var whereStatement in wherestatements)
            {
                query = query.Where(whereStatement);
            }
            return query;
        }

        /// <param name="sourceltem">The actual entity item you are checking to see if it exists</param>
        /// <returns>Returns True if the entity exists, returns false if it does not exist.</returns>
        public static bool DoesExists<T>(this DbContext thisDBcontext, T sourceItem)
        where T : class,new()
        {
            ObjectContext currentContext = ((IObjectContextAdapter)thisDBcontext).ObjectContext;
            object objectValue;
            var entityKeyValues = new List<KeyValuePair<string, object>>();
            var objectset = currentContext.CreateObjectSet<T>().EntitySet;
            foreach (var member in objectset.ElementType.KeyMembers)
            {
                var propertylnfo = sourceItem.GetType().GetProperty(member.Name);
                var keyPair = new KeyValuePair<string, object>(member.Name,
                propertylnfo.GetValue(sourceItem, null));
                entityKeyValues.Add(keyPair);
            }
            var currentEntityKey = new EntityKey(objectset.EntityContainer.Name + "." + objectset.Name, entityKeyValues);
            if (currentContext.TryGetObjectByKey(currentEntityKey, out objectValue))
            {
                return objectValue != null;
            }
            return false;
        }
    }
}
