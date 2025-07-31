
using BrcFoodApp.WebApi.Entities;
using FluentValidation;

namespace BrcFoodApp.WebApi.ValidationRules
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün adı boş bırakılamaz!");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("Ürün adı için minimum 2 karakter giriniz!")
            .MaximumLength(50).WithMessage("Ürün adı için maksimum 50 karakter giriniz!");

            RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Fiyat bilgisi boş bırakılamaz!")
            .LessThan(0).WithMessage("Fiyat bilgisi negatif olamaz!")
            .GreaterThan(1000).WithMessage("Fiyat bilgisi 1000 yüksek olamaz");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama kısmı boş bırakılamaz");
        }
    }
}