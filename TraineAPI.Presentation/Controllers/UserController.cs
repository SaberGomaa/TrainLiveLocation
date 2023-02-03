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
    [Route("api/user/[action]")]

    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryManegar _repository;
        private readonly IMapper _mapper;

        public UserController(IRepositoryManegar repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        [HttpGet(Name = "GetUsers")]
        public IActionResult GetUsers()
        {               
            var Users = _repository.User.GetAllUser();
            var userDTO = _mapper.Map<IEnumerable<userDto>>(Users);
            return Ok(userDTO);
        }



        [HttpGet(Name = "GetUserById")]
        public IActionResult GetUserById(int Id)
        {
            var User = _repository.User.GetUserById(Id);
            if (User == null)
            {
                return NotFound($"there is no user with id{Id}");
            }
            else
            {
                var userDTO = _mapper.Map<userDto>(User);

                return Ok(userDTO);
            }
        }


        [HttpPost(Name = "CreateUser")]
        public IActionResult CreateUser([FromBody] UserCreationDto user)
        {
            ArgumentNullException.ThrowIfNull(user);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var UserEntity = _mapper.Map<User>(user);
            _repository.User.CreateUser(UserEntity);
            _repository.Save();
            var UserToReturn = _mapper.Map<userDto>(UserEntity);
            return CreatedAtRoute("GetUserById", new { id = UserToReturn.Id }, UserToReturn);


        }



        [HttpDelete(Name = "DeleteUser")]
        public IActionResult DeleteUser(int Id)
        {
            var user = _repository.User.GetUserById(Id);
            ArgumentNullException.ThrowIfNull(user);
            _repository.User.DeleteUser(user);
            _repository.Save();
            return Ok($"User with id {Id} already has been deleted");
        }

        [HttpPut( Name = "UpdateUser")]
        public IActionResult UpdateUser([FromBody] UserUpdateDto user, int userId)
        {
            var Selecteduser = _repository.User.GetUserById(userId);
            ArgumentNullException.ThrowIfNull(Selecteduser);
            var UseryEntity = _mapper.Map(user, Selecteduser);
            _repository.User.UpdateUser(UseryEntity);
            _repository.Save();
            return Ok($"the user with id {userId} has been updeted successfully");
        }

    }
}
