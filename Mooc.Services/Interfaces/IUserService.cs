using Mooc.Core.IDependency;
using Mooc.Dtos.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mooc.Services.Interfaces
{
    public interface IUserService : IDependency
    {
        Task<bool> Add(CreateOrUpdateUserDto createOrUpdateUserDto);

        List<UserDto> GetList();

        List<UserDto> GetListByPage(int pageIndex, int pageSize, ref int totalCount);

        Task<UserDto> GetUser(int id);
        Task<UserDto> GetUser(string userName);

        Task<CreateOrUpdateUserDto> GetEditUser(int id);

        bool Update(CreateOrUpdateUserDto updateUser);

        bool Delete(CreateOrUpdateUserDto deleteUser);
        
        List<UserDto> GetLoginUser(string email,string pw);


    }
}
