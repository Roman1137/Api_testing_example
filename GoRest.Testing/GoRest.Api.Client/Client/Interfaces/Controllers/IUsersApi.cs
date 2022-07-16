using System.Collections.Generic;
using System.Threading.Tasks;
using GoRest.Api.Client.Client.Models;
using GoRest.Api.Client.Client.Models.UsersApi;
using RestEase;

namespace GoRest.Api.Client.Client.Interfaces.Controllers
{
    [Header("Accept", "application/json")]
    [Header("Content-Type", "application/json")]
    public interface IUsersApi : ISupportBearerAuth
    {
        [Get("users/")]
        Task<GeneralResponse<List<GetUserResponseModel>>> GetAll();
        
        [Post("users/")]
        Task<GeneralResponse<GetUserResponseModel>> CreateUser([Body] CreateUserModel userModel);
    }
}