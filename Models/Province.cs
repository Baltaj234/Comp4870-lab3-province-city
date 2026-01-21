using System;
using System.ComponentModel.DataAnnotations;


namespace lab3_province_city.Models
{
public class Province
    {
        [Key]
        [Display(Name = "Province Code")]
        public string ProvinceCode { get; set; }

        [Required]
        [Display(Name = "Province")]
        public string ProvinceName { get; set; }

       // province has a list of cities
        public ICollection<City> Cities { get; set; }
    }
}