using FluentValidation;

namespace StudentApp.Service.Dtos.GroupDtos
{
    public class GroupCreateDto
    {
        public string GroupNo { get; set; }
    }


    public class GroupCreateDtoValidator : AbstractValidator<GroupCreateDto>

    {
        public GroupCreateDtoValidator()
        {
            RuleFor(x => x.GroupNo).NotEmpty().WithMessage("Bos ola bilmez").MinimumLength(3).MaximumLength(35);
        }
    }
}
