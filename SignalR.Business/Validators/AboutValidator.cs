using FluentValidation;
using SignalR.DTO.Dtos.AboutDtos;
using SignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Business.Validators
{
    public class AboutValidator: AbstractValidator<CreateAboutDto>
    {

        public AboutValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz").MinimumLength(3).WithMessage("En az 3 karakter olmalıdır.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim Url boş bırakılamaz");
        }
    }

    public class UpdateAboutValidator: AbstractValidator<UpdateAboutDto>
    {
        public UpdateAboutValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim Url boş bırakılamaz");
        }
    }
}
