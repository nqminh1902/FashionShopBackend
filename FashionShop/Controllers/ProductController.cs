using FashionShopBL.BaseBL;
using FashionShopCommon;
using FashionShopCommon.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController<Product>
    {
        private readonly IWebHostEnvironment _environment;

        public ProductController(IBaseBL<Product> baseBL, IWebHostEnvironment environment) :base(baseBL) 
        {
            _environment = environment;
        }

        //[HttpPost("UploadImage")]
        //public async Task<IActionResult> UploadImage()
        //{
        //    bool Results = false;
        //    try
        //    {
        //        var _uploadedfiles = Request.Form.Files;
        //        foreach (IFormFile source in _uploadedfiles)
        //        {
        //            string Filename = source.FileName;
        //            string Filepath = GetFilePath(Filename);

        //            if (!System.IO.Directory.Exists(Filepath))
        //            {
        //                System.IO.Directory.CreateDirectory(Filepath);
        //            }

        //            string imagepath = Filepath + "\\image.png";

        //            if (System.IO.File.Exists(imagepath))
        //            {
        //                System.IO.File.Delete(imagepath);
        //            }
        //            using (FileStream stream = System.IO.File.Create(imagepath))
        //            {
        //                await source.CopyToAsync(stream);
        //                Results = true;
        //            }
        //        }
        //        return Ok(Results);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpGet("RemoveImage/{code}")]
        //public IActionResult RemoveImage(string code)
        //{
        //    string Filepath = GetFilePath(code);
        //    string Imagepath = Filepath + "\\image.png";
        //    try
        //    {
        //        if (System.IO.File.Exists(Imagepath))
        //        {
        //            System.IO.File.Delete(Imagepath);
        //        }

        //        var response = new ServiceResponse()
        //        {
        //            Success = true
        //        };

        //        return StatusCode(StatusCodes.Status200OK, response);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
        //        {
        //            ErrorCode = ErrorCode.Exception,
        //            DevMsg = Resources.DevMsg_Exception,
        //            UserMsg = Resources.UserMsg_Exception,
        //            MoreInfo = Resources.MoreInfo_Exception,
        //            TraceId = HttpContext.TraceIdentifier
        //        });
        //    }
        //}

        

        [HttpPost]
        [Route("upload-image")]
        public async Task<IActionResult> UploadImage(List<IFormFile> images)
        {
            //Xử lý ảnh
            if(images.Count > 0)
            {
                var listImage = new List<string>();
                foreach (var image in images)
                {
                    string HostUrl = "https://localhost:7236/";
                    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", "products", image.FileName);
                    using (var stream = System.IO.File.Create(path))
                    {
                        await image.CopyToAsync(stream);
                    }
                    var imageUrl = HostUrl + "/products/" + image.FileName;
                    listImage.Add(imageUrl);
                }
                return StatusCode(StatusCodes.Status200OK, listImage);
            }
            else
            {

                return StatusCode(StatusCodes.Status400BadRequest);
            }

        }
       
    }
}
