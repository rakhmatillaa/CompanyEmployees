﻿using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class EmployeeForCreationDto : EmployeeForManipulationDto
    {
        [Required(ErrorMessage ="Employee name is a required field.")]
        [MaxLength(30, ErrorMessage ="Maximum length for the Name is 30 characters.")]
        public string Name { get; set; }

        [Range(18,int.MaxValue, ErrorMessage ="Age is required and it can't be lower than 18")]
        public int Age { get; set; }

        [Required(ErrorMessage="Position is a required filed.")]
        [MaxLength(20,ErrorMessage ="Maximum length for the Position is 20 charcters.")]
        public string Position { get; set; }
    }
}
