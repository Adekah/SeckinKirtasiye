using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Net;
using Seckinkirtasiye.Models;

namespace Seckinkirtasiye.Data
{
    public class Data
    {
        //public static bool saveSlide(tbl_slider _Slider)
        //{
        //    bool _result = true;
        //    using (seckinkirtasiyeEntities db = new seckinkirtasiyeEntities())
        //    {
        //        try
        //        {
        //            if (_Slider.Slider_image_ID == 0)
        //            {
        //                db.tbl_slider.Add(_Slider);
        //            }
        //            else
        //            {
        //                db.tbl_slider.Attach(_Slider);
        //                db.Entry(_Slider).State = System.Data.Entity.EntityState.Modified;
        //            }
        //            db.SaveChanges();
        //        }
        //        catch (Exception)
        //        {
        //            _result = false;

        //        }
        //    }

        //    return _result;

        //}



        public static bool saveSlide(tbl_slider _Slider)
        {
            bool _result = true;
            using (seckinkirtasiyeEntities db = new seckinkirtasiyeEntities())
            {
                try
                {
                    if (_Slider.Slider_image_ID == 0)
                    {
                        db.tbl_slider.Add(_Slider);
                    }
                    else
                    {
                        db.tbl_slider.Attach(_Slider);
                        db.Entry(_Slider).State = System.Data.Entity.EntityState.Modified;
                    }
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    _result = false;

                }
            }

            return _result;

        }

        public static bool saveBrand(tbl_Marka _Brands)
        {
            bool _result = true;
            using (seckinkirtasiyeEntities db= new seckinkirtasiyeEntities())
            {
                try
                {
                    if (_Brands.Marka_ID==0)
                    {
                        db.tbl_Marka.Add(_Brands);
                    }
                    else
                    {
                        db.tbl_Marka.Attach(_Brands);
                        db.Entry(_Brands).State = System.Data.Entity.EntityState.Modified;
                    }
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    _result = false;
                }

            }
            return _result;
        }


        public static bool saveAboutus(tbl_AboutUs _About)
        {
            bool _result = true;
            using (seckinkirtasiyeEntities db = new seckinkirtasiyeEntities())
            {
                try
                {
                    if (_About.Aboutus_ID == 0)
                    {
                        db.tbl_AboutUs.Add(_About);
                    }
                    else
                    {
                        db.tbl_AboutUs.Attach(_About);
                        db.Entry(_About).State = System.Data.Entity.EntityState.Modified;
                    }
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    _result = false;
                }

            }
            return _result;
        }








        public static List<tbl_slider> get_Slider()
        {
            using (seckinkirtasiyeEntities db = new seckinkirtasiyeEntities())
            {
                return db.tbl_slider.ToList();
            }
        }

        public static tbl_slider get_slide( int? id)
        {
            using (seckinkirtasiyeEntities db = new seckinkirtasiyeEntities())
            {
                return db.tbl_slider.Where(a => a.Slider_image_ID == id).SingleOrDefault();
            }
        }
        public static List<tbl_Marka> get_Marka()
        {
            using (seckinkirtasiyeEntities db = new seckinkirtasiyeEntities())
            {
                return db.tbl_Marka.ToList();
            }


        }
        public static tbl_Marka get_brand(int? id )
        {
            using (seckinkirtasiyeEntities db = new seckinkirtasiyeEntities())
            {
                return db.tbl_Marka.Where(a => a.Marka_ID == id).SingleOrDefault();
            }
        }
        public static tbl_AboutUs get_about(int? id)
        {
            using (seckinkirtasiyeEntities db = new seckinkirtasiyeEntities())
            {
                return db.tbl_AboutUs.Where(a => a.Aboutus_ID == id).SingleOrDefault();
            }
        }
        public static List<tbl_Services> get_Services()
        {
            using (seckinkirtasiyeEntities db = new seckinkirtasiyeEntities())
            {
                return db.tbl_Services.ToList();
            }
        }



        public static List<tbl_Gallery> get_Images()
        {
            using (seckinkirtasiyeEntities db = new seckinkirtasiyeEntities())
            {
                return db.tbl_Gallery.ToList();
            }
        }
        public static tbl_Contact Get_Contacts(int id)
        {
            using (seckinkirtasiyeEntities db = new seckinkirtasiyeEntities())
            {
                return db.tbl_Contact.Where(a => a.Contact_ID == id).SingleOrDefault();
            }
        }

        //public static tbl_Marka get_Marka(int id)
        //{
        //    using (seckinkirtasiyeEntities db = new seckinkirtasiyeEntities())
        //    {
        //        return db.tbl_Marka.Where(a => a.Marka_ID == id).SingleOrDefault();
        //    }
        //}
        public static string get_aboutus(int id)
        {
            using (seckinkirtasiyeEntities db = new seckinkirtasiyeEntities())
            {
                return db.tbl_AboutUs.Where(a => a.Aboutus_ID == id).Select(a => a.AboutUs).SingleOrDefault();
            }
        }
        public static List<tbl_AboutUs>get_aboutuslist()
        {
            using (seckinkirtasiyeEntities db = new seckinkirtasiyeEntities())
            {
                return db.tbl_AboutUs.ToList();
            }
        }

        public static tbl_User login(string password, string username)
        {
            using (seckinkirtasiyeEntities db = new seckinkirtasiyeEntities())
            {
                var user = db.tbl_User.Where(a => a.User_Username == username && a.User_Password == password).SingleOrDefault();
                return user;
            }
        }
        public static string getfullname(int id)
        {
            using (seckinkirtasiyeEntities db = new seckinkirtasiyeEntities())
            {
                return db.tbl_User.Where(a => a.User_ID == id).Select(a => a.User_NameSurname).SingleOrDefault();
            }
        }










    }
}