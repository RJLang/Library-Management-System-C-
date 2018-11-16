using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library_Management_System_C_;

namespace LibraryUI.Controllers
{
    public class LoansController : Controller
    {
        // GET: Loans
        public IActionResult Index()
        {
            return View(Library.GetAllLoansbyUser(HttpContext.User.Identity.Name));
        }

        // GET: Loans/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loans = Library.GetAccountDetails(id.Value);
            if (loans == null)
            {
                return NotFound();
            }

            return View(loans);
        }

  

        //// GET: Loans/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var loans = await _context.Loans
        //        .FirstOrDefaultAsync(m => m.TransactinID == id);
        //    if (loans == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(loans);
        //}

        //// POST: Loans/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var loans = await _context.Loans.FindAsync(id);
        //    _context.Loans.Remove(loans);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool LoansExists(int id)
        //{
        //    return _context.Loans.Any(e => e.TransactinID == id);
        //}
    }
}
