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
        public IActionResult GetAllReports() 
        {
            try
            {
                var r = _repository.Report.GetAllReports();

                var reports = _mapper.Map<IEnumerable<ReportDto>>(r);

                if (reports is null)
                {
                    return StatusCode(404, "Empty");

                }
                else
                {
                    return Ok(reports);
                }
            }
            catch
            {
                return StatusCode(404, "Not Found");
            }
        }

        [HttpPost(Name = "CreateReport")]
        public IActionResult CreateReport(ReportCreationDto r)
        {
            var report = _mapper.Map<Report>(r);

            _repository.Report.CreateReport(report);
            _repository.Save();
            return Ok("Created");
        }


    }
}
