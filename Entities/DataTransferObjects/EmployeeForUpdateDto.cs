﻿using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class EmployeeForUpdateDto : EmployeeForManipulationDto
    {
        [Required(ErrorMessage ="Employee name is a required field.")]
        [MaxLength(30,ErrorMessage ="Maximum length for the Name is 30 characters.")]
        public string Name { get; set; }

        [Range(18,int.MaxValue, ErrorMessage ="Age is a required field and it can't  be lower than 18")]
        public int Age { get; set; }

        [Required(ErrorMessage ="Employee position is a required field.")]
        [MaxLength(20,ErrorMessage ="Maximum length for the Position is 20 characters.")]
        public string Position { get; set; }
    }
}
