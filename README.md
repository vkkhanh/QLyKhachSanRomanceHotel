# 🏨 HỆ THỐNG QUẢN LÝ KHÁCH SẠN – ROMANCE HOTEL

## 📌 Giới thiệu

Hệ thống Quản lý Khách sạn Romance Hotel được xây dựng nhằm hỗ trợ toàn diện các nghiệp vụ như quản lý phòng, đặt phòng, khách hàng, nhân viên, dịch vụ, hóa đơn, thống kê doanh thu và sao lưu – phục hồi dữ liệu. Giao diện được thiết kế trực quan, dễ sử dụng, phù hợp với môi trường làm việc thực tế tại khách sạn.
## 🎯 Mục tiêu dự án

- Xây dựng hệ thống quản lý khách sạn hiện đại, ổn định và dễ sử dụng
- Tối ưu hóa quy trình đặt phòng và thanh toán
- Chuẩn hóa cơ sở dữ liệu đảm bảo tính toàn vẹn và bảo mật
- Hỗ trợ thống kê – báo cáo nhanh chóng, chính xác
- Nâng cao trải nghiệm làm việc của nhân viên và trải nghiệm lưu trú của khách hàng


## 🛠 Công nghệ sử dụng

- **Ngôn ngữ lập trình:** C#.NET
- **Giao diện:** Windows Forms
- **Cơ sở dữ liệu:** SQL Server
- **Mô hình phát triển:** Phân tích & Thiết kế Hệ thống Thông tin
- **Thiết kế CSDL:** Chuẩn hóa dữ liệu (Normalization)

## 📂 Chức năng chính

### 🔹 1. Quản lý phòng
- Theo dõi mã phòng, loại phòng, tình trạng, giá thuê
- Cập nhật trạng thái phòng (Trống / Đã đặt / Đang sử dụng)

### 🔹 2. Quản lý loại phòng
- Phân loại phòng (Đơn, Đôi, VIP,...)
- Thiết lập mức giá và tiện nghi đi kèm

### 🔹 3. Quản lý đặt phòng
- Kiểm tra phòng trống
- Tạo / chỉnh sửa / hủy đặt phòng
- Tránh trùng phòng trong cùng thời gian

### 🔹 4. Quản lý khách hàng
- Lưu trữ thông tin khách hàng
- Hỗ trợ tra cứu lịch sử lưu trú

### 🔹 5. Quản lý nhân viên
- Quản lý hồ sơ nhân viên
- Phân quyền truy cập hệ thống

### 🔹 6. Quản lý dịch vụ
- Quản lý các dịch vụ: giặt ủi, ăn uống, spa, thuê xe,...
- Cập nhật giá dịch vụ

### 🔹 7. Quản lý hóa đơn
- Tính tiền phòng + dịch vụ phát sinh
- In hóa đơn cho khách hàng
- Lưu trữ lịch sử thanh toán

### 🔹 8. Thống kê – Báo cáo
- Thống kê doanh thu theo thời gian
- Thống kê theo loại phòng
- Xuất báo cáo phục vụ quản lý

### 🔹 9. Sao lưu – Phục hồi dữ liệu
- Backup cơ sở dữ liệu
- Khôi phục khi có sự cố

### 🔹 10. Chatbot AI hỗ trợ nội bộ
- Hỗ trợ tìm kiếm thông tin
- Soạn thảo email / văn bản / tin nhắn

## 🗄 Thiết kế hệ thống

Hệ thống được phân tích và thiết kế theo các mô hình:

- Sơ đồ ngữ cảnh
- Sơ đồ Use Case
- Sơ đồ ERD (Entity Relationship Diagram)
- Sơ đồ lớp (Class Diagram)
- Sơ đồ tuần tự (Sequence Diagram)


## 🔐 Phân quyền hệ thống

Hệ thống hỗ trợ phân quyền theo vai trò:

- 👑 Quản lý
- 👨‍💼 Nhân viên

Mỗi vai trò có quyền truy cập chức năng khác nhau nhằm đảm bảo tính bảo mật và phù hợp nghiệp vụ.



## 📎 Hướng dẫn chạy dự án


1. Mở file `.sln` bằng Visual Studio

2. Cấu hình chuỗi kết nối SQL Server trong file cấu hình

3. Restore database

4. Chạy chương trình

---

## 📜 License

Dự án phục vụ mục đích học tập và nghiên cứu.
