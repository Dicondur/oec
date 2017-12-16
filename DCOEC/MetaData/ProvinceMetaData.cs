using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DCOEC.Models
{
    [ModelMetadataType(typeof(ProvinceMetaData))]
    public partial class Province
    {
    }
    public class ProvinceMetaData
    {
        //public Province()
        //{
        //    Farm = new HashSet<Farm>();
        //}
        //[Required]
        [Display(Name = "Province Code (Key)")]
        //[Key]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}", ConvertEmptyStringToNull = true)]
        [ReadOnly(true)]
        //[HiddenInput(DisplayValue = true)]
        [StringLength(2, MinimumLength = 2)]
        //[RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
        //[DataType(DataType.EmailAddress)]
        //[Remote("OrderDateNotFuture", "Remotes")]

        // verify the order date is not in the future
        //public JsonResult OrderDateNotFuture(DateTime orderDate)
        //{
        //    Boolean isTodayOrBefore = orderDate <= DateTime.Now;
        //    return Json(isTodayOrBefore);
        //}

        //public JsonResult OrderDateNotInFuture(DateTime orderDate)
        //{
        //    if (orderDate <= DateTime.Now)
        //        return Json(true);
        //    else
        //        return Json("order date cannot be in the future");
        //}





        public string ProvinceCode { get; set; }


        public string Name { get; set; }


        [Display(Name = "Country Code")]
        public string CountryCode { get; set; }

        [Display(Name = "Country Code")]
        public Country CountryCodeNavigation { get; set; }

        public ICollection<Farm> Farm { get; set; }
    }
}
