using AutoMapper;
using Mooc.DataAccess.Context;
using Mooc.Dtos.User;
using Mooc.Models.Entities;
using Mooc.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;

namespace Mooc.Services.Service
{
    public class UserService : IUserService
    {
        private DataContext _db;
        //private IMapper _mapper;
        public UserService(IDataContextProvider dataContextProvider)
        {
            this._db = dataContextProvider.GetDataContext();
            //this._mapper = mapper;
        }

        public async Task<bool> Add(CreateOrUpdateUserDto createOrUpdateUserDto)
        {
            try
            {
                var user = Mapper.Map<User>(createOrUpdateUserDto);
                this._db.Users.Add(user);
                return await this._db.SaveChangesAsync() > 0;
            }

            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }

                throw;
            }

        }

        public List<UserDto> GetList()
        {
            var list = _db.Users.ToList();
            return Mapper.Map<List<UserDto>>(list);
        }

        public async Task<UserDto> GetUser(int id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(p => p.Id == id);
            if (user == null)
                return null;
            return Mapper.Map<UserDto>(user);
        }

        //Edit
        public async Task<CreateOrUpdateUserDto> GetEditUser(int id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(p => p.Id == id);

            if (user == null)
                return null;

            return Mapper.Map<CreateOrUpdateUserDto>(user);

        }

        //Update Edit items
        public bool Update(CreateOrUpdateUserDto updateUser)
        {
            var user = Mapper.Map<User>(updateUser);
            this._db.Users.Add(user);
            return this._db.SaveChanges() > 0;
        }

        public bool Delete(CreateOrUpdateUserDto deleteUser)
        {
            var user = Mapper.Map<User>(deleteUser);
            this._db.Users.Remove(user);
            return this._db.SaveChanges() > 0;
        }

        public List<UserDto> GetLoginUser(string email, string password)
        {
            var user = _db.Users.Where(s => s.Email.Equals(email) && s.PassWord.Equals(password)).ToList();
            if (user == null)
                return null;
            return Mapper.Map<List<UserDto>>(user);
        }

        public async Task<UserDto> GetUser(string userName)
        {
            User user = await _db.Users.FirstOrDefaultAsync(p => p.UserName == userName);
            if (user == null)
                return null;
            return Mapper.Map<UserDto>(user);
        }
    }
}