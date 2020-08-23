using CommaonLayer.ContextModel;
using CommaonLayer.RequestModel;
using RepositoryLayer.DBContextFiles;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmployeeRL : IEmployeeRL
    {
        private readonly EmployeeContext context;

        public EmployeeRL(EmployeeContext context)
        {
            this.context = context;
        }

        public bool RegisterEmployee(RegisterModel employee)
        {
            try
            {
                CompanyEmployee employeeObject = new CompanyEmployee()
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Password = employee.Password,
                    PhoneNumber = employee.PhoneNumber,
                    Role = "Employee",
                    CreatedDateTime = DateTime.UtcNow,
                    ModifiedDateTime = null
                };

                this.context.Employees.Add(employeeObject);
                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
