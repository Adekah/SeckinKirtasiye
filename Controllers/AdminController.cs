using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Net;
using Seckinkirtasiye.Models;
using System.IO;

namespace Seckinkirtasiye.Controllers
{
    [RequireHttps]
    public class AdminController : Controller
    {
        adsadsadsa

        seckinkirtasiyeEntities db = new seckinkirtasiyeEntities();

        public static string ftp = "ftp://89.252.180.81/httpdocs/img/";
        public static string ftp_Brand = "ftp://89.252.180.81/httpdocs/img/marka";
        public static string pasword = "K53sseries";
        public static string ftpuser = "Seckinkirtasiye";





        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string password, string username)
        {
            tbl_User user = Data.Data.login(password, username);
            if (user != null)
            {
                Session["UserID"] = user.User_ID;
                return RedirectToAction("Admin_Home", "Admin");

            }
            ViewBag.errormessage = "Kullanıcı adı ya da şifre hatalı...";
            return View();
        }


        public ActionResult Admin_Home()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }
        public ActionResult Slider(int? id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            if (RouteData.Values["id"] != null)
            {
                ViewBag.UpdateSlide = "True";
                int _id = Convert.ToInt32(RouteData.Values["id"]);
                tbl_slider _slide = Data.Data.get_slide(id);
                ViewBag.Slide_Image = _slide.Slider_image;
                ViewBag.Slide_Title = _slide.Slider_image_title;
                ViewBag.Slide_Text = _slide.Slider_image_text;


                return View(_slide);

            }

            return View();
        }
        [HttpPost]
        public ActionResult Slider(HttpPostedFileBase input_slider, tbl_slider _Slider, HttpPostedFileBase input_slider_null)
        {

            if (input_slider != null && input_slider.ContentLength > 0)
            {
                string File = System.IO.Path.GetFileName(input_slider.FileName);
                string GuidKey = Guid.NewGuid().ToString();
                string fileExt = Path.GetExtension(input_slider.FileName);
                _Slider.Slider_image = GuidKey + fileExt;

                var uploadurl = ftp;
                var uploadfilename = GuidKey + fileExt;

                Stream streamObj = input_slider.InputStream;
                byte[] buffer = new byte[input_slider.ContentLength];
                streamObj.Read(buffer, 0, buffer.Length);
                streamObj.Close();
                streamObj = null;
                string ftpurl = String.Format("{0}/{1}", uploadurl, uploadfilename);
                var requestObj = FtpWebRequest.Create(ftpurl) as FtpWebRequest;
                requestObj.Method = WebRequestMethods.Ftp.UploadFile;
                requestObj.Credentials = new NetworkCredential(ftpuser, pasword);
                Stream requestStream = requestObj.GetRequestStream();
                requestStream.Write(buffer, 0, buffer.Length);
                requestStream.Flush();
                requestStream.Close();
                requestObj = null;
            }
            else if (input_slider_null != null && input_slider_null.ContentLength > 0)
            {
                string File = System.IO.Path.GetFileName(input_slider_null.FileName);
                string GuidKey = Guid.NewGuid().ToString();
                string fileExt = Path.GetExtension(input_slider_null.FileName);
                _Slider.Slider_image = GuidKey + fileExt;

                var uploadurl = ftp;
                var uploadfilename = GuidKey + fileExt;

                Stream streamObj = input_slider_null.InputStream;
                byte[] buffer = new byte[input_slider_null.ContentLength];
                streamObj.Read(buffer, 0, buffer.Length);
                streamObj.Close();
                streamObj = null;
                string ftpurl = String.Format("{0}/{1}", uploadurl, uploadfilename);
                var requestObj = FtpWebRequest.Create(ftpurl) as FtpWebRequest;
                requestObj.Method = WebRequestMethods.Ftp.UploadFile;
                requestObj.Credentials = new NetworkCredential(ftpuser, pasword);
                Stream requestStream = requestObj.GetRequestStream();
                requestStream.Write(buffer, 0, buffer.Length);
                requestStream.Flush();
                requestStream.Close();
                requestObj = null;
            }


            if (Data.Data.saveSlide(_Slider) == false)
            {
                ViewBag.Error = "Lütfen Bilgilerinizi Kontrol Ediniz.";
                return RedirectToAction("Error", "Default");
            }
            return RedirectToAction("Slider", "Admin");
        }

        public ActionResult Slide_Delete(int slide_id)
        {
            tbl_slider _deleteslide = (from p in db.tbl_slider where p.Slider_image_ID == slide_id select p).SingleOrDefault();
            int proid = _deleteslide.Slider_image_ID;
            db.tbl_slider.Remove(_deleteslide);
            db.SaveChanges();
            return RedirectToAction("Slider", "Admin");
        }



        public ActionResult Brands(int? id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            if (RouteData.Values["id"] != null)
            {
                ViewBag.UpdateBrand = "True";
                int _id = Convert.ToInt32(RouteData.Values["id"]);
                tbl_Marka _Brand = Data.Data.get_brand(id);
                ViewBag.Brand_Image = _Brand.Marka_logo;
                ViewBag.Brand_Name = _Brand.Marka_name;



                return View(_Brand);

            }



            return View();
        }
        [HttpPost]
        public ActionResult Brands(tbl_Marka Brand, HttpPostedFileBase Brand_image)
        {

            if (Brand_image != null && Brand_image.ContentLength > 0)
            {
                string File = System.IO.Path.GetFileName(Brand_image.FileName);
                string GuidKey = Guid.NewGuid().ToString();
                string fileExt = Path.GetExtension(Brand_image.FileName);
                Brand.Marka_logo = GuidKey + fileExt;

                var uploadurl = ftp_Brand;
                var uploadfilename = GuidKey + fileExt;

                Stream streamObj = Brand_image.InputStream;
                byte[] buffer = new byte[Brand_image.ContentLength];
                streamObj.Read(buffer, 0, buffer.Length);
                streamObj.Close();
                streamObj = null;
                string ftpurl = String.Format("{0}/{1}", uploadurl, uploadfilename);
                var requestObj = FtpWebRequest.Create(ftpurl) as FtpWebRequest;
                requestObj.Method = WebRequestMethods.Ftp.UploadFile;
                requestObj.Credentials = new NetworkCredential(ftpuser, pasword);
                Stream requestStream = requestObj.GetRequestStream();
                requestStream.Write(buffer, 0, buffer.Length);
                requestStream.Flush();
                requestStream.Close();
                requestObj = null;
            }
            if (Data.Data.saveBrand(Brand) == false)
            {
                ViewBag.Error = "Lütfen Bilgilerinizi Kontrol Ediniz.";
                return RedirectToAction("Error", "Default");
            }
            return RedirectToAction("Brands", "Admin");
        }




        public ActionResult Slide_Brand(int brand_id)
        {
            tbl_Marka _deletebrand = (from p in db.tbl_Marka where p.Marka_ID == brand_id select p).SingleOrDefault();
            int proid = _deletebrand.Marka_ID;
            db.tbl_Marka.Remove(_deletebrand);
            db.SaveChanges();
            return RedirectToAction("Brands", "Admin");
        }

        public ActionResult Aboutus(tbl_AboutUs aboutus ,string aboutustext)
        {

            aboutus.Aboutus_ID = 1;
            aboutus.AboutUs = aboutustext;

            if (Data.Data.saveAboutus(aboutus) == false)
            {
                ViewBag.Error = "Lütfen Bilgilerinizi Kontrol Ediniz.";
                return RedirectToAction("Error", "Default");
            }
            return RedirectToAction("Aboutus_Services", "Admin");
        }



        public ActionResult aboutus_services(int? id)
        {
            id = 1;
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            tbl_AboutUs aboutus = Data.Data.get_about(id);
            ViewBag.aboutus = aboutus.AboutUs;


            return View(aboutus);
        }



        [HttpPost]
        public ActionResult aboutus_services(tbl_AboutUs AboutUs)
        {
            if (Data.Data.saveAboutus(AboutUs) == false)
            {
                ViewBag.Error = "Lütfen Bilgilerinizi Kontrol Ediniz.";
                return RedirectToAction("PagenotFound_Error", "Default");
            }

            return View();
               
        }
        public ActionResult Services()
        {
            return View();
        }


    }
}