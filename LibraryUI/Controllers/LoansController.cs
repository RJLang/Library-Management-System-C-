using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library_Management_System_C_;
using Microsoft.AspNetCore.Authorization;
using System.Dynamic;

namespace LibraryUI.Controllers
{
    [Authorize]
    public class LoansController : Controller
    {
        // GET: Loans
        public IActionResult Index()
        {
            //Library.GetAllLoansbyUser(HttpContext.User.Identity.Name);

            //combing views from the loans/media to flush out the details
            //Pull the list of media to key up with the current loans
            ViewData["Media"] = Library.GetAllMedia();
            ViewData["Loans"] = Library.GetAllLoansbyUser(HttpContext.User.Identity.Name);

            return View();
        }

        public IActionResult CheckIn(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var accountID = Library.AccountConversionLookup(HttpContext.User.Identity.Name);

            Library.CheckIn(accountID, id.Value);

            return RedirectToAction(nameof(Index));
        }

        //// GET: Loans/Details/5
        //public IActionResult Details(uint? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    //combing views from the loans/media to flush out the details
        //    //dynamic myModel = new ExpandoObject();
        //    //myModel.Media = Library.GetMediaDetails(id.Value);
        //    //myModel.Loans = Library.GetLoanDetails((int) id.Value);
        //    ViewData["Media"] = Library.GetMediaDetails(id.Value);
        //    ViewData["Loans"] = Library.GetLoanDetails((int)id.Value);
        //    //var loans = Library.GetMediaDetails(id.Value);
        //    //if (myModel == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    return View();
        //}



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
