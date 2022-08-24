
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Entities;
using Models.ViewModels;

namespace Services.Interfaces
{
	public interface IUserService
	{


		Task<UserListViewModel> BuildUserListViewModel(Sorting sorting, Paging paging);
		Task<UserListViewModel> BuildInitialUserListViewModel();
		Task<PostUserViewModel> BuildCreateUserViewModel(PostUserViewModel? viewModel = null);
		Task<ValidationResult> ValidateCreateUserViewModel(PostUserViewModel viewModel);
		Task<PostUserViewModel> BuildEditUserViewModel(Guid userId);
		Task<ValidationResult> ValidateEditUserViewModel(PostUserViewModel viewModel);

		Task<ActionResult> AddUser(User user);
		Task<bool> EditUser(User user);
		Task<bool> Delete(User user);


	}
}
