using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mahasiswa_New.Services;
using Mahasiswa_New.Models;


namespace Mahasiswa_New.Controllers
{
    public class MahasiswaController : Controller
    {
        MahasiswaService Mahasiswa;

        // Github
        // GET: Mahasiswa
        public ActionResult Index()
        {
            Mahasiswa = new MahasiswaService();
            var result = Mahasiswa.GetListMahasiswa();
            return View(result);
        }

        // GET: Mahasiswa/Details/5
        public ActionResult Details(int id)
        {
            
            return View();
        }

        // GET: Mahasiswa/Create
        public ActionResult Create()
        {
            Mahasiswa = new MahasiswaService();
            ViewData["jurusan"] = Mahasiswa.GetJurusan();
            return View();
        }

        // POST: Mahasiswa/Create
        [HttpPost]
        public ActionResult Create(MahasiswaModel model)
        {
            try
            {
                Mahasiswa = new MahasiswaService();
                bool IsDataExist = Mahasiswa.IsDataExist(model.NPM);
                if (IsDataExist)
                {
                    return Json(new { success = false, message = "Data already exist" }, JsonRequestBehavior.AllowGet);
                }
                Mahasiswa.SimpanMahasiswa(model);
                return Json(new { success = true, message = "Data Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { success = false, message = "Save data failed" }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Mahasiswa/Edit/5
        public ActionResult Edit(string id)
        {
            Mahasiswa = new MahasiswaService();
            ViewData["jurusan"] = Mahasiswa.GetJurusan();
            return View(Mahasiswa.GetListMahasiswaById(id));
        }

        // POST: Mahasiswa/Edit/5
        [HttpPost]
        public ActionResult Edit(MahasiswaModel model)
        {
            try
            {
                Mahasiswa = new MahasiswaService();
    
                Mahasiswa.UpdateMahasiswa(model);
                return Json(new { success = true, message = "Data Update Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { success = false, message = "Save data failed" }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Mahasiswa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mahasiswa/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
