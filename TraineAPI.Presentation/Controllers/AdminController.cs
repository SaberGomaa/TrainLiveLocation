using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Shared.DTOs;

namespace TraineAPI.Presentation.Controllers
{
    [Route("api/Admin/[action]")]
   
    [ApiController]
    //(ControllerBase)which provides all necessary behavior for the derived class
    public class AdminController : ControllerBase
    {
        private readonly IRepositoryManegar _repository;
        public AdminController (IRepositoryManegar repository)
        {
            _repository = repository;
        }

        [HttpGet (Name = "Admins")]
        public IActionResult GetAdmins()
        {
            try
            {
                var Admins = _repository.Admin.GetAllAdmins();

                var AdminsDto = Admins.Select(
                    c => new AdminDto(c.Id, c.Name, c.Password, c.Phone, c.Email , c.AdminDegree  ))
                    .ToList();

                if(AdminsDto == null)
                {
                    return StatusCode(404, "Empty");

                }
                else
                {
                    return Ok(AdminsDto);
                }
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }


    }
}
