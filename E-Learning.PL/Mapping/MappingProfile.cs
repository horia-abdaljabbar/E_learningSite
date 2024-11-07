using AutoMapper;
using E_Learning.DAL.Models;
using E_Learning.PL.Areas.Dashboard.ViewModels;
using E_Learning.PL.ViewModels;

namespace E_Learning.PL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ServiceFormVM, Service>();
            CreateMap<Service, ServiceFormVM>();

            CreateMap<Service,ShowServicesVM>();
            CreateMap<Service,ServiceDetailsVM>();

            CreateMap<Service,ServiceVM>();
            CreateMap<ServiceVM, Service>();
            CreateMap<Category, CategoryVM>();
            CreateMap<CategoryVM, Category>();
            CreateMap<Course, CourseVM>();
            CreateMap<CourseVM, Course>();
            CreateMap<Teacher, TeacherVM>();
            CreateMap<TeacherVM, Teacher>();


            CreateMap<CourseFormVM, Course>();
            CreateMap<Course, CourseFormVM>();
            CreateMap<Course, ShowCoursesVM>();
            CreateMap<Course, CourseDetails>();
            CreateMap<TeacherFormVM, Teacher>();
            CreateMap<Teacher, TeacherFormVM>();
            CreateMap<Teacher, ShowTeachersVM>();
            CreateMap<Teacher, TeacherDetailsVM>();
            CreateMap<CategoryFormVM, Category>();
            CreateMap<Category, CategoryFormVM>();
            CreateMap<Category, ShowCategoriesVM>();
            CreateMap<Category, CategoryDetailsVM>();

        }
    }
}
