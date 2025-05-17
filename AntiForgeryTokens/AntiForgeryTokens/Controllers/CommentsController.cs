using AntiForgeryTokens.Models;
using Microsoft.AspNetCore.Mvc;

namespace AntiForgeryTokens.Controllers
{
	public class CommentsController : Controller
	{
		private static List<Comment> comments = new();

		public IActionResult Index()
		{
			return View(comments);
		}
		public IActionResult Create()
		{
			return View();
		}

		// POST: /Comments/Create
		[HttpPost]
		[ValidateAntiForgeryToken] // Bu satır CSRF koruması sağlar
		public IActionResult Create(Comment comment)
		{
			if (!ModelState.IsValid)
				return View(comment);
			comment.Id = comments.Count + 1;
			comments.Add(comment);
			return RedirectToAction("Index");
		}
	}
}
