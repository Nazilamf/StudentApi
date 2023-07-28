using FluentValidation;

namespace StudentApp.Service.Dtos.StudentDtos
{
    public class StudentCreateDto
    {
        public int GroupId { get; set; }
        public string FullName { get; set; }   
        
        public decimal Point { get; set; }  
   
    }

    public class StudentCreateDtoValidator : AbstractValidator<StudentCreateDto>
    {
        public StudentCreateDtoValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Point).GreaterThanOrEqualTo(0);
            RuleFor(x => x.GroupId).GreaterThanOrEqualTo(1);
        }
    }
}
