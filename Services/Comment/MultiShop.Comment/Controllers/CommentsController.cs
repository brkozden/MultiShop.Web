using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
      private readonly CommentContext _commentContext;

        public CommentsController(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        [HttpGet]
        public  IActionResult CommentList()
        {
            var values =  _commentContext.UserComments.ToList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value =  _commentContext.UserComments.Find(id);
            return Ok(value);
        }
        [HttpPost]
        public  IActionResult CreateComment(UserComment userComment)
        {
             _commentContext.UserComments.Add(userComment);
            _commentContext.SaveChanges();

            return Ok("Yeni Yorum Eklendi.");
        }
        [HttpDelete("{id}")]
        public  IActionResult DeleteComment(string id)
        {
            var value =  _commentContext.UserComments.Find(id);
            _commentContext.UserComments.Remove(value);
            _commentContext.SaveChanges();

            return Ok("Yorum Silindi.");
        }
        [HttpPut]
        public  IActionResult UpdateComment(UserComment userComment)
        {
             _commentContext.UserComments.Update(userComment);
            _commentContext.SaveChanges();
            return Ok("Yorum Güncellendi.");
        }
        [HttpGet("CommentListByProductId/{id}")]
        public IActionResult CommentListByProductId(string id)
        {
            var value = _commentContext.UserComments.Where(x=>x.ProductId==id);
            return Ok(value);
        }
    }
}
