Hệ thống Quản lý Kho cho Xưởng Sản xuất (THUẦN AI)

![alt text](https://img.shields.io/badge/License-MIT-yellow.svg)


![alt text](https://img.shields.io/badge/status-in%20development-orange.svg)

Đây là dự án phần mềm quản lý kho vật tư được thiết kế dành riêng cho môi trường xưởng sản xuất. Hệ thống giúp số hóa và tối ưu hóa các quy trình nhập, xuất, kiểm kê vật tư, cung cấp báo cáo thống kê trực quan và hỗ trợ ra quyết định hiệu quả.

📖 Giới thiệu

Dự án được xây dựng nhằm giải quyết các vấn đề thường gặp trong quản lý kho thủ công như: sai sót dữ liệu, khó khăn trong việc theo dõi tồn kho, mất thời gian tìm kiếm vật tư và lập báo cáo. Hệ thống hướng tới mục tiêu quản lý tập trung, minh bạch và chính xác.

✨ Tính năng chính

Hệ thống bao gồm các phân hệ chức năng chính:

👤 Quản lý Người dùng & Phân quyền:

Đăng nhập, đăng xuất an toàn.

Quản lý tài khoản người dùng (quản trị viên, thủ kho, nhân viên).

Phân quyền chi tiết theo vai trò.

📥 Quản lý Nhập kho:

Lập phiếu nhập kho từ nhà cung cấp.

Cập nhật số lượng tồn kho tự động.

Gợi ý vị trí lưu trữ tối ưu.

Lưu trữ lịch sử nhập kho chi tiết.

📤 Quản lý Xuất kho:

Lập phiếu xuất vật tư cho sản xuất.

Kiểm tra tồn kho trước khi xuất.

Cập nhật số lượng tồn kho tự động.

Hỗ trợ tạo lộ trình soạn hàng (picking route).

📦 Quản lý Vật tư & Kho:

Quản lý danh mục vật tư (mã, tên, loại, đơn vị tính).

Quản lý danh mục kho, vị trí kệ/ô.

Theo dõi tồn kho theo thời gian thực.

Tìm kiếm vật tư nhanh chóng theo nhiều tiêu chí.

📊 Kiểm kê & Báo cáo:

Cảnh báo vật tư dưới mức tồn tối thiểu.

Báo cáo nhập/xuất kho theo ngày, tháng, năm.

Báo cáo tồn kho hiện tại.

Thống kê vật tư được nhập/xuất nhiều nhất.

🏛️ Kiến trúc hệ thống

Hệ thống được phát triển dựa trên kiến trúc 3 tầng (3-Tier) để đảm bảo tính module hóa, dễ bảo trì và mở rộng.

Tầng Giao diện (Presentation Layer):

Hiển thị thông tin cho người dùng.

Tiếp nhận các thao tác nhập liệu, tìm kiếm, cập nhật từ người dùng.

Được xây dựng dưới dạng ứng dụng web, truy cập qua trình duyệt.

Tầng Xử lý Nghiệp vụ (Business Logic Layer):

Thực thi các quy tắc nghiệp vụ cốt lõi của hệ thống.

Ví dụ: Kiểm tra tính hợp lệ của dữ liệu, tính toán tồn kho, xử lý logic nhập/xuất.

Tầng Dữ liệu (Data Layer):

Chịu trách nhiệm lưu trữ và truy xuất dữ liệu từ cơ sở dữ liệu.

Quản lý các thực thể như Vật tư, Kho, Phiếu nhập, Phiếu xuất, Người dùng.

Luồng hoạt động tổng quan:
code
Code
download
content_copy
expand_less
Người dùng -> Giao diện hệ thống -> Tầng Xử lý nghiệp vụ -> Tầng Dữ liệu (CSDL)
🛠️ Công nghệ sử dụng

(Bạn hãy điền các công nghệ thực tế đã sử dụng vào đây)

Backend: [Ví dụ: Java (Spring Boot), Node.js (Express), Python (Django)]

Frontend: [Ví dụ: React.js, Angular, Vue.js]

Cơ sở dữ liệu: [Ví dụ: MySQL, PostgreSQL, SQL Server]

Deployment: [Ví dụ: Docker, Nginx]

🗄️ Cấu trúc Cơ sở dữ liệu

Hệ thống bao gồm các thực thể chính sau:

NguoiDung (User): MaNguoiDung, TenDangNhap, MatKhau, HoTen, VaiTro

VatTu (Material): MaVatTu, TenVatTu, DonViTinh, SoLuongTon, MucTonToiThieu, MaKho, MaViTri

Kho (Warehouse): MaKho, TenKho, DiaDiem, NguoiPhuTrach

NhaCungCap (Supplier): MaNhaCungCap, TenNhaCungCap, DiaChi, SoDienThoai

PhieuNhap (Inbound Note): MaPhieuNhap, NgayNhap, MaNhaCungCap, MaNguoiDung

ChiTietPhieuNhap (Inbound Note Detail): MaPhieuNhap, MaVatTu, SoLuongNhap, DonGiaNhap

PhieuXuat (Outbound Note): MaPhieuXuat, NgayXuat, MaNguoiDung, BoPhanNhan

ChiTietPhieuXuat (Outbound Note Detail): MaPhieuXuat, MaVatTu, SoLuongXuat


Truy cập web:
Mở trình duyệt và truy cập vào http://localhost:5000 (hoặc cổng tương ứng).

