using AutoMapper;
using Mooc.Dtos.Teacher;
using Mooc.Models.Entities;
using Mooc.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using Mooc.Utils;
using Mooc.DataAccess.Context;

namespace Mooc.Services.Service
{
    public class TeacherService : ITeacherService
    {
        private DataContext _db;
        public TeacherService(IDataContextProvider dataContextProvider)
        {
            this._db = dataContextProvider.GetDataContext();
        }

        //Add
        public async Task<bool> Add(CreateOrUpdateTeacherDto createOrUpdateTeacherDto)
        {
            try
            {
                var teacher = Mapper.Map<Teacher>(createOrUpdateTeacherDto);
                this._db.Teachers.Add(teacher);
                return await this._db.SaveChangesAsync() > 0;
            }
            catch(DbEntityValidationException e)
            {
                foreach(var er in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation error:",
                        er.Entry.Entity.GetType().Name, er.Entry.State);
                    foreach (var ve in er.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public List<TeacherDto> GetList()
        {
            var list = _db.Teachers.ToList();
            return Mapper.Map<List<TeacherDto>>(list);
        }

        public async Task<TeacherDto> GetTeacher(int id)
        {
            var teacher = await _db.Teachers.FirstOrDefaultAsync(p => p.Id == id);
            if (teacher == null)
                return null;
            return Mapper.Map<TeacherDto>(teacher);
        }

        //Edit
        public async Task<CreateOrUpdateTeacherDto> GetEditTeacher(int id)
        {
            try
            {
                var teacher = await _db.Teachers.FirstOrDefaultAsync(p => p.Id == id);

                if (teacher == null)
                    return null;
                return Mapper.Map<CreateOrUpdateTeacherDto>(teacher);
            }
            catch(DbEntityValidationException e)
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

        //Update
        public async Task<bool> Update(CreateOrUpdateTeacherDto updateTeacher)
        {
            try
            {
                var teacher = Mapper.Map<Teacher>(updateTeacher);
                this._db.Teachers.Add(teacher);
                return await this._db.SaveChangesAsync() > 0;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    //Log.Error(eve.Entry.Entity.GetType().Name.ToString());
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }

                throw;
            }
        }

        public bool Delete(int deleteID)
        {
            var teacher = _db.Teachers.Find(deleteID);
            this._db.Teachers.Remove(teacher);
            return this._db.SaveChanges() > 0;
        }

        public async Task<TeacherDto> GetTeacher(string teacherName)
        {
            Teacher teacher = await _db.Teachers.FirstOrDefaultAsync(p => p.TeacherName == teacherName);
            if (teacher == null)
                return null;
            return Mapper.Map<TeacherDto>(teacher);
        }
    }
}
