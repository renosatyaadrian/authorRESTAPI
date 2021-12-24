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
    public class AuthorsController : ControllerBase
    {
        private IAuthor _author;
        private IMapper _mapper;

        public AuthorsController(IAuthor author, IMapper mapper)
        {
            _author = author ?? throw new ArgumentNullException(nameof(author));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/<CoursesController>
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> Get()
        {
            var results = await _author.GetAll();
            var dtos = _mapper.Map<IEnumerable<AuthorDto>>(results);
            return Ok(dtos);
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> Get(int id)
        {
            var result = await _author.GetById(id.ToString());
            if(result ==null)
            {
                return NotFound();
            }
            var dto = _mapper.Map<AuthorDto>(result);
            return Ok(dto);
        }

        // POST api/<CoursesController>
        [HttpPost]
        public async Task<ActionResult<AuthorDto>> Post([FromBody] AuthorForUpdateDto author)
        {
            try
            {
                var dto = _mapper.Map<Author>(author);
                var result = await _author.Insert(dto);
                return Ok(_mapper.Map<AuthorDto>(result));    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorDto>> Put(int id, [FromBody] AuthorForUpdateDto author)
        {
            try
            {
                var dto = _mapper.Map<Author>(author);
                var result = await _author.Update(id.ToString(), dto);
                var resultDto = _mapper.Map<AuthorDto>(result);
                return Ok(resultDto);  
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthorDto>> Delete(int id)
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