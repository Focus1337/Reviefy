﻿using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Reviefy.Helpers;
using Reviefy.Models;

namespace Reviefy.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDataConnection _connection;
        public UserController(AppDataConnection connection) => _connection = connection;

        private List<Movie> GetMoviesList() =>
            _connection.Movie.OrderByDescending(x => x.ReleaseDate).ToList();

        // GET
        public IActionResult UserProfile(Guid id)
        {
            if (_connection.User.All(x => x.UserId != id))
                return RedirectToAction("PageNotFound", "Home");

            var viewModel = new ViewModel
            {
                Movies = GetMoviesList(),
                Reviews = _connection.Review
                    .Where(x => x.UserId == id)
                    .OrderByDescending(x => x.ReviewDate).ToList(),

                UserById = _connection.User.FirstOrDefault(x => x.UserId == id)
            };

            return View("UserProfile", viewModel);
        }

        public IActionResult ResetAvatar()
        {
            var user = _connection.User.FirstOrDefault(u => u.UserId == GetUserBySession().UserId);

            if (user != null)
            {
                user.AvatarPath = "https://i.imgur.com/dNOjQWC.png";
                _connection.Update(user);
            }
            
            return NoContent();
        }

        public IActionResult MyProfile()
        {
            if (!UserExistInSession())
                return RedirectToAction("PageNotFound", "Home");

            // var viewModel = new ViewModel
            // {
            //     Movies = GetMoviesList(),
            //     Reviews = _connection.Review
            //         .Where(x => x.UserId == GetUserBySession().UserId)
            //         .OrderByDescending(x => x.ReviewDate).ToList(),
            //
            //     UserById = GetUserBySession()
            // };

            return View("MyProfile"); //, viewModel);
        }

        private bool UserExistInSession() => 
            HttpContext.Session.Keys.Contains("user");

        private User GetUserBySession() => 
            HttpContext.Session.Get<User>("user");
    }
}