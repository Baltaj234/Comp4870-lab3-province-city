using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace lab3_province_city.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required]
        [Display(Name = "City")]
        public string CityName { get; set; }

        public int Population { get; set; }

        // Foreign Key
        [Required]
        [Display(Name = "Province")]
        public string ProvinceCode { get; set; }

       
        [ForeignKey("ProvinceCode")]
        [ValidateNever]
        public Province Province { get; set; }
    }

}