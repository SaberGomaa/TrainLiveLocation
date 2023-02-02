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
    [Route("api/Comment/[action]")]

    [ApiController]

    public class CommentController : ControllerBase
    {


        private readonly IRepositoryManegar _repository;
        private readonly IMapper _mapper;

        public CommentController(IRepositoryManegar repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet (Name = "GetComments")]
        public ActionResult GetAllComments()
        {
            try
            {
               
                var comments = _repository.Comment.GetAllComments();

                var commentDtos = _mapper.Map<IEnumerable<CommentDto>>(comments);

                if (commentDtos == null)
                {
                    return StatusCode(404, "Empty");
                }
                else
                {
                    return Ok(commentDtos);
                }
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost(Name ="createComment")]
        public ActionResult CreateComment(Comment comment) 
        {
            ArgumentNullException.ThrowIfNull(comment);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var commentEntity = _mapper.Map<Comment>(comment);
            _repository.Comment.CreateComment(commentEntity);

            _repository.Save();
            var ReturnedComment = _mapper.Map<CommentDto>(commentEntity);
            return CreatedAtRoute("GetAdmin", new { Id = ReturnedComment.Id }, ReturnedComment);

        }

        [HttpDelete("{Id:int}", Name = "DeleteComment")]
        public IActionResult DeleteComment(int Id)
        {
            var comment = _repository.Comment.GetCommentById(Id);
            ArgumentNullException.ThrowIfNull(comment);
            _repository.Comment.DeleteComment(comment);
            _repository.Save();
            return Ok($"Comment with id {Id} deleted");
        }

        [HttpPut("{Id:int}", Name = "Updatecomment")]
        public IActionResult Updatecomment([FromBody] CommentUpdateDto comment, int Id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest($"comment with id  {Id}  already has deleted");
                }
                else
                {
                    var SelectedComment = _repository.Comment.GetCommentById(Id);
                    ArgumentNullException.ThrowIfNull(SelectedComment);
                    var CommentEntity = _mapper.Map(comment, SelectedComment);
                    _repository.Comment.UpdateComment(CommentEntity);
                    _repository.Save();
                    return Ok($"the Comment with id {Id} has been updeted successfully");
                }
            }
            catch
            {
                return BadRequest("Error");
            }
        }


    }
}
