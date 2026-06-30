using Microsoft.AspNetCore.Mvc;
using GSULibrary.Models;

namespace GSULibrary.Controllers;

public class BookController : Controller
{
    private readonly GSUBookContext _context;

    public BookController(GSUBookContext context)
    {
        _context = context;
    }

    // Display all books
    public IActionResult Index()
    {
        var books = _context.Books.ToList();
        return View(books);
    }

    // GET: Add book
    [HttpGet]
    public IActionResult Add()
    {
        return View(new GSUBook());
    }

    // POST: Add book
    [HttpPost]
    public IActionResult Add(GSUBook book)
    {
        if (ModelState.IsValid)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        return View(book);
    }

    // GET: Edit book
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var book = _context.Books.Find(id);

        if (book == null)
            return NotFound();

        return View(book);
    }

    // POST: Edit book
    [HttpPost]
    public IActionResult Edit(GSUBook book)
    {
        if (ModelState.IsValid)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        return View(book);
    }

    // GET: Delete confirmation
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var book = _context.Books.Find(id);

        if (book == null)
            return NotFound();

        return View(book);
    }

    // POST: Delete confirmed
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var book = _context.Books.Find(id);

        if (book != null)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        return RedirectToAction(nameof(Index));
    }
}