using ccct2019.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ccct2019.Controllers
{
    
    public class UserController : Controller
    {
        private ConnectDB cnn = new ConnectDB();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // Đăng nhập
        public ActionResult Login()
        {
            return View("Login");
        }

        // Đăng xuất
        public ActionResult Logout()
        {
            Session["userid"] = null;
            Session["username"] = null;
            Session["fullname"] = null;
            Session["avatar"] = null;

            return RedirectToAction("Login");
        }
        // Xử lý Đăng nhập
        public int LoginAction(string username, string pass)
        {
            int result = 0;

            var userN = cnn.User.Where(u => u.UserName.Equals(username)).FirstOrDefault();
            var passw = MD5Hash(pass);
            if (userN != null)
            {
                if (userN.PassWord.Equals(MD5Hash(pass)))
                {
                    Session["userid"] = userN.ID;
                    Session["username"] = userN.UserName;
                    Session["fullname"] = userN.Hoten;
                    Session["avatar"] = userN.Avatar;

                    result = 1;
                }
            }
            return result;
        }
        // Mã hóa Md5
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}