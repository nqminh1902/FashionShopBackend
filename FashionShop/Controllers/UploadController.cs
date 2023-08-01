using Imagekit;
using Imagekit.Sdk;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FashionShopCommon;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly ImagekitClient _imageKitClient;
        public UploadController(IConfiguration configuration)
        {
            // Đọc các thông tin cấu hình từ appsettings.json
            string publicKey = configuration["ImageKit:PublicKey"];
            string privateKey = configuration["ImageKit:PrivateKey"];
            string urlEndpoint = configuration["ImageKit:UrlEndpoint"];

            // Tạo ImageKitClient với thông tin cấu hình
            _imageKitClient = new ImagekitClient(publicKey, privateKey, urlEndpoint);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("Không tìm thấy file hoặc file rỗng.");
                }

                // Gọi ImageKitService để upload ảnh lên ImageKit
                var response = await UploadImageAsync(file);

                if (response == null)
                {
                    return BadRequest("Lỗi khi upload ảnh.");
                }

                // Trả về đường dẫn (URL) của ảnh đã upload
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = ErrorCode.Exception,
                    DevMsg = Resources.DevMsg_Exception,
                    UserMsg = Resources.UserMsg_Exception,
                    MoreInfo = Resources.MoreInfo_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        public async Task<Result> UploadImageAsync(IFormFile file)
        {
            try
            {
                // Chuyển IFormFile sang dạng byte array
                byte[] fileBytes;
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    fileBytes = memoryStream.ToArray();
                }

                // Tạo đối tượng FileCreateRequest để truyền vào phương thức UploadAsync
                var fileCreateRequest = new FileCreateRequest()
                {
                    file = fileBytes,
                    fileName = file.FileName
                };

                // Thực hiện yêu cầu upload ảnh lên ImageKit
                var uploadResponse = await _imageKitClient.UploadAsync(fileCreateRequest);

                // Trả về đường dẫn (URL) của ảnh đã upload
                return uploadResponse;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
