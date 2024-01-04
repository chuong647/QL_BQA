using onlineShop.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using onlineShop.Models.EF;
using onlineShop.Security;
namespace onlineShop.Areas.Admin.Controllers
{
    public class HomeAdController : Controller
    {
        //
        // GET: /Admin/HomeAd/
        public ActionResult Index()
        {
            if (SessesionPersister.nhanVien == null)
                return RedirectToAction("Login", "HomeAd");
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(NhanVien model)
        {
            NhanVienDao nv = new NhanVienDao();
            if (string.IsNullOrEmpty(model.TenTK) || string.IsNullOrEmpty(model.Pass)
                || nv.LoginNV(model.TenTK, model.Pass) == null)
            {
                ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng";
                return View();
            }
            SessesionPersister.nhanVien = nv.LoginNV(model.TenTK, model.Pass);
            return RedirectToAction("Index", "HomeAd");


        }

        public ActionResult Logout()
        {
            SessesionPersister.nhanVien = null;
            return RedirectToAction("Login", "HomeAd");

        }
        public ActionResult Search(string key)
        {
            var list = new SanPhamDao().Search(key);
            return View(list);
        }
    }
}