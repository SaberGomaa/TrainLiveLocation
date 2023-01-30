using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace TraineAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //(ControllerBase)which provides all necessary behavior for the derived class
    public class AdminController : ControllerBase
    {
        private readonly IRepositoryManegar _repository;
        public AdminController (IRepositoryManegar repository)
        {
            _repository = repository;
        }

    }
}
