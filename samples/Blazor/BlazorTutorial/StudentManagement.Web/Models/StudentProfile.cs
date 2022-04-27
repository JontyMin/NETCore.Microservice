using AutoMapper;
using StudentManagement.Models;

namespace StudentManagement.Web.Models;

public class StudentProfile:Profile
{
    public StudentProfile()
    {
        CreateMap<Student, EditStudentModel>()
            .ForMember(x => x.ConfirmEmail,
                opt =>
                    opt.MapFrom(a => a.Email));
        CreateMap<EditStudentModel, Student>();
    }
}