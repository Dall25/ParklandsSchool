
using AutoMapper;
using Data;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Entities;
using Models.ViewModels;
using Services.Interfaces;

namespace Services.Implementation
{
    public class UserService : BaseService, IUserService
    {
        private readonly IValidator<PostUserViewModel> _validator;
        private readonly IMapper _mapper;

        public UserService(ParklandsSchoolContext parklandsSchoolContext, IValidator<PostUserViewModel> validator, IMapper mapper) : base(parklandsSchoolContext)
        {
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<UserListViewModel> BuildInitialUserListViewModel()
        {
            var viewModel = new UserListViewModel
            {
                UserResults = await GetInitialUserResults()
            };

            return viewModel;

        }

        public async Task<UserListViewModel> BuildUserListViewModel(Sorting sorting, Paging paging)
        {
            var viewModel = new UserListViewModel
            {
                UserResults = await GetUserResults(sorting, paging)
            };

            return viewModel;

        }

        private async Task<UserResults> GetInitialUserResults()
        {
            var recordCount = await _parklandsSchoolContext.User.CountAsync();
            var sorting = new Sorting
            {
                SortColumn = 1,
                SortDirection = "asc"
            };

            Paging paging = new Paging
            {
                RecordsToSkip = 0,
                RecordsToSelect = 10,
                RecordCount = recordCount,
                NumberOfPages = (recordCount / 1),
                CurrentPage = 1

            };

            UserResults userResults = new UserResults
            {

                Users = await SortUserResults(sorting, paging),
                Sorting = sorting,
                Paging = paging

            };
            return userResults;
        }

        private async Task<int> CalculateRecordsToSkip(int recordsToSelect, int currentPage)
        {
            if (currentPage == 1)
            {
                return 0;
            }
            else
            {
                return (currentPage - 1) * recordsToSelect;
            }

        }
        private async Task<UserResults> GetUserResults(Sorting? sorting = null, Paging? paging = null)
        {
            if (sorting == null)
            {
                sorting.SortColumn = 1;
                sorting.SortDirection = "asc";
            }
            if (paging.CurrentPage == 0)
            {
                paging.CurrentPage = 1;
            }

            var recordCount = await _parklandsSchoolContext.User.CountAsync();
            paging.RecordsToSelect = 10;
            paging.RecordCount = recordCount;
            paging.NumberOfPages = (recordCount / 1);
            // paging.CurrentPage = paging.CurrentPage;
            paging.RecordsToSkip = await CalculateRecordsToSkip(1, paging.CurrentPage);

            UserResults userResults = new UserResults
            {
                Users = await SortUserResults(sorting, paging),
                Paging = paging,
                Sorting = sorting
            };
            return userResults;
        }

        private async Task<List<User>> SortUserResults(Sorting sorting, Paging paging)
        {
            var users = new List<User>();

            if (sorting.SortDirection == "asc")
            {
                switch (sorting.SortColumn)
                {
                    case 1:
                        users = await _parklandsSchoolContext.User.Include(a => a.UserType).Include(a => a.YearGroup).OrderBy(a => a.FirstName).Skip(paging.RecordsToSkip).Take(paging.RecordsToSelect).ToListAsync();
                        break;
                    case 2:
                        users = await _parklandsSchoolContext.User.Include(a => a.UserType).Include(a => a.YearGroup).OrderBy(a => a.LastName).Skip(paging.RecordsToSkip).Take(paging.RecordsToSelect).ToListAsync();
                        break;
                    case 3:
                        users = await _parklandsSchoolContext.User.Include(a => a.UserType).Include(a => a.YearGroup).OrderBy(a => a.UserType).Skip(paging.RecordsToSkip).Take(paging.RecordsToSelect).ToListAsync();
                        break;
                    case 4:
                        users = await _parklandsSchoolContext.User.Include(a => a.UserType).Include(a => a.YearGroup).OrderBy(a => a.YearGroup.Name).Skip(paging.RecordsToSkip).Take(paging.RecordsToSelect).ToListAsync();
                        break;
                    default:
                        users = await _parklandsSchoolContext.User.Include(a => a.UserType).Include(a => a.YearGroup).OrderBy(a => a.FirstName).Skip(paging.RecordsToSkip).Take(paging.RecordsToSelect).ToListAsync();
                        break;
                }
            }
            else
            {
                switch (sorting.SortColumn)
                {
                    case 1:
                        users = await _parklandsSchoolContext.User.Include(a => a.UserType).Include(a => a.YearGroup).OrderByDescending(a => a.FirstName).Skip(paging.RecordsToSkip).Take(paging.RecordsToSelect).ToListAsync();
                        break;
                    case 2:
                        users = await _parklandsSchoolContext.User.Include(a => a.UserType).Include(a => a.YearGroup).OrderByDescending(a => a.LastName).Skip(paging.RecordsToSkip).Take(paging.RecordsToSelect).ToListAsync();
                        break;
                    case 3:
                        users = await _parklandsSchoolContext.User.Include(a => a.UserType).Include(a => a.YearGroup).OrderByDescending(a => a.UserType).Skip(paging.RecordsToSkip).Take(paging.RecordsToSelect).ToListAsync();
                        break;
                    case 4:
                        users = await _parklandsSchoolContext.User.Include(a => a.UserType).Include(a => a.YearGroup).OrderByDescending(a => a.YearGroup.Name).Skip(paging.RecordsToSkip).Take(paging.RecordsToSelect).ToListAsync();
                        break;
                    default:
                        users = await _parklandsSchoolContext.User.Include(a => a.UserType).Include(a => a.YearGroup).OrderByDescending(a => a.FirstName).Skip(paging.RecordsToSkip).Take(paging.RecordsToSelect).ToListAsync();
                        break;
                }
            }

                return users;
            }

          public async Task<PostUserViewModel> BuildCreateUserViewModel(PostUserViewModel? viewModel = null)
          {
            if (viewModel == null)
            {
                viewModel = new PostUserViewModel { User = new User() };
            }
                    viewModel.UserTypeList = await _parklandsSchoolContext.UserType.ToListAsync();
                    viewModel.YearGroupList = await _parklandsSchoolContext.YearGroup.ToListAsync();

                    return viewModel;
          }

          public async Task<ValidationResult> ValidateCreateUserViewModel(PostUserViewModel viewModel)
          {
              ValidationResult result = await _validator.ValidateAsync(viewModel);
              return result;
          }

          public async Task<PostUserViewModel> BuildEditUserViewModel(Guid userId)
          {

             var viewModel = new PostUserViewModel { User = new User() };

             viewModel.User = await _parklandsSchoolContext.User.Where(a => a.UserId == userId).FirstOrDefaultAsync();

                    
             viewModel.UserTypeList = await _parklandsSchoolContext.UserType.ToListAsync();
             viewModel.YearGroupList = await _parklandsSchoolContext.YearGroup.ToListAsync();

             return viewModel;
          }

          public async Task<ValidationResult> ValidateEditUserViewModel(PostUserViewModel viewModel)
          {
              ValidationResult result = await _validator.ValidateAsync(viewModel);
              return result;
          }


        public async Task<ActionResult> AddUser(User user)
        {
            await _parklandsSchoolContext.User.AddAsync(user);
            await _parklandsSchoolContext.SaveChangesAsync();


            return new OkResult();
        }

        public async Task<bool> EditUser(User user)
        {
            if (await _parklandsSchoolContext.User.AnyAsync(a => a.UserId == user.UserId))
            {
                var userToUpdate = await _parklandsSchoolContext.User.SingleAsync(a => a.UserId == user.UserId);
                userToUpdate = _mapper.Map(user, userToUpdate);
                await _parklandsSchoolContext.SaveChangesAsync();

                return true;

            }

            return false;
        }

        public async Task<bool> Delete(User user)
        {
            if (await _parklandsSchoolContext.User.AnyAsync(a => a.UserId == user.UserId))
            {

                var userToDelete = await _parklandsSchoolContext.User.SingleAsync(a => a.UserId == user.UserId);
                _parklandsSchoolContext.User.Remove(userToDelete);
                await _parklandsSchoolContext.SaveChangesAsync();
                return true;
            }


            return false;
        }
    }

}
    

