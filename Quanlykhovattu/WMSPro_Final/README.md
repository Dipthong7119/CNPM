# WMS Pro — Hệ thống Quản lý Kho

## Tính năng mới (phiên bản nâng cấp)

- ✅ **SQLite Database** — dữ liệu lưu vĩnh viễn, không mất khi tắt ứng dụng
- ✅ **ASP.NET Core Identity** — xác thực người dùng thực sự (cookie, bcrypt hash)
- ✅ **Phân quyền 3 cấp** — Admin / Quản lý kho / Nhân viên
- ✅ **Quản lý tài khoản** — Admin tạo/khoá/reset mật khẩu người dùng
- ✅ **Tách file** — mỗi model một file, dễ bảo trì

---

## Cài đặt và chạy

### Yêu cầu
- .NET 8 SDK: https://dotnet.microsoft.com/download

### Bước 1 — Restore packages
```bash
dotnet restore
```

### Bước 2 — Tạo Migration và Database
```bash
dotnet ef migrations add IdentityInit
dotnet ef database update
```
> File `wmspro.db` sẽ được tạo tự động tại thư mục project.

### Bước 3 — Chạy ứng dụng
```bash
dotnet run
```
Mở trình duyệt: http://localhost:5000

---

## Tài khoản mặc định

| Vai trò | Tên đăng nhập | Mật khẩu |
|---|---|---|
| 🔴 Admin | `admin` | `Admin@123` |
| 🟡 Quản lý kho | `thukho` | `Thukho@123` |
| 🟢 Nhân viên | `nhanvien` | `Nhanvien@123` |

---

## Phân quyền chi tiết

| Chức năng | Nhân viên 🟢 | Quản lý kho 🟡 | Admin 🔴 |
|---|:---:|:---:|:---:|
| Xem tồn kho, tồn kho, báo cáo | ✅ | ✅ | ✅ |
| Xem phiếu nhập / xuất | ✅ | ✅ | ✅ |
| **Tạo / sửa phiếu nhập / xuất** | ❌ | ✅ | ✅ |
| **Quản lý vật tư, vị trí, NCC** | ❌ | ✅ | ✅ |
| **Xoá dữ liệu** | ❌ | ❌ | ✅ |
| **Quản lý người dùng** | ❌ | ❌ | ✅ |
| **Tạo / khoá tài khoản** | ❌ | ❌ | ✅ |

---

## Cấu trúc thư mục

```
WMSPro/
├── Controllers/
│   ├── AccountController.cs      ← Đăng nhập / đăng xuất / đổi mật khẩu
│   ├── NguoiDungController.cs    ← Admin quản lý tài khoản [Authorize(Admin)]
│   ├── HomeController.cs         ← Dashboard [Authorize]
│   ├── VatTuController.cs        ← Vật tư [Authorize]
│   ├── NhapKhoController.cs      ← Phiếu nhập [Authorize]
│   ├── XuatKhoController.cs      ← Phiếu xuất [Authorize]
│   └── OtherControllers.cs       ← Kho, ViTri, NCC, TonKho, CanhBao, BaoCao
│
├── Data/
│   ├── AppDbContext.cs            ← EF Core DbContext + Identity
│   └── DbSeeder.cs               ← Seed roles + tài khoản + dữ liệu mẫu
│
├── Models/
│   ├── ApplicationUser.cs        ← Identity User + VaiTroConst
│   ├── VatTu.cs
│   ├── Kho.cs
│   ├── ViTri.cs
│   ├── NhaCungCap.cs
│   ├── PhieuNhapKho.cs
│   └── PhieuXuatKho.cs
│
├── ViewModels/
│   └── ViewModels.cs             ← LoginVM, DashboardVM, BaoCaoVM, NguoiDungVM...
│
├── Views/
│   ├── Account/
│   │   ├── Login.cshtml
│   │   ├── AccessDenied.cshtml
│   │   └── DoiMatKhau.cshtml
│   ├── NguoiDung/
│   │   ├── Index.cshtml
│   │   └── Tao.cshtml
│   ├── Shared/
│   │   └── _Layout.cshtml        ← Menu hiển thị theo vai trò
│   └── ... (các views khác giữ nguyên)
│
├── Program.cs                    ← Identity + EF Core + Cookie + Authorization
├── appsettings.json
└── wmspro.db                     ← SQLite database (tự tạo khi chạy lần đầu)
```

---

## Ghi chú kỹ thuật

- Database tự migrate khi khởi động (`db.Database.Migrate()`)
- Dữ liệu mẫu tự seed nếu bảng trống (`DbSeeder.SeedAsync`)
- Mật khẩu được hash bằng bcrypt thông qua ASP.NET Identity
- Tài khoản bị khoá sau 5 lần nhập sai mật khẩu (5 phút)
- Cookie xác thực tồn tại 8 giờ, tự gia hạn khi dùng
