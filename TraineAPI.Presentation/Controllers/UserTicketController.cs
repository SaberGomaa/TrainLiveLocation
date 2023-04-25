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
using System.Xml.Linq;

namespace TraineAPI.Presentation.Controllers
{
    [Route("api/user/[action]")]

    [ApiController]
    public class UserTicketController : ControllerBase
    {

        private readonly IRepositoryManegar _repository;
        private readonly IMapper _mapper;

        public UserTicketController(IRepositoryManegar repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "DoctorsInTrain")]
        public IActionResult DoctorsInTrain(int TrainId)
        {
            var usersInTrain = _repository.Ticket.GetAllTikets().Where(x => x.TrainId.Equals(TrainId) && x.UserJop=="Doctor").Select(x=> new {TicketId = x.Id ,userId = x.UserId , UserName = x.UserName , UserEmail = x.UserEmail , UserPhone = x.UserPhone ,TakeOffStation = x.TakeOffStation ,ArrivalStation= x.ArrivalStation    });

            return Ok(usersInTrain);
        }

    }
    
}
