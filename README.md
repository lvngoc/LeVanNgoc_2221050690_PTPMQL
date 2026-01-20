1. Cấu trúc của project .NET MVC
A. Controlers :
- Tên của Controller bắt buộc phải có phần hậu tố Controller: Ví dụ StudentController, PersonController
- Nằm trong thư mục Controllers
- Nhiệm vụ của Controller:
  Xử lý các yêu cầu của người dùng gửi tới từ View.
  Truy xuất dữ liệu trong cơ sở dữ liệu.
  Gọi các mẫu View và trả về dữ liệu
B. Models:
- Nằm trong thư mục Models
- Nhiệm vụ của Models:
  Chứa các lớp đại diện cho dữ liệu và các quy tắc nghiệp vụ.
  Tương tác với cơ sở dữ liệu thông qua Entity Framework hoặc các công cụ ORM khác.
C. View:
- Nằm trong thư mục Views
- Nhiệm vụ của View:
  Hiển thị dữ liệu cho người dùng.
  Chứa các tệp Razor (.cshtml) để tạo giao diện người dùng.
D. wwwroot:
- Nằm trong thư mục wwwroot
- Nhiệm vụ của wwwroot:
  Chứa các tệp tĩnh như CSS, JavaScript, hình ảnh.
  Đây là thư mục gốc để phục vụ các tài nguyên tĩnh cho ứng dụng web.
E. appsetting.js và Profram.cs:
- Nằm trong thư mục gốc của project
- Nhiệm vụ:
   appsetting.js : chứa các cấu hình ứng dụng như chuỗi kết nỗi cơ sở dữ liệu, cài đặt dịch vụ.
    Profram.cs : là điểm khởi đầu của ứng dụng, nơi cấu hình các dịch vụ và middleware.

2. Định tuyến (Route) trong .Net MVC .
- MVC sẽ gọi bộ điều khiển (Controller) và các hành động bên trong (Action) thông qua URL
- Logic định tuyến MVC sử dụng dạng: /[Controller]/[Action]/[Parameters]
- Định tuyến được cấu hình trong file Program.cs: 
- Ví dụ về định tuyến mặc định:
  app.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}/{id?}");
- Trong đó: 
controller=Home :Nếu không có controller nào được chỉ định trong URL, nó sẽ sử dụng HomeController
action=Index :Nếu không có action nào được chỉ định trong URL, nó sẽ sử dụng phương thức Index
id: tham số tùy chọn và có thể được sử dụng để truyền dữ liệu bổ dung cho action.

3. Controller và View giữ vai trò quan trọng trong việc xử lý yêu cầu và hiển thị giao diện người dùng.

- Controller là thành phần tiếp nhận các yêu cầu từ trình duyệt, thực hiện xử lý logic và điều phối dữ liệu. Controller có thể gọi Model để lấy hoặc xử lý dữ liệu, sau đó trả kết quả về cho View. Mỗi phương thức public trong Controller được gọi là một Action, đại diện cho một chức năng cụ thể của ứng dụng.

- View là thành phần đảm nhiệm việc hiển thị giao diện. View nhận dữ liệu do Controller gửi sang và trình bày dưới dạng HTML bằng cú pháp Razor. View không chứa logic xử lý nghiệp vụ mà chỉ tập trung vào việc hiển thị thông tin cho người dùng.

- Sự tách biệt rõ ràng giữa Controller và View giúp ứng dụng web có cấu trúc mạch lạc, dễ bảo trì và thuận tiện cho việc phát triển, mở rộng trong tương lai.