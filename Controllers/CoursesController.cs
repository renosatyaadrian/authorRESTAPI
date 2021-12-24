using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using authorRESTAPI.Data;
using authorRESTAPI.Dtos;
using authorRESTAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace authorRESTAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private ICourse _course;
        private IMapper _mapper;

        public CoursesController(ICourse course, IMapper mapper)
        {
            _course = course ?? throw new ArgumentNullException(nameof(course));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/<CoursesController>
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> Get()
        {
            var courses = await _course.GetAll();

            var dtos = _mapper.Map<IEnumerable<CourseDto>>(courses);
            return Ok(dtos);
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> Get(int id)
        {
            var course = await _course.GetById(id.ToString());
            if(course==null)
                return NotFound();
            var dtos = _mapper.Map<CourseDto>(course);

            return Ok(dtos);
        }

        // POST api/<CoursesController>
        [HttpPost]
        public async Task<ActionResult<CourseDto>> Post([FromBody] CourseForUpdateDto course)
        {
            try
            {
                var dto = _mapper.Map<Course>(course);
                var result = await _course.Insert(dto);
                return Ok(_mapper.Map<CourseDto>(result));  
          }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CourseDto>> Put(int id, [FromBody] CourseForUpdateDto course)
        {
            try
            {
                var dto = _mapper.Map<Course>(course);
                var result = await _course.Update(id.ToString(), dto);
                var resultDto = _mapper.Map<CourseDto>(result);
                return Ok(resultDto); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _course.Delete(id.ToString());
                return Ok($"delete data id {id} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("byAuthorId")]
        public async Task<ActionResult<IEnumerable<Course>>> GetByAuthorId(int id)
        {
            var courses = await _course.GetAllCourseByAuthor(id);
            var dtos = _mapper.Map<IEnumerable<CourseDto>>(courses);
            return Ok(dtos);
        }
    }
}