using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WMSPro.Data;
using WMSPro.Models;
using WMSPro.ViewModels;

namespace WMSPro.Controllers
{
    // ═══════════════════════════════════════════════════════════
    //  NHÀ CUNG CẤP — Admin + QuanLyKho quản lý
    // ═══════════════════════════════════════════════════════════
    [Authorize]
    public class NhaCungCapController : Controller
    {
        private readonly AppDbContext _db;
        public NhaCungCapController(AppDbContext db) => _db = db;

        public async Task<IActionResult> Index(string? q)
        {
            ViewBag.Q = q ?? "";
            var ds = _db.NhaCungCaps.AsQueryable();
            if (!string.IsNullOrEmpty(q))
                ds = ds.Where(x => x.TenNhaCungCap.Contains(q) || x.MaNhaCungCap.Contains(q) || x.SoDienThoai.Contains(q));
            return View(await ds.ToListAsync());
        }

        [Authorize(Roles = $"{VaiTroConst.QuanLy},{VaiTroConst.Admin}")]
        public async Task<IActionResult> Tao()
        {
            var count = await _db.NhaCungCaps.CountAsync();
            return View(new NhaCungCap { MaNhaCungCap = $"NCC-{(count + 1):D3}" });
        }

        [HttpPost, Authorize(Roles = $"{VaiTroConst.QuanLy},{VaiTroConst.Admin}")]
        public async Task<IActionResult> Tao(NhaCungCap model)
        {
            if (!ModelState.IsValid) return View(model);
            _db.NhaCungCaps.Add(model);
            await _db.SaveChangesAsync();
            TempData["Success"] = $"Đã thêm nhà cung cấp {model.TenNhaCungCap}!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Xem(int id)
        {
            var ncc = await _db.NhaCungCaps.FindAsync(id);
            if (ncc == null) return NotFound();
            ViewBag.VatTuCuaNCC = await _db.VatTus.Where(v => v.MaNhaCungCap == ncc.MaNhaCungCap).ToListAsync();
            return View(ncc);
        }

        [Authorize(Roles = $"{VaiTroConst.QuanLy},{VaiTroConst.Admin}")]
        public async Task<IActionResult> Sua(int id)
        {
            var ncc = await _db.NhaCungCaps.FindAsync(id);
            if (ncc == null) return NotFound();
            return View(ncc);
        }

        [HttpPost, Authorize(Roles = $"{VaiTroConst.QuanLy},{VaiTroConst.Admin}")]
        public async Task<IActionResult> Sua(NhaCungCap model)
        {
            if (!ModelState.IsValid) return View(model);
            _db.NhaCungCaps.Update(model);
            await _db.SaveChangesAsync();
            TempData["Success"] = $"Đã cập nhật {model.TenNhaCungCap}!";
            return RedirectToAction("Index");
        }

        [HttpPost, Authorize(Roles = VaiTroConst.Admin)]
        public async Task<IActionResult> Xoa(int id)
        {
            var ncc = await _db.NhaCungCaps.FindAsync(id);
            if (ncc != null) { _db.NhaCungCaps.Remove(ncc); await _db.SaveChangesAsync(); TempData["Success"] = $"Đã xóa {ncc.TenNhaCungCap}!"; }
            return RedirectToAction("Index");
        }
    }

    // ═══════════════════════════════════════════════════════════
    //  QUẢN LÝ KHO — Chỉ Admin mới được thêm/xoá kho
    // ═══════════════════════════════════════════════════════════
    [Authorize]
    public class QuanLyKhoController : Controller
    {
        private readonly AppDbContext _db;
        public QuanLyKhoController(AppDbContext db) => _db = db;

        public async Task<IActionResult> Index() => View(await _db.Khos.ToListAsync());

        [Authorize(Roles = VaiTroConst.Admin)]
        public async Task<IActionResult> Tao()
        {
            var count = await _db.Khos.CountAsync();
            return View(new Kho { MaKho = $"KHO-{(char)('A' + count)}" });
        }

        [HttpPost, Authorize(Roles = VaiTroConst.Admin)]
        public async Task<IActionResult> Tao(Kho model)
        {
            if (!ModelState.IsValid) return View(model);
            _db.Khos.Add(model);
            await _db.SaveChangesAsync();
            TempData["Success"] = $"Đã thêm kho {model.TenKho}!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = $"{VaiTroConst.QuanLy},{VaiTroConst.Admin}")]
        public async Task<IActionResult> Sua(int id)
        {
            var kho = await _db.Khos.FindAsync(id);
            if (kho == null) return NotFound();
            return View(kho);
        }

        [HttpPost, Authorize(Roles = $"{VaiTroConst.QuanLy},{VaiTroConst.Admin}")]
        public async Task<IActionResult> Sua(Kho model)
        {
            if (!ModelState.IsValid) return View(model);
            _db.Khos.Update(model);
            await _db.SaveChangesAsync();
            TempData["Success"] = $"Đã cập nhật {model.TenKho}!";
            return RedirectToAction("Index");
        }

        [HttpPost, Authorize(Roles = VaiTroConst.Admin)]
        public async Task<IActionResult> Xoa(int id)
        {
            var kho = await _db.Khos.FindAsync(id);
            if (kho != null) { _db.Khos.Remove(kho); await _db.SaveChangesAsync(); TempData["Success"] = $"Đã xóa {kho.TenKho}!"; }
            return RedirectToAction("Index");
        }
    }

    // ═══════════════════════════════════════════════════════════
    //  VỊ TRÍ KHO
    // ═══════════════════════════════════════════════════════════
    [Authorize]
    public class ViTriKhoController : Controller
    {
        private readonly AppDbContext _db;
        public ViTriKhoController(AppDbContext db) => _db = db;

        public async Task<IActionResult> Index(string? maKho)
        {
            ViewBag.MaKho = maKho ?? "KHO-A";
            ViewBag.DanhSachKho = await _db.Khos.ToListAsync();
            var ds = _db.ViTris.AsQueryable();
            if (!string.IsNullOrEmpty(maKho)) ds = ds.Where(v => v.MaKho == maKho);
            return View(await ds.ToListAsync());
        }

        [Authorize(Roles = $"{VaiTroConst.QuanLy},{VaiTroConst.Admin}")]
        public async Task<IActionResult> Tao()
        {
            ViewBag.DanhSachKho = await _db.Khos.ToListAsync();
            var count = await _db.ViTris.CountAsync();
            return View(new ViTri { MaViTri = $"A1-{(count + 1):D2}" });
        }

        [HttpPost, Authorize(Roles = $"{VaiTroConst.QuanLy},{VaiTroConst.Admin}")]
        public async Task<IActionResult> Tao(ViTri model)
        {
            if (await _db.ViTris.AnyAsync(v => v.MaViTri == model.MaViTri))
            {
                TempData["Error"] = $"Mã vị trí {model.MaViTri} đã tồn tại!";
                ViewBag.DanhSachKho = await _db.Khos.ToListAsync(); return View(model);
            }
            if (string.IsNullOrEmpty(model.TinhTrang)) model.TinhTrang = "Trống";
            if (string.IsNullOrEmpty(model.MatHang)) model.MatHang = "—";
            _db.ViTris.Add(model);
            await _db.SaveChangesAsync();
            TempData["Success"] = $"Đã thêm vị trí {model.MaViTri}!";
            return RedirectToAction("Index", new { maKho = model.MaKho });
        }

        [Authorize(Roles = $"{VaiTroConst.QuanLy},{VaiTroConst.Admin}")]
        public async Task<IActionResult> Sua(int id)
        {
            var vt = await _db.ViTris.FindAsync(id);
            if (vt == null) return NotFound();
            ViewBag.DanhSachKho = await _db.Khos.ToListAsync();
            return View(vt);
        }

        [HttpPost, Authorize(Roles = $"{VaiTroConst.QuanLy},{VaiTroConst.Admin}")]
        public async Task<IActionResult> Sua(ViTri model)
        {
            _db.ViTris.Update(model);
            await _db.SaveChangesAsync();
            TempData["Success"] = $"Đã cập nhật vị trí {model.MaViTri}!";
            return RedirectToAction("Index", new { maKho = model.MaKho });
        }

        [HttpPost, Authorize(Roles = VaiTroConst.Admin)]
        public async Task<IActionResult> Xoa(int id)
        {
            var vt = await _db.ViTris.FindAsync(id);
            if (vt != null) { _db.ViTris.Remove(vt); await _db.SaveChangesAsync(); TempData["Success"] = $"Đã xóa vị trí {vt.MaViTri}!"; }
            return RedirectToAction("Index");
        }
    }

    // ═══════════════════════════════════════════════════════════
    //  TỒN KHO, CẢNH BÁO, BÁO CÁO — Mọi người xem được
    // ═══════════════════════════════════════════════════════════
    [Authorize(Roles = VaiTroConst.QuanLyVaAdmin)]  // Quản lý + Admin theo dõi tồn kho
    public class TonKhoController : Controller
    {
        private readonly AppDbContext _db;
        public TonKhoController(AppDbContext db) => _db = db;

        public async Task<IActionResult> Index(string? filter, string? q)
        {
            ViewBag.Filter = filter ?? "tat-ca";
            ViewBag.Q = q ?? "";
            var ds = _db.VatTus.AsQueryable();
            if (filter == "sap-het") ds = ds.Where(x => x.SoLuongTon <= x.MucTonToiThieu);
            if (!string.IsNullOrEmpty(q))
                ds = ds.Where(x => x.TenVatTu.Contains(q) || x.MaVatTu.Contains(q));
            return View(await ds.ToListAsync());
        }
    }

    [Authorize(Roles = VaiTroConst.Admin)]  // Chỉ Admin theo dõi cảnh báo hệ thống
    public class CanhBaoController : Controller
    {
        private readonly AppDbContext _db;
        public CanhBaoController(AppDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var vatTus = await _db.VatTus.ToListAsync();
            var cbSapHet = vatTus
                .Where(v => v.SoLuongTon <= v.MucTonToiThieu)
                .Select(v => new CanhBaoItem
                {
                    TenHang = $"{v.TenVatTu} — Sắp hết hàng",
                    MoTa = $"Tồn kho: {v.SoLuongTon} / Mức tối thiểu: {v.MucTonToiThieu} đơn vị · Vị trí: {v.MaViTri} · Lô: {v.MaLo}",
                    ThoiGian = "Vừa cập nhật",
                    Loai = "sap-het"
                }).ToList();
            ViewBag.CbSapHet = cbSapHet;
            ViewBag.CbTonLau = new List<CanhBaoItem>();
            return View();
        }
    }

    [Authorize(Roles = VaiTroConst.Admin)]  // Chỉ Admin xem báo cáo
    public class BaoCaoController : Controller
    {
        private readonly AppDbContext _db;
        public BaoCaoController(AppDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var vatTus = await _db.VatTus.ToListAsync();
            var phieuNhap = await _db.PhieuNhapKhos.ToListAsync();
            var phieuXuat = await _db.PhieuXuatKhos.ToListAsync();

            var baoCao = vatTus.Select(v => new BaoCaoItem
            {
                MaHang = v.MaVatTu,
                TenHang = v.TenVatTu,
                TongNhap = phieuNhap.Where(p => p.MaHang == v.MaVatTu).Sum(p => p.SlThucTe),
                TongXuat = phieuXuat.Where(p => p.MaHang == v.MaVatTu).Sum(p => p.SlXuat),
                TonCuoiKy = v.SoLuongTon,
                DonVi = v.DonViTinh
            }).ToList();

            // Tính TonDauKy = TonCuoiKy - TongNhap + TongXuat
            foreach (var b in baoCao)
                b.TonDauKy = b.TonCuoiKy - b.TongNhap + b.TongXuat;

            return View(baoCao);
        }
    }
}
