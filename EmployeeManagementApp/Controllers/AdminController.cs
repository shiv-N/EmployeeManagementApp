using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommaonLayer.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminBL adminBL;

        public AdminController(IAdminBL adminBL)
        {
            this.adminBL = adminBL;
        }

        [HttpPost]
        public IActionResult RegisterAdmin(RegisterModel admin)
        {
            try
            {
                if (this.adminBL.RegisterAdmin(admin))
                {
                    return this.Ok(new { success = true, Message = "Admin record added successfully" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new { success = false, Message = "Admin record is not added " });
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

        [HttpPost("Login")]
        public ActionResult AdminLogin(AdminLogin login)
        {

        }

        [HttpGet("Employees")]
        public IActionResult GetAllEmployee()
        {
            try
            {
                var result = this.adminBL.GetAllEmployee();
                if (result.Count != 0)
                {
                    return this.Ok(new { success = true, Message = "Get All Employee successfully",Data = result });
                }
                else
                {
                    return this.NotFound(new { success = false, Message = "Get All Employee unsuccessfully" });
                }
            }
            catch (Exception e)
            {
                
                return this.BadRequest(new { success = false, Message = e.Message });

            }
        }
    }
}
