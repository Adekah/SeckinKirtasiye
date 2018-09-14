using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Net;
using Seckinkirtasiye.Models;

namespace Seckinkirtasiye.Controllers
{
    [RequireHttps]
    public class DefaultController : Controller
    {
        seckinkirtasiyeEntities db = new seckinkirtasiyeEntities();

        [HandleError]
        public ActionResult Index()
        {
            ///tbl_Slider Tablosu
            ViewBag.SliderImage = Data.Data.get_Slider();
            //tbl_Services Tablosu
            ViewBag.Marka = Data.Data.get_Marka();
            ViewBag.GalleryImages = Data.Data.get_Images();
            ViewBag.Contact = Data.Data.Get_Contacts(2);
            ViewBag.Services = Data.Data.get_Services();
            ViewBag.aboutus = Data.Data.get_aboutus(1);


            return View();
        }
        public ActionResult PagenotFound_Error()
        {
            return View();
        }
    }
}