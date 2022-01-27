using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        #region If I have very many lines

        //public async Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParam
        //    eters employeeParameters, bool trackChanges)
        //{
        //    var employees = await FindByCondition(e => e.CompanyId.Equals(companyId), trackCha
        //    nges)
        //        .OrderBy(e => e.Name)
        //        .Skip((employeeParameters.PageNumber - 1) * employeeParameters.PageSize)
        //        .Take(employeeParameters.PageSize)
        //        .ToListAsync();
        //    var count = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges
        //    ).CountAsync();
        //    return new PagedList<Employee>(employees, employeeParameters.PageNumber, employeeP
        //    arameters.PageSize, count);
        //}

        #endregion
        public async Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId,
            EmployeeParameters employeeParameters, bool trackChanges)
        {
            var employees =
                await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
                  .OrderBy(e => e.Name)
                  .ToListAsync();

            return PagedList<Employee>
                .ToPagedList(employees, employeeParameters.PageNumber, employeeParameters.PageSize);
        }


        public async Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges) =>
          await FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id),
                    trackChanges)
                .SingleOrDefaultAsync();

        public void CreateEmployeeForCompany(Guid companyId, Employee employee)
        {
            employee.CompanyId = companyId;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }
    }
}
