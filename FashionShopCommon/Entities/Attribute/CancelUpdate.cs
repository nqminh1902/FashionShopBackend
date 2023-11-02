using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities.Attribute
{
    public class CancelUpdate : ValidationAttribute
    {
        /// <summary>
        /// Attribute key cho của đối tượng table detail
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns>Trả về thành công</returns>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return ValidationResult.Success;
        }

    }
}
