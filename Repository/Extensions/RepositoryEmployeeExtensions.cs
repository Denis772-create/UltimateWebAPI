using System;
using System.Linq;
using System.Reflection;
using System.Text;
using Entities.Models;
using System.Linq.Dynamic.Core;
using Repository.Extensions.Utility;

namespace Repository.Extensions
{
    public static class RepositoryEmployeeExtensions
    {
        public static IQueryable<Employee> FilterEmployees(this IQueryable<Employee> employees,
            uint minAge, uint maxAge) =>
            employees.Where(e => e.Age >= minAge && e.Age <= maxAge);

        public static IQueryable<Employee> Search(this IQueryable<Employee> employees,
            string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return employees;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return employees.Where(e => e.Name.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<T> Sort<T>(this IQueryable<T> employees,
            string orderByQueryString) where T : class
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return employees.OrderBy("name");

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<T>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return employees.OrderBy("name");

            return employees.OrderBy(orderQuery);
        }
    }
}
