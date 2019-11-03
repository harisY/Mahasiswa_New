using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mahasiswa_New.Services;
using Mahasiswa_New.Models;

namespace Mahasiswa_New.Controllers
{
    public class JurusanController : Controller
    {
        // GET: Jurusan
        public ActionResult Index()
        {
            GetListJurusan();
            return View();
           
        }

        public ActionResult GetListJurusan()
        {
            JurusanService service  = new JurusanService();
            ViewData["ListJurusan"] = service.GetListJurusan();
            return PartialView("Partial/_ListJurusan");
        }

        public bool ValidasiCreate(string Id)
        {
            JurusanService service = new JurusanService();
            bool result = service.IsDataExist(Id);
            return (result);
        }
        public ActionResult Create(JurusanModel model)
        {
            JurusanService service = new JurusanService();
            int hasil = service.SimpanJurusan(model);
            if (hasil != -1)
            {
                return GetListJurusan();
            }
            return null;
        }

        public ActionResult Edit(JurusanModel model)
        {
            JurusanService service = new JurusanService();
            int hasil = service.UpdateJurusan(model);
            if (hasil != -1)
            {
                return GetListJurusan();
            }
            return null;
        }
        public ActionResult Delete(string Id)
        {
            JurusanService service = new JurusanService();
            int hasil = service.DeleteJurusan(Id);
            if (hasil != -1)
            {
                return GetListJurusan();
            }
            return null;
        }
    }
}