using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DCOEC.Models
{

    [ModelMetadataType(typeof(FarmMetaData))]
    public partial class Farm : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield return ValidationResult.Success;
        }
    }
    public class FarmMetaData
    {
        public int FarmId { get; set; }

        [Required(ErrorMessage = "Farm name missing")]
        [StringLength(50)]
        [Display(Name = "Farm Name")]
        [Remote("DCCapitalize", "Remotes")]
        public string Name { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Town { get; set; }

        [StringLength(50)]
        public string County { get; set; }

       
        [Required(ErrorMessage = "Province missing")]
        //[StringLength(2,MinimumLength =2)]
        public string ProvinceCode { get; set; }

        [StringLength(7)]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z] ?\d[A-Za-z]\d$",
               ErrorMessage = "the {0} is not a valid Canadian pattern")]

        public string PostalCode { get; set; }

        [Display(Name = "Home Phone")]
        [StringLength(50)]
        public string HomePhone { get; set; }
        [StringLength(50)]
        public string CellPhone { get; set; }
        [StringLength(250)]
        public string Email { get; set; }
        public string Directions { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Date Joined")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d MMM, yyyy}")]
        public DateTime? DateJoined { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Last Contact")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d MMM, yyyy}")]
        public DateTime? LastContactDate { get; set; }


        [Display(Name = "Province")]
        public Province ProvinceCodeNavigation { get; set; }
        public ICollection<Plot> Plot { get; set; }
    }
}
