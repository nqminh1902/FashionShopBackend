using FashionShopBL.BaseBL;
using FashionShopCommon;
using FashionShopCommon.Entities;
using FashionShopDL.BaseDL;
using FashionShopDL.ProductDL;
using FashionShopDL.ProductImageDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.ProductBL
{
    public class ProductBL : BaseBL<Product>, IProductBL
    {
        private IProductDL _productDL;
        private IProductImageDL _productImageDL;
        public ProductBL(IProductDL productDL, IProductImageDL productImageDL) : base(productDL)
        {
            _productDL = productDL;
            _productImageDL = productImageDL;
        }

        public override ServiceResponse InsertRecord(Product record)
        {
            ServiceResponse imageResponse = new ServiceResponse() { Success = false};
            //// Thực hiện gọi làm thêm bản ghi và trả về kết quả
            //var product = _productDL.InsertRecord(record);
            //if(product.Success == true)
            //{
                //Insert ảnh sản phẩm
                if(record.ProductImages.Count > 0)
                {
                    //foreach (var image in record.ProductImages)
                    //{
                    //    if (product.Data != null)
                    //    {
                    //        image.ProductID = (int)product.Data;
                    //    }
                    //}
                    imageResponse = _productImageDL.InsertProductImage(record.ProductImages);
                    if(imageResponse.Success == false) 
                    {
                        return new ServiceResponse()
                        {
                            Success = false,
                            Data = null
                        };
                    }
                }
            //}
            return new ServiceResponse()
            {
                Success = false,
                Data = null
            };
        }
    }
}
