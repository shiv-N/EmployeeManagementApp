using BusinessLayer.Interfaces;
using CommaonLayer.RequestModel;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class EmployeeBL:IEmployeeBL
    {
        private IEmployeeRL employeeRL;

        public EmployeeBL(IEmployeeRL employeeRL)
        {
            this.employeeRL = employeeRL;
        }

        public bool RegisterEmployee(RegisterModel employee)
        {
            try
            {
                return this.employeeRL.RegisterEmployee(employee);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
