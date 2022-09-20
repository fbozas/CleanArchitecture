using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CleanArchitecture.MVC.Dtos
{
    public class PostDto
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
    }
}