using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Security.Policy;

namespace Cars_Web.cars.model
{
    [Table("cars")]
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id   { get;set;}

        [Required]
        [Column("Brand")]
        public string Brand { get; set; }


        [Required]
        [Column("Model")]
        public string Model { get; set; }

        [Required]
        [Column("Color")]
        public string Color { get; set; }

        [Required]
        [Column("Year")]

        public int Year { get; set; }















    }
}
