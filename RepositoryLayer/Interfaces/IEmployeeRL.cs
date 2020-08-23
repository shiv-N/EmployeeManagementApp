using CommaonLayer.RequestModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IEmployeeRL
    {
        bool RegisterEmployee(RegisterModel employee);
    }
}
