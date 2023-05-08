using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineAPI.Presentation.Controllers
{
    [Route("api/user/[action]")]

    [ApiController]
    public class UserStationController : ControllerBase
    {

        private readonly IRepositoryManegar _repository;
        private readonly IMapper _mapper;

        public UserStationController(IRepositoryManegar repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //[HttpGet(Name ="UserInStation")]
        //public ActionResult UserInStation (int StationId) 
        //{
        //    var users = _repository.User.GetAllUser().Where(x=>x.StationId == StationId).Select(x=> new { Id = x.Id, Phone = x.Phone, Name = x.Name } );
        //    return Ok(users);
        //}
      

    }
}
