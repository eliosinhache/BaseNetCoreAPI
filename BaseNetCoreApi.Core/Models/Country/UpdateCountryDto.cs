﻿using System.ComponentModel.DataAnnotations;

namespace BaseNetCoreAPI.Models.Country
{
    public class UpdateCountryDto : BaseCountryDto
    {
        [Required]
        public int Id { get; set; }
    }
}
