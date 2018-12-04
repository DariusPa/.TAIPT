using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApp.Models
{
    public class BookViewModel
    {
        [Required(ErrorMessage = "The title is required")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The isbn is required")]
        [Display(Name = "ISBN")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Display(Name = "Quantity")]
        public string Qty { get; set; }

        [Required(ErrorMessage = "Pages number is required")]
        [Display(Name = "Pages")]
        public string Pages { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        public string[] Genre { get; set; }

        //public IEnumerable<SelectListItem> Author { get; set; }
        //public IEnumerable<SelectListItem> Publisher { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }

        public string Description { get; set; }
    }

    public class AuthorViewModel
    {
        [Required(ErrorMessage = "The name is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The surname is required")]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "The country is required")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        public string Description { get; set; }
    }

    public class PublisherViewModel
    {
        [Required(ErrorMessage = "The name is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public string Country { get; set; }

        public string Description { get; set; }
    }
}