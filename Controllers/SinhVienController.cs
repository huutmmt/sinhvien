using database.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static database.Models.SinhVien;
using static database.Models.Model1;
using System.Data.Entity.Infrastructure;

namespace database.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly Model1 db = new Model1();
        // GET: SinhVien    
        public ActionResult IndexSV()
        {
            var sv = db.SinhViens.ToList();
            return View(sv);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(SinhVien s)
        {
            db.SinhViens.Add(s);
            db.SaveChanges();
            return RedirectToAction("IndexSV");
        }

        // GET: SinhVien/Delete/5
        public ActionResult Delete(int id)
        {
            // Lấy sinh viên cần xóa từ cơ sở dữ liệu
            var sinhVien = db.SinhViens.Find(id);

            if (sinhVien == null)
            {
                return HttpNotFound(); // Trả về trang lỗi 404 nếu không tìm thấy sinh viên
            }

            return View(sinhVien); // Trả về trang xác nhận xóa
        }

        // POST: SinhVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Lấy sinh viên cần xóa từ cơ sở dữ liệu
            var sinhVien = db.SinhViens.Find(id);

            if (sinhVien == null)
            {
                return HttpNotFound(); // Trả về trang lỗi 404 nếu không tìm thấy sinh viên
            }

            db.SinhViens.Remove(sinhVien);
            db.SaveChanges();
            return RedirectToAction("IndexSV");
        }
        // GET: SinhVien/Edit/5
        public ActionResult Edit(int id)
        {
            var sinhVien = db.SinhViens.Find(id);

            if (sinhVien == null)
            {
                return HttpNotFound(); // Trả về trang lỗi 404 nếu không tìm thấy sinh viên
            }

            return View(sinhVien); // Trả về trang sửa thông tin sinh viên
        }

        // POST: SinhVien/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SinhVien s)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(s).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("IndexSV");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Xử lý lỗi xung đột phiên làm việc ở đây.
                ModelState.AddModelError(string.Empty, "Dữ liệu đã bị thay đổi bởi một người khác. Vui lòng cập nhật lại dữ liệu.");
            }   

            return View(s);
        }


    }
}
