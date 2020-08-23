﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommaonLayer.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBL employeeBL;

        public EmployeeController(IEmployeeBL employeeBL)
        {
            this.employeeBL = employeeBL;
        }

        [HttpPost]
        public IActionResult RegisterEmployee(RegisterModel employee)
        {
            try
            {
                if (this.employeeBL.RegisterEmployee(employee))
                {
                    return this.Ok(new { success = true, Message = "Employee record added successfully" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new { success = false, Message = "Employee record is not added " });
                }
            }
            catch (Exception e)
            {
                var sqlException = e.InnerException as SqlException;

                if (sqlException.Number == 2601 || sqlException.Number == 2627)
                {
                    return StatusCode(StatusCodes.Status409Conflict,
                        new { success = false, ErrorMessage = "Cannot insert duplicate Email values." });
                }
                else
                {
                    return this.BadRequest(new { success = false, Message = e.Message });
                }

            }
        }
    }
}