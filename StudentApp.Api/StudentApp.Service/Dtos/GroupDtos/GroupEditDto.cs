using FluentValidation;

namespace StudentApp.Service.Dtos.GroupDtos
{
    public class GroupEditDto
    {
        public string GroupNo { get; set; }
    }


    public class GroupEditDtoValidator : AbstractValidator<GroupEditDto>
    {
        public GroupEditDtoValidator()
        {
            RuleFor(x => x.GroupNo).NotEmpty().MaximumLength(35);
        }
    }
}
