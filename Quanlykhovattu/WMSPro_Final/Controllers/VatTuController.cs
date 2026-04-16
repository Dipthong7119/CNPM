using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WMSPro.Data;
using WMSPro.Models;

namespace WMSPro.Controllers
{
    [Authorize] // Mọi nhân viên đã đăng nhập đều xem được
    public class VatTuController : Controller
    {
        private readonly AppDbContext _db;

        public VatTuController(AppDbContext db) => _db = db;

        public async Task<IActionResult> Index(string? q, string? loai)
        {
            ViewBag.Q = q ?? "";
            ViewBag.Loai = loai ?? "";

            var ds = _db.VatTus.AsQueryable();
            if (!string.IsNullOrEmpty(q))
                ds = ds.Where(x => x.MaVatTu.Contains(q) || x.TenVatTu.Contains(q)
                    || x.LoaiVatTu.Contains(q) || x.MaLo.Contains(q));
            if (!string.IsNullOrEmpty(loai))
                ds = ds.Where(x => x.LoaiVatTu == loai);

            return View(await ds.ToListAsync());
        }

        // Tạo mới: Admin + QuanLyKho
        [Authorize(Roles = $"{VaiTroConst.QuanLy},{VaiTroConst.Admin}")]
        public async Task<IActionResult> Tao()
        {
            await LoadViewBag();
            return View(new VatTu());
        }

        [HttpPost, Authorize(Roles = $"{VaiTroConst.QuanLy},{VaiTroConst.Admin}")]
        public async Task<IActionResult> Tao(VatTu model)
        {
            if (await _db.VatTus.AnyAsync(v => v.MaVatTu == model.MaVatTu))
                ModelState.AddModelError("MaVatTu", "Mã vật tư đã tồn tại!");

            if (!ModelState.IsValid) { await LoadViewBag(); return View(model); }

            var ncc = await _db.NhaCungCaps.FirstOrDefaultAsync(n => n.MaNhaCungCap == model.MaNhaCungCap);
            model.TenNhaCungCap = ncc?.TenNhaCungCap ?? "";

            _db.VatTus.Add(model);
            await _db.SaveChangesAsync();
            TempData["Success"] = $"Đã thêm vật tư {model.TenVatTu} thành công!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Xem(int id)
        {
            var vt = await _db.VatTus.FindAsync(id);
            if (vt == null) return NotFound();
            return View(vt);
        }

        [Authorize(Roles = $"{VaiTroConst.QuanLy},{VaiTroConst.Admin}")]
        public async Task<IActionResult> Sua(int id)
        {
            var vt = await _db.VatTus.FindAsync(id);
            if (vt == null) return NotFound();
            await LoadViewBag();
            return View(vt);
        }

        [HttpPost, Authorize(Roles = $"{VaiTroConst.QuanLy},{VaiTroConst.Admin}")]
        public async Task<IActionResult> Sua(VatTu model)
        {
            if (!ModelState.IsValid) { await LoadViewBag(); return View(model); }

            var ncc = await _db.NhaCungCaps.FirstOrDefaultAsync(n => n.MaNhaCungCap == model.MaNhaCungCap);
            model.TenNhaCungCap = ncc?.TenNhaCungCap ?? model.TenNhaCungCap;

            _db.VatTus.Update(model);
            await _db.SaveChangesAsync();
            TempData["Success"] = $"Đã cập nhật vật tư {model.TenVatTu}!";
            return RedirectToAction("Index");
        }

        [HttpPost, Authorize(Roles = VaiTroConst.Admin)]
        public async Task<IActionResult> Xoa(int id)
        {
            var vt = await _db.VatTus.FindAsync(id);
            if (vt != null)
            {
                _db.VatTus.Remove(vt);
                await _db.SaveChangesAsync();
                TempData["Success"] = $"Đã xóa vật tư {vt.TenVatTu}!";
            }
            return RedirectToAction("Index");
        }

        private async Task LoadViewBag()
        {
            ViewBag.DanhSachNCC = await _db.NhaCungCaps.ToListAsync();
            ViewBag.DanhSachKho = await _db.Khos.ToListAsync();
            ViewBag.DanhSachViTri = await _db.ViTris.Where(v => v.TinhTrang != "Đầy").ToListAsync();
        }
    }
}
