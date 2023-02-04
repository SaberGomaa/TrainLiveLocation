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
    [Route("api/Post/[action]")]

    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IRepositoryManegar _repository;
        private readonly IMapper _mapper;

        public PostController(IRepositoryManegar repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetPosts")]
        public ActionResult GetAllPosts()
        {
            try
            {

                var posts = _repository.Post.GetAllPosts();

                var postDtos = _mapper.Map<IEnumerable<PostDto>>(posts);

                if (postDtos == null)
                {
                    return StatusCode(404, "Empty");
                }
                else
                {
                    return Ok(postDtos);
                }
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id:int}", Name = "GetPost")]
        public ActionResult GetPost(int id)
        {
            try
            {

                var post = _repository.Post.GetPostById(id);

                var postDtos = _mapper.Map<PostDto>(post);

                if (postDtos == null)
                {
                    return StatusCode(404, "Empty");
                }
                else
                {
                    return Ok(postDtos);
                }
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost(Name = "createPost")]
        public ActionResult CreatePost(PostDto post)
        {
            ArgumentNullException.ThrowIfNull(post);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var postEntity = _mapper.Map<Post>(post);
            _repository.Post.CreatePost(postEntity);

            _repository.Save();
            var ReturnedPost= _mapper.Map<PostDto>(post);
            return CreatedAtRoute("GetPost", new { Id = ReturnedPost.id }, ReturnedPost);

        }

        [HttpDelete("{Id:int}", Name = "DeletePost")]
        public IActionResult DeletePost(int Id)
        {
            var post = _repository.Post.GetPostById(Id);
            ArgumentNullException.ThrowIfNull(post);
            _repository.Post.DeletePost(post);
            _repository.Save();
            return Ok($"Post with id {Id} deleted");
        }


        [HttpPut("{Id:int}", Name = "UpdatePost")]
        public IActionResult UpdatePost([FromBody] PostUpdateDto post, int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest($"Post with id  {Id}  already has deleted");
            }
            else
            {
                var SelectedPost = _repository.Post.GetPostById(Id);
                ArgumentNullException.ThrowIfNull(SelectedPost);
                var postEntity = _mapper.Map(post, SelectedPost);
                _repository.Post.UpdatePost(postEntity);
                _repository.Save();
                return Ok($"the Post with id {Id} has been updeted successfully");
            }
        }

    }
}
