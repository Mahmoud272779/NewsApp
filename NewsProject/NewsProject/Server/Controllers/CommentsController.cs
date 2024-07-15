using Microsoft.AspNetCore.Mvc;
using NewsProject.Server.Repositories.Intefaces;
using NewsProject.Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsProject.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly MainInteface<Comment> _comment;

        public CommentsController(MainInteface<Comment> comment)
        {
            _comment = comment;
        }

        // GET: api/<CommentsController>
        [HttpGet]
        public IActionResult GetAllComments()
        {
            return Ok(_comment.GetAllDate("newsList"));
        }

        // GET api/<CommentsController>/5
        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id)
        {
            return Ok(_comment.GetAllDate("newsList").Where(c=> c.Id == id));
        }

        // POST api/<CommentsController>
        [HttpPost]
        public IActionResult AddComment([FromBody] Comment model)
        {
            _comment.AddRow(model);
            return Ok(model);
        }

        // PUT api/<CommentsController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateComment([FromBody] Comment model)
        {
            _comment.UpdateRow(model);
            return Ok(model);
        }

        // DELETE api/<CommentsController>/5
        [HttpDelete("{id}")]
        public void Deletecomment(int id)
        {
            _comment.DeleteRow(id);
        }
    }
}
