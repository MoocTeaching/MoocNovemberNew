using Mooc.DataAccess.Dtos.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mooc.DataAccess.Service
{
    public interface IUserService : IDependency
    {
        bool Add(CreateOrUpdateUserDto createOrUpdateUserDto);

        List<UserDto> GetList();

        Task<UserDto> GetUser(int id);

        Task<CreateOrUpdateUserDto> GetEditUser(int id);

        bool Update(CreateOrUpdateUserDto updateUser);

        bool Delete(CreateOrUpdateUserDto deleteUser);
        //List<UserDto> GetUser(int id);
    }
}
