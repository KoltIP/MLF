using PetProject.UserAccountService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.UserAccountService
{
    public interface IUserAccountService
    {
        Task<UserModel> Create(RegistrationUserModel model);
        Task Delete(string token);
        Task ConfirmEmail(string email, string code);
        Task<bool> InspectEmail(string email);
        Task<UserModel> GetUser(string token);
        Task ChangeName(string token, string name);
        Task ChangeSurname(string token, string name);
        Task ChangePatronymic(string token, string name);
        Task ChangeEmail(string token, string email);
        Task ChangePassword(string token, PasswordModel password);
        Task ConfirmForgotPassword(string email, string code, string password);
        Task ForgotPassword(ForgotPasswordModel model);
        //Task InsectPhone(string phone);
        //Task ChangePhone(string token, string phone);
    }
}
