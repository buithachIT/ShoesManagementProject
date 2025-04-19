# 👟 Shoes Management System

**ShoesManagementProject** là hệ thống quản lý bán giày đa nền tảng bao gồm:
- **WebApp**: Dành cho khách hàng đặt hàng trực tuyến
- **AdminApp (WinForms)**: Dành cho quản trị viên quản lý sản phẩm, đơn hàng, người dùng...

---

## 📦 Công nghệ sử dụng

| Thành phần       | Công nghệ             |
|------------------|------------------------|
| Web Frontend     | ASP.NET Core MVC       |
| Desktop App      | WinForms (.NET 4.7.2)  |
| Cơ sở dữ liệu    | MySQL                  |
| ORM              | Entity Framework Core  |
| UI Web           | Bootstrap 5            |
| Quản lý mã nguồn | Git / GitHub           |

---

## ⚙️ Cài đặt & chạy dự án

### 1. Cơ sở dữ liệu

- Import file `shoes_web.sql` vào MySQL
- Database tên: `shoes_web`

### 2. WebApp (ASP.NET Core)

- Mở solution `ShoesManagementProject.sln`
- Cấu hình chuỗi kết nối trong `WebApp/appsettings.json`
- Set `WebApp` làm Startup Project → nhấn `F5` để chạy

### 3. AdminApp (WinForms)

- Mở `Form1.cs` hoặc bất kỳ form nào trong AdminApp
- Kiểm tra chuỗi kết nối trong các file `.cs`
- Set `AdminApp` làm Startup Project → nhấn `F5` để chạy

---

## ✨ Các chức năng nổi bật

### WebApp
- Đăng nhập / Đăng ký
- Duyệt sản phẩm, lọc theo brand, size, màu
- Thêm sản phẩm vào giỏ hàng
- Đặt hàng và theo dõi đơn hàng
- Quản lý địa chỉ người dùng

### AdminApp
- Quản lý sản phẩm và biến thể (size, màu)
- Quản lý người dùng, đơn hàng
- Upload ảnh theo màu cho từng biến thể
- Quản lý size, màu, brand, dòng sản phẩm

---

## 🖼️ Giao diện demo



---

## 🧪 Kiểm thử

- Đã thực hiện hơn 100 test case (Web + Admin)
- Tỷ lệ pass > 85%
- Hiệu suất tốt, phản hồi nhanh, dễ triển khai thực tế

---

## 📄 Tài liệu đi kèm

- [x] Báo cáo đầy đủ theo chuẩn trường
- [x] Sơ đồ ERD, Flowchart, UML Use Case, Class Diagram
- [x] Hướng dẫn cài đặt, test chức năng

---

## 🙌 Tác giả

- Họ tên: **Bùi Công Thạch** 
---

