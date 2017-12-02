using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vamia.Domain.Models
{
    public class ProductModel : Model
    {
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }

        public string ImageUrl => Images.Select(i => i.Url).FirstOrDefault();

        public virtual ICollection<ImageModel> Images { get; set; } = new HashSet<ImageModel>();


        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Price < 0)
            {
                yield return new ValidationResult("Price cannot be less than Zero", new[] { nameof(Price) });
            }

            if (Stock < 0)
            {
                yield return new ValidationResult("Stock cannot be less than Zero", new[] { nameof(Stock) });
            }
        }
    }
}
