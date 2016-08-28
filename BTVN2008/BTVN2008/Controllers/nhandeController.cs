using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTVN2008.Models;

namespace BTVN2008.Controllers
{
    public class nhandeController : Controller
    {
        // GET: nhande
        [HttpGet]
        public ActionResult Index()
        {
            using (nhanEntities db = new nhanEntities())
            {
                List<nhande> lstCategory = db.nhandes.ToList();
                return View(lstCategory);
            }
        }
        // POST: /Category/Index/
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            //Lay du lieu tu tren view
            string tenChuyenMuc = collection["TenChuyenMuc"].ToString();
            int chuyenMucCha = collection["ChuyenMucCha"].ToString() != "" ? Convert.ToInt32(collection["ChuyenMucCha"].ToString()) : 0;

            using (nhanEntities db = new nhanEntities())
            {
                //Them chuyen muc vao csdl
                //Khoi tao doi tuong muon them vao csdl
                nhande cate = new nhande();
                cate.nhande1 = tenChuyenMuc;
                cate.cha = chuyenMucCha;

                //Them doi tuong vao csdl
                db.nhandes.Add(cate);
                //Thuc hien ghi vao csdl
                db.SaveChanges();

                //Lay danh sach chuyen muc trong csdl tra ve view
                List<nhande> lstCategory = db.nhandes.ToList();
                return View(lstCategory);
            }
        }

        //Category/Edit/123/
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (nhanEntities db = new nhanEntities())
            {
                nhande cate = db.nhandes.FirstOrDefault(x => x.id == id);
                return View(cate);
            }
        }

        //Category/Edit/123/
        [HttpPost]
        public ActionResult Edit(FormCollection collection, int id)
        {
            using (nhanEntities db = new nhanEntities())
            {
                //Lay du lieu tu tren view
                string tenChuyenMuc = collection["TenChuyenMuc"].ToString();
                int chuyenMucCha = collection["ChuyenMucCha"].ToString() != "" ? Convert.ToInt32(collection["ChuyenMucCha"].ToString()) : 0;

                //Lấy đối tượng cần sửa
                nhande cate = db.nhandes.FirstOrDefault(x => x.id == id);

                //Gán lại thông tin cần sửa
                cate.nhande1 = tenChuyenMuc;
                cate.cha = chuyenMucCha;

                //Thực hiện thay đổi trong csdl
                db.SaveChanges();

                //Lay danh sach chuyen muc trong csdl tra ve view
                List<nhande> lstCategory = db.nhandes.ToList();
                return RedirectToAction("Index", lstCategory);
            }
        }

        public ActionResult Delete(int id)
        {
            using (nhanEntities db = new nhanEntities())
            {
                //Lấy đối tượng cần sửa
                nhande cate = db.nhandes.FirstOrDefault(x => x.id == id);

                //Thực hiện xóa đối tượng
                db.nhandes.Remove(cate);

                //Thực hiện thay đổi trong csdl
                db.SaveChanges();

                //Lay danh sach chuyen muc trong csdl tra ve view
                List<nhande> lstCategory = db.nhandes.ToList();
                return RedirectToAction("Index", lstCategory);
            }
        }
    }
}
