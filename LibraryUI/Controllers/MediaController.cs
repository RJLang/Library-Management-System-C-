using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library_Management_System_C_;
using Microsoft.AspNetCore.Authorization;

namespace LibraryUI.Controllers
{
    [Authorize]
    public class MediaController : Controller
    {


        // GET: Media
        public IActionResult Index()
        {
            return View(Library.GetAllMedia());
        }

        // GET: Media/Details/5
        public IActionResult Details(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var media = Library.GetMediaDetails(id.Value);
            if (media == null)
            {
                return NotFound();
            }

            return View(media);
        }

        // GET: Media/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Media/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Title,TotalCopies,AvailableCopies,Type,Category,Author,OrginDate")] Media media)
        {
            if (ModelState.IsValid)
            {
                Library.AddInv(media.Title, media.TotalCopies, media.Type, media.Category, media.Author, media.OrginDate);
                return RedirectToAction(nameof(Index));
            }
            return View(media);
        }

        // GET: Media/Edit/5
        public IActionResult Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var media = Library.GetMediaDetails((uint)id.Value);
            if (media == null)
            {
                return NotFound();
            }
            return View(media);
        }

        // POST: Media/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(uint id, [Bind("ID,Title,TotalCopies,AvailableCopies,Type,Category,Author,OrginDate")] Media media)
        {
            if (id != media.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Library.EditMedia(media);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Library.MediaExists((uint)media.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(media);
        }

        // GET: Media/Delete/5
        public IActionResult Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var media = Library.GetMediaDetails(id.Value);
            if (media == null)
            {
                return NotFound();
            }

            return View(media);
        }

        // POST: Media/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(uint id)
        {
            Library.RemoveInv(id);
            return RedirectToAction(nameof(Index));
        }

        //public IActionResult CheckOut(uint? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var media = Library.GetMediaDetails(id.Value);
        //    var account = Library.AccountLookupName(HttpContext.User.Identity.Name);
        //    int accountID = account.Where(a => account.I)
        //    Library.CheckOut(account, media, 1);

        //    return RedirectToAction(nameof(Index));
        //}
    }
}
