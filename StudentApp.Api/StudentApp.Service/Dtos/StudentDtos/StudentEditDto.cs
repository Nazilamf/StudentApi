using FluentValidation;

namespace StudentApp.Service.Dtos.StudentDtos
{
    public class StudentEditDto
    {
        public int GroupId { get; set; }
        public string FullName { get; set; }  
        public decimal Point { get; set; }  
    }

    public class StudentEditDtoValidator : AbstractValidator<StudentEditDto>
    {
        public StudentEditDtoValidator() 
        {
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Point).GreaterThanOrEqualTo(0);
            RuleFor(x => x.GroupId).GreaterThanOrEqualTo(1);
        }    
    }
}
