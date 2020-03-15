﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Application.Models;
using Application.Helpers;

namespace Application.Controllers
{
    public class AdvertisementsController : Controller
    {
        AdvertisementProcessor _processor;

        public AdvertisementsController()
        {
            _processor = new AdvertisementProcessor();
        }

        // GET: Advertisements
        public async Task<IActionResult> Index(string titleFIlter)
        {
            var advertisements = await _processor.GetAdvertisements<List<Advertisement>>();

            if (!string.IsNullOrEmpty(titleFIlter))
            {
                advertisements = advertisements.Where(x => x.Title.Contains(titleFIlter)).ToList();
            }

            return View(advertisements);
        }

        // GET: Advertisements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisement = await _processor.GetAdvertisements<Advertisement>((int)id);
            if (advertisement == null)
            {
                return NotFound();
            }

            return View(advertisement);
        }

        // GET: Advertisements/Create
        public IActionResult Create()
        {
            return View();
        }

        //// POST: Advertisements/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Title,Description,Phone,Image")] Advertisement advertisement)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(advertisement);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(advertisement);
        //}

        //// GET: Advertisements/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var advertisement = await _context.Advertisement.FindAsync(id);
        //    if (advertisement == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(advertisement);
        //}

        //// POST: Advertisements/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Phone,Image")] Advertisement advertisement)
        //{
        //    if (id != advertisement.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(advertisement);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AdvertisementExists(advertisement.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(advertisement);
        //}

        //// GET: Advertisements/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var advertisement = await _context.Advertisement
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (advertisement == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(advertisement);
        //}

        //// POST: Advertisements/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var advertisement = await _context.Advertisement.FindAsync(id);
        //    _context.Advertisement.Remove(advertisement);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool AdvertisementExists(int id)
        //{
        //    return _context.Advertisement.Any(e => e.Id == id);
        //}
    }
}
