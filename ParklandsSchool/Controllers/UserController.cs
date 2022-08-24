using System;
using Data;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Entities;
using Models.ViewModels;
using ParklandsSchool.Extensions;
using Services.Interfaces;

namespace ParklandsSchool.Controllers
{
    public class UserController : Controller 
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, ParklandsSchoolContext parklandsSchoolContext, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }


        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var userList = await _userService.BuildInitialUserListViewModel();

            return View(userList);
        }


        // GET: /<controller>/
        public async Task<IActionResult> Create()
        {
            var viewModel = await _userService.BuildCreateUserViewModel();
            return View(viewModel);
        }

        // GET: /<controller>/
        public async Task<IActionResult> SortUserResultsTable(Sorting sorting, Paging paging)
        {


            var userList = await _userService.BuildUserListViewModel(sorting, paging);
            return PartialView("_UserResults", userList.UserResults);

        }

        [HttpPost]
        public async Task<IActionResult> Create(PostUserViewModel viewModel, User user)
        {

            var result = await _userService.ValidateCreateUserViewModel(viewModel);
            if (!result.IsValid)
            {
                viewModel = await _userService.BuildCreateUserViewModel(viewModel);
                result.AddToModelState(this.ModelState);
                return View(viewModel);
            }

            await _userService.AddUser(user);

            return Redirect("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid userId)
        {
            PostUserViewModel viewModel = await _userService.BuildEditUserViewModel(userId);

            return View(viewModel);

        }


        [HttpPost]
        public async Task<IActionResult> Edit(PostUserViewModel viewModel)
        {

            var result = await _userService.ValidateEditUserViewModel(viewModel);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View(viewModel);
            }

            if (!await _userService.EditUser(viewModel.User))
            {
                return View(viewModel);
            }


            return Redirect("Index");
        }




        [HttpPost]
        public async Task<IActionResult> Delete(User user)
        {

            await _userService.Delete(user);

            return Redirect("Index");


        }

    }
}


