using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet(Name = "UserInTrain")]
        public ActionResult UserInTrain(int TrainId)
        {
            var users = _repository.Ticket.GetAllTikets().Where(x => x.TrainId == TrainId).Select(x => new { UserId = x.UserId , TrainId = x.TrainId , ArrivalStation = x.ArrivalStation , TakeOffStation = x.TakeOffStation });
            return Ok(users);
        }

    }
    
}
