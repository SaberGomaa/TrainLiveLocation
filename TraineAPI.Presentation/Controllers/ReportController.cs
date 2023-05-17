using AutoMapper;
using Contracts;
using Entites;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineAPI.Presentation.Controllers
{
    [Route("api/Report/[action]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IRepositoryManegar _repository;
        private readonly IMapper _mapper;

        public ReportController(IRepositoryManegar repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet(Name ="GetAllReports")]
        public ActionResult GetAllReports() 
        {
            try
            {
                var reports = _repository.Report.GetAllReports().ToList();

                return Ok(reports);
            }
            catch
            {
                return StatusCode(404 , "Not Found");
            }
        }

       


    }
}
