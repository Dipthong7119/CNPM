# ?? CHANGELOG - C?p Nh?t 2024

## ?? Hai Yêu C?u ?ã Implement

### ? 1. Nh?p S? Phi?u Th? Công (Manual Invoice Number)

**Mô t?**: Cho phép Admin & Qu?n lý kho nh?p s? phi?u t? bàn phím thay vì auto-generate

#### Files Thay ??i:

**Controllers/NhapKhoController.cs**
- S?a method `Tao()` (GET): Lo?i b? auto-generate, ?? `SoPhieu = ""` (tr?ng)
- S?a method `Tao()` (POST): 
  - Thêm validation ki?m tra `SoPhieu` không tr?ng
  - Thêm ki?m tra duplicate: `SoPhieu` không ???c t?n t?i
  - S?a Authorize t? `VaiTroConst.NhanVienVaAdmin` ? `VaiTroConst.QuanLyVaAdmin`

**Controllers/XuatKhoController.cs**
- S?a method `Tao()` (GET): Lo?i b? auto-generate, ?? `SoPhieu = ""` (tr?ng)
- S?a method `Tao()` (POST):
  - Thêm validation ki?m tra `SoPhieu` không tr?ng
  - Thêm ki?m tra duplicate
  - S?a Authorize t? `VaiTroConst.NhanVienVaAdmin` ? `VaiTroConst.QuanLyVaAdmin`

**Views/NhapKho/Tao.cshtml**
- Thay ??i input t? `readonly` ? nh?p ???c
- Thêm placeholder: "Nh?p s? phi?u (VD: PN-2026-903)"
- Thêm helper text

**Views/XuatKho/Tao.cshtml**
- Thay ??i input t? `readonly` ? nh?p ???c
- Thêm placeholder: "Nh?p s? phi?u (VD: PX-2026-850)"
- Thêm helper text

#### Quy?n Truy C?p:
```
? Admin ? T?o phi?u + nh?p s? phi?u
? Qu?n lý kho ? T?o phi?u + nh?p s? phi?u
? Nhân viên ? KHÔNG t?o phi?u
```

#### Validation:
```csharp
// Ki?m tra s? phi?u không tr?ng
if (string.IsNullOrEmpty(model.SoPhieu))
    TempData["Error"] = "Vui lòng nh?p s? phi?u!";

// Ki?m tra s? phi?u không duplicate
if (await _db.PhieuNhapKhos.AnyAsync(x => x.SoPhieu == model.SoPhieu))
    TempData["Error"] = $"S? phi?u {model.SoPhieu} ?ã t?n t?i!";
```

---

### ? 2. Ch?c N?ng S?a Vai Trò Ng??i Dùng (Edit User Role)

**Mô t?**: Admin có th? ch?nh s?a vai trò c?a ng??i dùng

#### Files Thay ??i:

**Controllers/NguoiDungController.cs**
- Thêm method `Sua(string id)` (GET): Hi?n th? form ch?nh s?a
  ```csharp
  [Authorize(Roles = VaiTroConst.Admin)]
  public async Task<IActionResult> Sua(string id)
  {
      // Load user t? database
      // Tr? v? SuaTaiKhoanViewModel v?i vai trò hi?n t?i & m?i
  }
  ```

- Thêm method `Sua(SuaTaiKhoanViewModel model)` (POST): X? lý l?u
  ```csharp
  [HttpPost, Authorize(Roles = VaiTroConst.Admin)]
  public async Task<IActionResult> Sua(SuaTaiKhoanViewModel model)
  {
      // C?p nh?t HoTen, Email
      // Xoá vai trò c?
      // Thêm vai trò m?i
      // Redirect v? Index
  }
  ```

**ViewModels/ViewModels.cs**
- Thêm ViewModel m?i: `SuaTaiKhoanViewModel`
  ```csharp
  public class SuaTaiKhoanViewModel
  {
      public string Id { get; set; } = "";
      public string TenDangNhap { get; set; } = "";
      public string HoTen { get; set; } = "";
      public string? Email { get; set; }
      public string VaiTroHienTai { get; set; } = "";
      public string VaiTroMoi { get; set; } = "";
      public string TrangThai { get; set; } = "";
  }
  ```

**Views/NguoiDung/Index.cshtml**
- Thêm nút "?? S?a" tr??c nút "Khoá"
  ```html
  <a href="/NguoiDung/Sua/@u.Id" class="btn-sm btn-sm-info">
      ?? S?a
  </a>
  ```
- Thêm style `.btn-sm-info`

**Views/NguoiDung/Sua.cshtml** (NEW FILE)
- Form ch?nh s?a tài kho?n
  - Tên ??ng nh?p: `readonly`
  - H? tên: editable
  - Email: editable
  - Tr?ng thái: `readonly` (s? d?ng nút Khoá/M? khoá)
  - Vai trò hi?n t?i: displayed (không editable)
  - Vai trò m?i: `<select>` dropdown (editable)
  - Warning message n?u vai trò thay ??i

#### Quy?n Truy C?p:
```
? Admin ? S?a vai trò ng??i dùng
? Qu?n lý kho ? KHÔNG s?a
? Nhân viên ? KHÔNG s?a
```

#### Validation:
```csharp
// Không cho s?a chính mình
if (user.Id == currentUser?.Id)
    TempData["Error"] = "Không th? thay ??i vai trò c?a chính mình!";

// Xoá vai trò c?, thêm vai trò m?i
if (model.VaiTroHienTai != model.VaiTroMoi)
{
    await _userMgr.RemoveFromRoleAsync(user, model.VaiTroHienTai);
    await _userMgr.AddToRoleAsync(user, model.VaiTroMoi);
}
```

---

## ?? Tóm T?t Thay ??i

| Ch?c N?ng | Lo?i Thay ??i | File | Dòng |
|-----------|---------------|------|------|
| **S? phi?u nh?p** | Thay ??i | Controllers/NhapKhoController.cs | 40-52, 53-95 |
| **S? phi?u nh?p** | Thay ??i | Views/NhapKho/Tao.cshtml | 14-18 |
| **S? phi?u xu?t** | Thay ??i | Controllers/XuatKhoController.cs | 38-46, 48-66 |
| **S? phi?u xu?t** | Thay ??i | Views/XuatKho/Tao.cshtml | 12-15 |
| **Qu?n lý vai trò** | Thêm | Controllers/NguoiDungController.cs | 93-139 |
| **Qu?n lý vai trò** | Thêm | ViewModels/ViewModels.cs | 112-133 |
| **Qu?n lý vai trò** | Thêm | Views/NguoiDung/Sua.cshtml | NEW FILE |
| **Qu?n lý vai trò** | Thay ??i | Views/NguoiDung/Index.cshtml | 55-76, 97-99 |

---

## ?? Cách Test

### Test 1: Nh?p S? Phi?u Th? Công

1. **Login Admin** ho?c **Qu?n lý kho**
2. Vào **Phi?u Nh?p Kho** ? T?o phi?u m?i
3. Xác nh?n:
   - [ ] Input "S? phi?u" **không ph?i readonly** (có th? nh?p)
   - [ ] Placeholder hi?n th?: "Nh?p s? phi?u (VD: PN-2026-903)"
   - [ ] Nh?p s? phi?u b?t k? (VD: PN-CUSTOM-001)
   - [ ] Submit thành công n?u format h?p l?
   - [ ] Error n?u s? phi?u trùng
4. Ki?m tra **Phi?u Xu?t Kho** t??ng t?

### Test 2: S?a Vai Trò Ng??i Dùng

1. **Login Admin**
2. Vào **Qu?n lý ng??i dùng**
3. Xác nh?n:
   - [ ] Nút "?? S?a" hi?n th? ? m?i dòng ng??i dùng
   - [ ] Click "S?a" ? Vào form ch?nh s?a
   - [ ] Form hi?n th?:
     - Tên ??ng nh?p: readonly
     - H? tên: editable
     - Email: editable
     - Vai trò hi?n t?i: displayed
     - Vai trò m?i: dropdown
   - [ ] Thay ??i vai trò (VD: NhanVien ? QuanLy)
   - [ ] Submit thành công
   - [ ] Vai trò c?p nh?t trong b?ng Index
   - [ ] Warning n?u admin c? thay vai trò c?a chính mình (error)

---

## ? Build Status

**Build Result**: ? **SUCCESS - No Errors**

---

## ?? Notes

1. **Auto-generate b? lo?i b?**: S? phi?u không còn t? ??ng t?o, user ph?i nh?p th? công
2. **Duplicate check**: H? th?ng ki?m tra s? phi?u không ???c trùng
3. **Vai trò Admin**: Không th? thay ??i vai trò c?a chính mình (tránh b? lock)
4. **UI/UX**: Thêm placeholder, helper text, warning messages rõ ràng
5. **Authorization**: Ch?t ch? h?n - ch? Admin & Qu?n lý m?i t?o phi?u

---

