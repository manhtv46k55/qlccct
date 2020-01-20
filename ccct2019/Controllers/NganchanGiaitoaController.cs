using ccct2019.Data;
using ccct2019.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ccct2019.Controllers
{
    public class NganchanGiaitoaController : Controller
    {
        // GET: NganchanGiaitoa

        ConnectDB cnn = new ConnectDB();

        [AuthorizeBussiness]
        public ActionResult Index()
        {
            int numberNcgt = cnn.NganchanGiaitoa.Where(a => a.IsActive.Equals(1) && a.Demncgt.Equals(null)).Count();
            ViewBag.numberNcgt = numberNcgt;
            
            return View();
        }

        public ActionResult ViewNCGT()
        {
            return View();
        }

        [AuthorizeBussiness]
        public PartialViewResult Search(string search = "", int page = 1)
        {
            var query = from p in cnn.NganchanGiaitoa
                        where p.SoGCN.Contains(search) && p.IsActive.Equals(1) || p.Noicap.Contains(search) && p.IsActive.Equals(1)
                        orderby p.CreateDate descending
                        select p;
            List<NganchanGiaitoa> listncgt = query.ToList();
            IPagedList<NganchanGiaitoa> listPagedNcgt = query.ToPagedList(page, 7);
            return PartialView("_ListNcgt", listPagedNcgt);
        }
        [AuthorizeBussiness]
        public PartialViewResult SearchMod(string search = "", int page = 1)
        {
            var query = from p in cnn.NganchanGiaitoa
                        where p.SoGCN.Contains(search) && p.IsActive.Equals(1) || p.Noicap.Contains(search) && p.IsActive.Equals(1)
                        orderby p.CreateDate descending
                        select p;
            List<NganchanGiaitoa> listncgt = query.ToList();
            IPagedList<NganchanGiaitoa> listPagedNcgt = query.ToPagedList(page, 7);
            return PartialView("_ListNcgtMod", listPagedNcgt);
        }




        //Upload file

        public string UploadFile(HttpPostedFileBase file)
        {
            //xử lý upload
            // Get random file name.
            //
            string msg = "";
            string random = Path.GetRandomFileName();

            file.SaveAs(Server.MapPath("~/Content/uploadfile/file/" + random + file.FileName));
            msg = random + file.FileName;
            return msg;

        }

        //thêm ncgt
        public int Add(int UserID, string SoGCN, string noicap, DateTime ngaycap, string hoten, string diachi, string thuadat, string bandoso,
            string diachithuadat, string dientich, string sudungchung, string mucdichsudung, string sudungrieng, string thoihansudung,
            string nguongoc, int loaivb, string sokyhieu, DateTime ngayvb, string noigui, string lydo, string filedinhkem)
        {
            try
            {

                NganchanGiaitoa ncgt = new NganchanGiaitoa();
                ncgt.SoGCN = SoGCN;
                ncgt.Noicap = noicap;
                //string thang = Convert.ToString(ngaycap.Month);
                //string nam = Convert.ToString(ngaycap.Year);
                //string dateformart = (ngay + "-" + thang + "-" + nam);
                ncgt.Ngaycap = ngaycap;
                ncgt.Chusohuu = hoten;
                ncgt.Diachichusohuu = diachi;
                ncgt.Thuadatso = thuadat;
                ncgt.Bandoso = bandoso;
                ncgt.Diachithuadat = diachithuadat;
                ncgt.Dientich = dientich;
                ncgt.Sudungchung = sudungchung;
                ncgt.Sudungrieng = sudungrieng;
                ncgt.Mucdichsudung = mucdichsudung;
                ncgt.Thoihansudung = thoihansudung;
                ncgt.Nguongoc = nguongoc;
                ncgt.LoaiVB = loaivb;
                ncgt.Sokyhieu = sokyhieu;
                //string ngayb = Convert.ToString(ngayvb.Day);
                //string thangb = Convert.ToString(ngayvb.Month);
                //string namb = Convert.ToString(ngayvb.Year);
                //string dateformartvb = (ngayb + "-" + thangb + "-" + namb);
                ncgt.NgayVB = ngayvb;
                ncgt.Noigui = noigui;
                ncgt.Lydo = lydo;
                ncgt.Filedinhkem = ("/Content/uploadfile/file/" + filedinhkem);
                ncgt.UserID = UserID;
                
                ncgt.CreateDate = DateTime.Now;
                ncgt.IsActive = 1;
                //Luu Pack vao DB
                cnn.NganchanGiaitoa.Add(ncgt);
                cnn.SaveChanges();
                return 1;
                //
            }
            catch
            {
                return 0;
            }

        }

        //Xem ncgt
        public PartialViewResult GetDetail(int ncgtID)
        {
            var query = from i in cnn.NganchanGiaitoa
                        where i.IsActive.Equals(1) && i.ID.Equals(ncgtID)
                        select (i);
            NganchanGiaitoa u = query.FirstOrDefault();
            NganchanGiaitoa Congdem = cnn.NganchanGiaitoa.Find(ncgtID);
            Congdem.Demncgt = 1;
            cnn.SaveChanges();

            return PartialView("_Xemncgt", u);
        }

        //Xem ncgt
        public PartialViewResult GetDetailMod(int ncgtID)
        {
            var query = from i in cnn.NganchanGiaitoa
                        where i.IsActive.Equals(1) && i.ID.Equals(ncgtID)
                        select (i);
            NganchanGiaitoa u = query.FirstOrDefault();
            NganchanGiaitoa Congdem = cnn.NganchanGiaitoa.Find(ncgtID);
            Congdem.Demncgt = 1;
            cnn.SaveChanges();

            return PartialView("_XemncgtMod", u);
        }

        //get id ncgt
        public PartialViewResult GetUpdate(int sncgtID)
        {
            var query = from i in cnn.NganchanGiaitoa
                        where i.IsActive.Equals(1) && i.ID.Equals(sncgtID)
                        select (i);
            NganchanGiaitoa u = query.FirstOrDefault();

            return PartialView("_Suancgt", u);
        }

        //Sửa ngăn chặn giải tỏa
        public int Edit(int NcgtID, int UserID, string SoGCN, string noicap, DateTime ngaycap, string hoten, string diachi, string thuadat, string bandoso,
            string diachithuadat, string dientich, string sudungchung, string mucdichsudung, string sudungrieng, string thoihansudung,
            string nguongoc, int loaivb, string sokyhieu, DateTime ngayvb, string noigui, string lydo, string filedinhkem)
        {
            try
            {
                NganchanGiaitoa update = cnn.NganchanGiaitoa.Find(NcgtID);

                update.SoGCN = SoGCN;
                update.Noicap = noicap;
                update.Ngaycap = ngaycap;
                update.Chusohuu = hoten;
                update.Diachichusohuu = diachi;
                update.Thuadatso = thuadat;
                update.Bandoso = bandoso;
                update.Diachithuadat = diachithuadat;
                update.Dientich = dientich;
                update.Sudungchung = sudungchung;
                update.Sudungrieng = sudungrieng;
                update.Mucdichsudung = mucdichsudung;
                update.Thoihansudung = thoihansudung;
                update.Nguongoc = nguongoc;
                update.LoaiVB = loaivb;
                update.Sokyhieu = sokyhieu;
                update.NgayVB = ngayvb;
                update.Noigui = noigui;
                update.Lydo = lydo;
                string filedinhkemmoi = ("/Content/uploadfile/file/" + filedinhkem);
                string filedinhkemcu = update.Filedinhkem;
                //so sanh file dinh kem
                if (filedinhkem == filedinhkemcu)
                {
                    update.Filedinhkem = filedinhkemcu;
                }
                else
                {
                    update.Filedinhkem = filedinhkemmoi;
                }

                update.UserID = UserID;
                update.CreateDate = DateTime.Now;
                update.IsActive = 1;
                //Luu Pack vao DB       
                cnn.SaveChanges();
                return 1;

            }
            catch
            {
                return 0;
            }

        }

        //get id ncgt
        public PartialViewResult GetDelete(int ncgtID)
        {
            var query = from i in cnn.NganchanGiaitoa
                        where i.IsActive.Equals(1) && i.ID.Equals(ncgtID)
                        select (i);
            NganchanGiaitoa u = query.FirstOrDefault();

            return PartialView("_Xoancgt", u);
        }

        // Xóa ncgt
        public int Delete(int ID)
        {
            try
            {
                NganchanGiaitoa delete = cnn.NganchanGiaitoa.Find(ID);
                delete.CreateDate = DateTime.Now;
                delete.IsActive = 0;
                //Luu Pack vao DB       
                cnn.SaveChanges();
                return 1;

            }
            catch
            {
                return 0;
            }

        }

        //set time out
        public EmptyResult Alive()
        {
            return new EmptyResult();
        }
    }


}