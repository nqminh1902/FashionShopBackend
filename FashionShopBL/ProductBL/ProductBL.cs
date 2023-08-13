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
            ServiceResponse colorResponse = new ServiceResponse() { Success = false};
            ServiceResponse sizeResponse = new ServiceResponse() { Success = false};
            int productID;
            // Thực hiện gọi làm thêm bản ghi và trả về kết quả
            var product = _productDL.InsertRecord(record);
            if(product.Success == true)
            {
                productID = (int)product.Data;
                //Insert ảnh sản phẩm
                if (record.ProductImages.Count > 0)
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
                //Insert màu sản phẩm
                if (record.ProductColors.Count > 0)
                {
                    foreach (var color in record.ProductColors)
                    {
                        color.ProductID = productID;
                    }
                    colorResponse = _productColorDL.InsertMultipleRecord(record.ProductColors);
                    if (colorResponse.Success == false)
                    {
                        return colorResponse;
                    }
                }
                //Insert kích cỡ sản phẩm
                if (record.ProductSizes.Count > 0)
                {
                    foreach (var size in record.ProductSizes)
                    {
                        size.ProductID = productID;
                    }
                    sizeResponse = _productSizeDL.InsertMultipleRecord(record.ProductSizes);
                    if (colorResponse.Success == false)
                    {
                        return colorResponse;
                    }
                }
                // Insert biết thể sản phẩm
                if(record.ProductSizes.Count > 0 || record.ProductColors.Count > 0)
                {       
                    var productVariantResponse = _productVariantDL.InsertMultipleProductVariant(productID);
                }

            }
            return new ServiceResponse()
            {
                Success = false,
                Data = null
            };
        }
    }
}
