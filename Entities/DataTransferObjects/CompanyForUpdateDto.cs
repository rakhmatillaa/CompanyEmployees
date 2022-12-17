using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class CompanyForUpdateDto : CompanyForManipulationDto
    {
        [Required(ErrorMessage ="Company name is a required field.")]
        [MaxLength(60,ErrorMessage="Maximum length for the Name is 60 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Address is a required field.")]
        [MaxLength(60,ErrorMessage ="Maximum length for the Address is 60 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage ="Country is a required field.")]
        public string Country { get; set; }
    }
}
