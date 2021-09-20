﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bilinguals.Data;
using Bilinguals.Domain.Interfaces;
using Bilinguals.Domain.Models;

namespace Bilinguals.Controllers
{
    public class DialogsController : Controller
    {
        private readonly IDialogService _dialogService;

        public DialogsController(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        // GET: Dialogs
        public ActionResult Index(int? pageIndex, string searchText, string sortOrder)
        {
            int pageSize = 8;

            var dialogs = _dialogService.GetDialogList(pageIndex ?? 1, pageSize, searchText, sortOrder);

            return View(dialogs);
        }

        // GET: Dialogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dialog dialog = _dialogService.GetById(id.Value);
            if (dialog == null)
            {
                return HttpNotFound();
            }
            return View(dialog);
        }

        // GET: Dialogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dialogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dialog dialog)
        {
            if (ModelState.IsValid)
            {
                _dialogService.Add(dialog);
                return RedirectToAction("Index");
            }

            return View(dialog);
        }

        // GET: Dialogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dialog dialog = _dialogService.GetById(id.Value);
            if (dialog == null)
            {
                return HttpNotFound();
            }
            return View(dialog);
        }

        // POST: Dialogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Dialog dialog, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                _dialogService.Edit(dialog);
                

                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);

                return RedirectToAction("Index");
            }
            return View(dialog);
        }

        // GET: Dialogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dialog dialog = _dialogService.GetById(id.Value);
            if (dialog == null)
            {
                return HttpNotFound();
            }
            return View(dialog);
        }

        // POST: Dialogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _dialogService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}