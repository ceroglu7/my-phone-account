using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhoneAccount.Validators
{
    public class PersonDtoValidator : AbstractValidator<PersonDto.Person>
    {
        
        public PersonDtoValidator()
        {
            RuleFor(c => c.Email).EmailAddress().WithMessage("Mail bilgisi hatalı girildi").When(i => !string.IsNullOrEmpty(i.Email));
            RuleFor(c => c.Fullname).Length(3, 20).NotEmpty().NotNull().WithMessage("Ad Soyad bilgisi hatalı");
            RuleFor(c => c.GSM).Length(11).Must(IsDigit).WithMessage("Hata");
            RuleFor(c => c.CompanyName).Length(0, 15).NotNull().NotEmpty().WithMessage("Şirket adı 15 karakter olmalı max").When(c => c.IsCompany);
            RuleFor(c => c.Phone).Must(IsDigit).WithMessage("Hata");
        }
        private bool IsDigit(string deger)
        {
            bool sayidonusumu = int.TryParse(deger, out int sonuc);
            return sayidonusumu;
        }
    }
}
