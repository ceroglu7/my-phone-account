using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyPhoneAccount.Validators
{
    public class PersonDtoValidator : AbstractValidator<PersonDto.Person>
    {
        
        public PersonDtoValidator()
        {
            RuleFor(c => c.Email).EmailAddress().Must(IsMailContainDot).WithMessage("Mail bilgisi hatalı girildi").When(i => !string.IsNullOrEmpty(i.Email));
            RuleFor(c => c.Fullname).Length(3, 20).NotEmpty().NotNull().WithMessage("Ad Soyad bilgisi hatalı");
            RuleFor(c => c.GSM).Must(IsDigit).WithMessage("GSM Bilgisi 11 Haneli Olmalı ve Rakamlardan Oluşmalı");
            RuleFor(c => c.CompanyName).Length(0, 15).NotNull().NotEmpty().WithMessage("Şirket adı 15 karakter olmalı max").When(c => c.IsCompany);
            RuleFor(c => c.Phone).Must(IsDigit).WithMessage("Sabit Telefon Bilgisi 11 Haneli Olmalı ve Rakamlardan Oluşmalı");
        }
        private bool IsDigit(string phone)
        {
            return Regex.IsMatch(phone, @"^0\d{10}$");
        }
        private bool IsMailContainDot(string mail)
        {
            string dot = ".";
            if (mail.Contains(dot))
                return true;
            else
                return false;
        }
    }
}
