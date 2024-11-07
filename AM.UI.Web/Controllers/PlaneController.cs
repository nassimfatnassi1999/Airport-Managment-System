﻿using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AM.UI.Web.Controllers
{
    public class PlaneController : Controller
    {

        private readonly IServicePlane _planeService;
        public PlaneController(IServicePlane planeService)
        {
            _planeService = planeService;
        }
        // GET: PlaneController
        public ActionResult Index()
        {
            return View( _planeService.GetAll().ToList());
        }

        // GET: PlaneController/Details/5
        public ActionResult Details(int id)
        {
            return View(_planeService.GetById(id));
        }

        // GET: PlaneController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlaneController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Plane p )
        {
            try
            {
                    _planeService.Add(p);
                     _planeService.Commit();
                   return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlaneController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_planeService.GetById(id));
        }

        // POST: PlaneController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Plane p)
        {
            try
            {
                _planeService.Update(p);
                _planeService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlaneController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_planeService.GetById(id));
        }

        // POST: PlaneController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Plane p)
        {
            try
            {
                _planeService.Delete(_planeService.GetById(id));
                _planeService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
