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
    public class AuthorsController : ControllerBase
    {
        private IAuthor _author;

        public AuthorsController(IAuthor author)
        {
            _author = author;
        }

        // GET: api/<CoursesController>
       
        [HttpGet]
        public async Task<IEnumerable<Author>> Get()
        {
            var results = await _author.GetAll();
            return results;
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public async Task<Author> Get(int id)
        {
            var result = await _author.GetById(id.ToString());
            return result;
        }

        // POST api/<CoursesController>
        [HttpPost]
        public async Task<ActionResult<Author>> Post([FromBody] Author author)
        {
            try
            {
                var result = await _author.Insert(author);
                return Ok(result);  
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Author>> Put(int id, [FromBody] Author author)
        {
            try
            {
                var result = await _author.Update(id.ToString(), author);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Author>> Delete(int id)
        {
            try
            {
                await _author.Delete(id.ToString());
                return Ok($"delete data id {id} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}