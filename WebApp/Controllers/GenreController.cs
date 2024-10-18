using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Utility;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace WebApp.Controllers
{
    public class GenreController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public GenreController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var genres= await _appDbContext.Genres.ToListAsync();
            return View(genres);
        }

        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _appDbContext.Genres.Add(genre);
            await _appDbContext.SaveChangesAsync();
            TempData["success"] = "new Genre created successfully.";
            return RedirectToAction("Index", "Genre");
        }


        public IActionResult Update(int? id){
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Genre? genre=_appDbContext.Genres.Find(id);
            return genre == null ? NotFound() : View(genre);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _appDbContext.Genres.Update(genre);
            await _appDbContext.SaveChangesAsync();
            TempData["success"] = "Genre updated successfully.";
            return RedirectToAction("Index", "Genre");
        }





        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Genre? genre = _appDbContext.Genres.Find(id);
            return genre == null ? NotFound() : View(genre);
        }



        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> Remove(int? id)
        {
            Genre deletegenre = _appDbContext.Genres.Find(id);
            if (deletegenre == null) return NotFound(); 
            _appDbContext.Genres.Remove(deletegenre);
            await _appDbContext.SaveChangesAsync();
            TempData["success"] = "Genre deleted successfully.";
            return RedirectToAction("Index", "Genre");
        }
    }
}
