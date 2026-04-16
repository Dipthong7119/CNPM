# ?? TESTING GUIDE - H??ng D?n Test Quy?n Truy C?p

## ?? Tài Kho?n Test Có S?n

H? th?ng ?ã ???c seed v?i 3 tài kho?n m?c ??nh:

### 1. ????? Admin Account
- **Tên ??ng nh?p**: `admin`
- **M?t kh?u**: `Admin@123`
- **Vai trò**: Admin (Qu?n tr? viên)
- **Quy?n**: Toàn quy?n - có th? t?o, s?a, xóa t?t c? d? li?u

### 2. ?? QuanLyKho Account (Qu?n Lý Kho)
- **Tên ??ng nh?p**: `thukho`
- **M?t kh?u**: `Thukho@123`
- **Vai trò**: QuanLyKho
- **Quy?n**: T?o, s?a phi?u nh?p/xu?t, qu?n lý v?t t?, v? trí (KHÔNG xóa)

### 3. ?? NhanVien Account (Nhân Viên)
- **Tên ??ng nh?p**: `nhanvien`
- **M?t kh?u**: `Nhanvien@123`
- **Vai trò**: NhanVien
- **Quy?n**: Ch? xem thông tin (KHÔNG t?o, s?a, xóa)

---

## ? Test Checklist

### Test 1??: Login & Navigation
- [ ] Login thành công v?i tài kho?n admin
- [ ] Login thành công v?i tài kho?n thukho
- [ ] Login thành công v?i tài kho?n nhanvien
- [ ] Logout ho?t ??ng ?úng
- [ ] Redirect ?úng sau khi logout

### Test 2??: Admin Permissions (admin account)

#### Phi?u Nh?p Kho
- [ ] **Index**: Xem ???c danh sách phi?u nh?p
- [ ] **Tao**: Có nút "T?o phi?u nh?p" ? t?o ???c phi?u m?i
- [ ] **Sua**: Có nút "S?a" ? s?a ???c phi?u
- [ ] **Xoa**: Có nút "Xóa" ? xóa ???c phi?u

#### Phi?u Xu?t Kho
- [ ] **Index**: Xem ???c danh sách phi?u xu?t
- [ ] **Tao**: Có nút "T?o phi?u xu?t" ? t?o ???c phi?u m?i
- [ ] **Sua**: Có nút "S?a" ? s?a ???c phi?u
- [ ] **Xoa**: Có nút "Xóa" ? xóa ???c phi?u

#### V?t T?
- [ ] **Index**: Xem ???c danh sách v?t t?
- [ ] **Tao**: Có nút "T?o v?t t?" ? t?o ???c v?t t? m?i
- [ ] **Sua**: Có nút "S?a" ? s?a ???c v?t t?
- [ ] **Xoa**: Có nút "Xóa" ? xóa ???c v?t t?

#### V? Trí Kho
- [ ] **Index**: Xem ???c danh sách v? trí
- [ ] **Tao**: Có nút "T?o v? trí" ? t?o ???c v? trí m?i
- [ ] **Sua**: Có nút "S?a" ? s?a ???c v? trí
- [ ] **Xoa**: Có nút "Xóa" ? xóa ???c v? trí

#### Qu?n Lý Kho
- [ ] **Index**: Xem ???c danh sách kho
- [ ] **Tao**: Có nút "Thêm kho m?i" ? t?o ???c kho m?i
- [ ] **Sua**: Có nút "S?a" ? s?a ???c kho
- [ ] **Xoa**: Có nút "Xóa" ? xóa ???c kho

#### Qu?n Lý Ng??i Dùng
- [ ] **Index**: Xem ???c danh sách ng??i dùng
- [ ] **Tao**: Có nút "T?o ng??i dùng" ? t?o ???c tài kho?n
- [ ] **Edit**: Có nút "S?a" ? s?a ???c ng??i dùng
- [ ] **Delete**: Có nút "Xóa" ? xóa ???c ng??i dùng

#### T?n Kho, C?nh Báo, Báo Cáo
- [ ] Xem ???c t?n kho
- [ ] Xem ???c c?nh báo
- [ ] Xem ???c báo cáo

#### Account
- [ ] ??i m?t kh?u ???c

---

### Test 3??: QuanLyKho Permissions (thukho account)

#### Phi?u Nh?p Kho
- [ ] **Index**: Xem ???c danh sách phi?u nh?p
- [ ] **Tao**: Có nút "T?o phi?u nh?p" ? t?o ???c phi?u m?i
- [ ] **Sua**: Có nút "S?a" ? s?a ???c phi?u
- [ ] **Xoa**: ? KHÔNG có nút "Xóa" (403 AccessDenied n?u c? tình truy c?p)

#### Phi?u Xu?t Kho
- [ ] **Index**: Xem ???c danh sách phi?u xu?t
- [ ] **Tao**: Có nút "T?o phi?u xu?t" ? t?o ???c phi?u m?i
- [ ] **Sua**: Có nút "S?a" ? s?a ???c phi?u
- [ ] **Xoa**: ? KHÔNG có nút "Xóa" (403 AccessDenied n?u c? tình truy c?p)

#### V?t T?
- [ ] **Index**: Xem ???c danh sách v?t t?
- [ ] **Tao**: Có nút "T?o v?t t?" ? t?o ???c v?t t? m?i
- [ ] **Sua**: Có nút "S?a" ? s?a ???c v?t t?
- [ ] **Xoa**: ? KHÔNG có nút "Xóa" (403 AccessDenied n?u c? tình truy c?p)

#### V? Trí Kho
- [ ] **Index**: Xem ???c danh sách v? trí
- [ ] **Tao**: Có nút "T?o v? trí" ? t?o ???c v? trí m?i
- [ ] **Sua**: Có nút "S?a" ? s?a ???c v? trí
- [ ] **Xoa**: ? KHÔNG có nút "Xóa" (403 AccessDenied n?u c? tình truy c?p)

#### Qu?n Lý Kho
- [ ] **Index**: Xem ???c danh sách kho
- [ ] **Tao**: ? KHÔNG có nút "Thêm kho m?i" (403 AccessDenied n?u c? tình truy c?p)
- [ ] **Sua**: Có nút "S?a" ? s?a ???c kho
- [ ] **Xoa**: ? KHÔNG có nút "Xóa" (403 AccessDenied n?u c? tình truy c?p)

#### Qu?n Lý Ng??i Dùng
- [ ] **Index**: ? KHÔNG truy c?p ???c (403 AccessDenied)

#### T?n Kho, C?nh Báo, Báo Cáo
- [ ] Xem ???c t?n kho
- [ ] Xem ???c c?nh báo
- [ ] Xem ???c báo cáo

#### Account
- [ ] ??i m?t kh?u ???c

---

### Test 4??: NhanVien Permissions (nhanvien account)

#### Phi?u Nh?p Kho
- [ ] **Index**: Xem ???c danh sách phi?u nh?p
- [ ] **Xem**: Xem ???c chi ti?t phi?u
- [ ] **Tao**: ? KHÔNG có nút "T?o phi?u nh?p" (403 AccessDenied n?u c? tình truy c?p)
- [ ] **Sua**: ? KHÔNG có nút "S?a" (403 AccessDenied n?u c? tình truy c?p)
- [ ] **Xoa**: ? KHÔNG có nút "Xóa" (403 AccessDenied n?u c? tình truy c?p)

#### Phi?u Xu?t Kho
- [ ] **Index**: Xem ???c danh sách phi?u xu?t
- [ ] **Xem**: Xem ???c chi ti?t phi?u
- [ ] **Tao**: ? KHÔNG có nút "T?o phi?u xu?t" (403 AccessDenied n?u c? tình truy c?p)
- [ ] **Sua**: ? KHÔNG có nút "S?a" (403 AccessDenied n?u c? tình truy c?p)
- [ ] **Xoa**: ? KHÔNG có nút "Xóa" (403 AccessDenied n?u c? tình truy c?p)

#### V?t T?
- [ ] **Index**: Xem ???c danh sách v?t t?
- [ ] **Xem**: Xem ???c chi ti?t v?t t?
- [ ] **Tao**: ? KHÔNG có nút "T?o v?t t?" (403 AccessDenied n?u c? tình truy c?p)
- [ ] **Sua**: ? KHÔNG có nút "S?a" (403 AccessDenied n?u c? tình truy c?p)
- [ ] **Xoa**: ? KHÔNG có nút "Xóa" (403 AccessDenied n?u c? tình truy c?p)

#### V? Trí Kho
- [ ] **Index**: Xem ???c danh sách v? trí
- [ ] **Tao**: ? KHÔNG có nút "T?o v? trí" (403 AccessDenied n?u c? tình truy c?p)
- [ ] **Sua**: ? KHÔNG có nút "S?a" (403 AccessDenied n?u c? tình truy c?p)
- [ ] **Xoa**: ? KHÔNG có nút "Xóa" (403 AccessDenied n?u c? tình truy c?p)

#### Qu?n Lý Kho
- [ ] **Index**: Xem ???c danh sách kho
- [ ] **Tao**: ? KHÔNG có nút "Thêm kho m?i" (403 AccessDenied n?u c? tình truy c?p)
- [ ] **Sua**: ? KHÔNG có nút "S?a" (403 AccessDenied n?u c? tình truy c?p)
- [ ] **Xoa**: ? KHÔNG có nút "Xóa" (403 AccessDenied n?u c? tình truy c?p)

#### Qu?n Lý Ng??i Dùng
- [ ] **Index**: ? KHÔNG truy c?p ???c (403 AccessDenied)

#### T?n Kho, C?nh Báo, Báo Cáo
- [ ] Xem ???c t?n kho
- [ ] Xem ???c c?nh báo
- [ ] Xem ???c báo cáo

#### Account
- [ ] ??i m?t kh?u ???c

---

## ?? Security Testing (Nâng Cao)

### Brute Force Check
- [ ] Sau 5 l?n nh?p sai m?t kh?u, tài kho?n b? khóa 5 phút

### Direct URL Access
- [ ] Nhân viên c? tình truy c?p `/Admin/Delete/123` ? 403 Forbidden
- [ ] Nhân viên c? tình truy c?p `/NguoiDung/Index` ? 403 Forbidden
- [ ] QuanLyKho c? tình truy c?p `/QuanLyKho/Tao` (POST) ? 403 Forbidden (GET ???c nh?ng POST failed)

### Session Timeout
- [ ] Logout ? ngay l?p t?c không truy c?p ???c protected pages
- [ ] Session timeout sau 8 gi? (c?u hình trong Program.cs)

### CSRF Protection
- [ ] POST requests không có anti-forgery token ? 400 Bad Request

---

## ?? Notes

- Các ? items nên t?t c? ??u pass
- Các ? items nên ???c BLOCK (403 Forbidden ho?c AccessDenied page)
- N?u b?t k? test nào fail, hãy ki?m tra l?i `[Authorize(Roles = ...)]` attribute

