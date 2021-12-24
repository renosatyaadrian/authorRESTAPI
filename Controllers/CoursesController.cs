using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using authorRESTAPI.Data;
using authorRESTAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace authorRESTAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private ICourse _course;
        public CoursesController(ICourse course)
        {
            _course = course;
        }

        // GET: api/<CoursesController>
       
        [HttpGet]
        public async Task<IEnumerable<Course>> Get()
        {
            var results = await _course.GetAll();
            return results;
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public async Task<Course> Get(int id)
        {
            var result = await _course.GetById(id.ToString());
            return result;
        }

        // POST api/<CoursesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Course course)
        {
            try
            {
                var result = await _course.Insert(course);
                return Ok(result);  
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Course course)
        {
            try
            {
                var result = await _course.Update(id.ToString(), course);
                return Ok(result);
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
    }
}