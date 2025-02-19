using FluentValidation;
using TodoAppBlazorWebAssembly.Shared.Models;

namespace TodoAppBlazorWebAssembly.Shared.Validation
{
    public class NewTodoItemModelValidator : AbstractValidator<NewTodoItemModel>
    {
        public NewTodoItemModelValidator()
        {
            RuleFor(x => x.Text).NotEmpty().MaximumLength(Constants.MaxTodoItemLength);
        }
    }
}
