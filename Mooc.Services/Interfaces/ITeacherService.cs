using Mooc.Core.IDependency;
using Mooc.Dtos.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooc.Services.Interfaces
{
    public interface ITeacherService : IDependency
    {
        Task<bool> Add(CreateOrUpdateTeacherDto createOrUpdateTeacherDto);

        List<TeacherDto> GetList();

        Task<TeacherDto> GetTeacher(int id);
        Task<TeacherDto> GetTeacher(string userName);

        Task<CreateOrUpdateTeacherDto> GetEditTeacher(int id);

        Task<bool> Update(CreateOrUpdateTeacherDto updateTeacher);

        bool Delete(int deleteTeacher);

    }
}
