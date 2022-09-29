using AutoMapper;
using ELearn.Courses.Service.Dtos;
using ELearn.Courses.Service.Model;
using ELearn.Courses.Service.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ELearn.Courses.Service.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _repo;
        private readonly IMapper _mapper;

        public CoursesController(ICourseRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: api/<CourseController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> Get()
        {
            var coursesFromDb = await _repo.GetAsync();
            var coursesToReturn = _mapper.Map<IEnumerable<CourseDto>>(coursesFromDb);
            return Ok(coursesToReturn);
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> Get(string id)
        {
            var courseFromDb = await _repo.GetAsync(new Guid(id));

            if(courseFromDb == null)
            {
                return NotFound();
            }

            var courseToReturn = _mapper.Map<CourseDto>(courseFromDb);
            return Ok(courseToReturn);
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CourseCreateDto request)
        {
            var course = _mapper.Map<Course>(request);
            course.CreatedDate = DateTimeOffset.Now;
            course.IsActive = true;

            await _repo.CreateAsync(course);

            return Ok();
        }

        // PUT api/<CourseController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            Guid courseId = new Guid(id);

            var courseFromDb = await _repo.GetAsync(courseId);

            if (courseFromDb == null)
            {
                return NotFound();
            }

            await _repo.DeleteAsync(courseId);
            return Ok();
        }
    }
}
