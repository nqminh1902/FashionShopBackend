using FashionShopBL.BaseBL;
using FashionShopCommon;
using FashionShopCommon.Entities;
using FashionShopDL.BaseDL;
using FashionShopDL.ProductColorDL;
using FashionShopDL.ProductDL;
using FashionShopDL.ProductImageDL;
using FashionShopDL.ProductSizeDL;
using FashionShopDL.ProductVariantDL;
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
        private IProductColorDL _productColorDL;
        private IProductSizeDL _productSizeDL;
        private IProductVariantDL _productVariantDL;
        public ProductBL(IProductDL productDL, IProductImageDL productImageDL, IProductColorDL productColorDL, IProductSizeDL productSizeDL, IProductVariantDL productVariantDL) : base(productDL)
        {
            _productDL = productDL;
            _productImageDL = productImageDL;
            _productColorDL = productColorDL;
            _productSizeDL = productSizeDL;
            _productVariantDL = productVariantDL;
        }

        public override ServiceResponse InsertRecord(Product record)
        {
            int productID;
            // Thực hiện gọi làm thêm bản ghi và trả về kết quả
            var product = _productDL.InsertRecord(record);
            if(product.Success == true)
            {
                productID = (int)product.Data;
                record.ProductID = productID;
                //Insert ảnh sản phẩm
                if (record.ProductImages?.Count > 0)
                {
                    foreach (var image in record.ProductImages)
                    {
                        if (product.Data != null)
                        {
                            image.ProductID = productID;
                        }
                    }
                    var imageResponse = _productImageDL.InsertProductImage(record.ProductImages);
                    if(imageResponse.Success == false) 
                    {
                        return imageResponse;
                    }
                }
                if(record.ProductVariants?.Count > 0)
                {

                    var response  =  _productVariantDL.InsertMultipleProductVariant(productID, record.ProductVariants);
                    if (response.Success == false)
                    {
                        return response;
                    }
                }

            }
            return new ServiceResponse()    
            {
                Success = true,
                Data = record
            };
        }
    }
}
