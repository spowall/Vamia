using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vamia.Domain.Models;

namespace Vamia.Web.Models
{
    public class RegisterViewModel : Model
    {
        [EmailAddress, Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, DataType(DataType.Password),MinLength(6, ErrorMessage = "Password must be at least six characters")]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), DisplayName("Confirm")]
        public string ConfirmPassword { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Password != ConfirmPassword)
            {
                yield return new ValidationResult("Passwords do not match", new[] { nameof(Password), nameof(ConfirmPassword) });
            }
        }
    }
}