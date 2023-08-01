using Imagekit;
using Imagekit.Sdk;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FashionShopCommon;
using System.Security.Policy;

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
        public async Task<IActionResult> UploadImage(List<IFormFile> files)
        {
            try
            {
                if (files.Count > 0)
                {
                    var url = new List<string>();
                    foreach (IFormFile file in files)
                    {

                        // Gọi ImageKitService để upload ảnh lên ImageKit
                        //var response = await UploadImageAsync(file);
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
                            fileName = file.FileName,
                            folder = "/products/"
                        };

                        // Thực hiện yêu cầu upload ảnh lên ImageKit
                        var response = await _imageKitClient.UploadAsync(fileCreateRequest);
                        url.Add(response.thumbnailUrl);
                    }
                    return StatusCode(StatusCodes.Status200OK, url);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                    {
                        ErrorCode = ErrorCode.Exception,
                        DevMsg = Resources.DevMsg_Exception,
                        UserMsg = Resources.UserMsg_Exception,
                        MoreInfo = Resources.MoreInfo_Exception,
                        TraceId = HttpContext.TraceIdentifier
                    });
                }

                // Trả về đường dẫn (URL) của ảnh đã upload
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
    }
}
