using CommaonLayer.RequestModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IEmployeeBL
    {
        bool RegisterEmployee(RegisterModel employee);
    }
}
