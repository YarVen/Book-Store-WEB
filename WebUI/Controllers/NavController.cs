﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Domain.Abstract;

namespace WebUI.Controllers
{
    public class NavController : Controller
    {
        private IBookRepository repository;

        public NavController(IBookRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string genre = null)
        {
            ViewBag.SelectedGenre = genre;

            IEnumerable<string> genres = repository.Books
                .Select(book => book.Genre)
                .Distinct().OrderBy(x => x);

            return PartialView(genres);
        }
    }
}