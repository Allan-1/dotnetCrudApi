using DotnetCRUD.Services;
using DotnetCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCRUD.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CommentController : Controller
{
    public CommentController(){}

    [HttpGet]
    public ActionResult<List<CommentModel>> GetAll() => CommentServices.GetAll();
    
    [HttpGet("{id}")]
    public ActionResult<CommentModel> Get(int id)
    {
        var comment = CommentServices.Get(id);

        if (comment == null)
        {
            return NotFound();
        }

        return comment;
    }

    [HttpPost]
    public IActionResult Create(CommentModel comments)
    {
        CommentServices.Add(comments);
        return CreatedAtAction(nameof(Get), new {id = comments.Id}, value: comments);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, CommentModel commentModel)
    {
        if (id != commentModel.Id)
        {
            return BadRequest();
        }

        var existingComments = CommentServices.Get(id);
        if (existingComments == null)
        {
            return NotFound();
        }
        
        CommentServices.Update(commentModel);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var comment = CommentServices.Get(id);
        if (comment is null)
        {
            return NotFound();
        }
        CommentServices.Delete(id);
        return NoContent();
    }
}


