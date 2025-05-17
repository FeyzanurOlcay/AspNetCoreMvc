using Microsoft.AspNetCore.Mvc;
using StudentApp2.Models;
using StudentApp2.Data;

namespace StudentApp2.Controllers
{
	
	public class StudentController : Controller
	{
		private readonly AppDbContext _context;
		public StudentController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var students =_context.Students.ToList();
			return View(students);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Student student)
		{
			if(!ModelState.IsValid)
			{
				return View(student);
			}
			_context.Students.Add(student);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Edit(int id)
		{
			var student=_context.Students.Find(id);
			return View(student);
		}
		[HttpPost]
		public IActionResult Edit(Student student)
		{
			_context.Students.Update(student);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Delete(int id)
		{
			var student=_context.Students.Find(id);
			_context.Students.Remove(student);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
