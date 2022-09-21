using AutoMapper;
using CleanArchitecture.DataAccess.Entities;
using CleanArchitecture.DataAccess.Interfaces;
using CleanArchitecture.MVC.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CleanArchitecture.MVC.Controllers.Api
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PostsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IHttpActionResult GetPosts()
        {
            return Ok(_unitOfWork.Posts
                .GetAll()
                .Select(Mapper.Map<Post, PostDto>));
        }

        [HttpGet]
        public IHttpActionResult GetPost(int id)
        {
            var post = _unitOfWork.Posts.GetById(id);
            if (post == null)
                return NotFound();
            return Ok(Mapper.Map<Post, PostDto>(post));
        }

        [HttpPost]
        public IHttpActionResult CreatePost(PostDto postDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var post = Mapper.Map<PostDto, Post>(postDto);
            _unitOfWork.Posts.Create(post);
            _unitOfWork.Complete();
            postDto.ID = post.ID;
            return Created(new Uri(Request.RequestUri + "/" + post.ID), postDto);
        }

        [HttpPut]
        public IHttpActionResult UpdatePost(int id, PostDto postDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var postInDb = _unitOfWork.Posts.GetById(id);
            if (postInDb == null)
                return NotFound();

            Mapper.Map(postDto, postInDb);
            _unitOfWork.Posts.Update(postInDb);
            _unitOfWork.Complete();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeletePost(int id)
        {
            var postInDb = _unitOfWork.Posts.GetById(id);
            if (postInDb == null)
                return NotFound();
            _unitOfWork.Posts.Delete(id);
            _unitOfWork.Complete();

            return Ok(postInDb);
        }
    }
}
