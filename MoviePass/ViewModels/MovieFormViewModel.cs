using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoviePass.Models;

namespace MoviePass.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movies { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
    }
}

