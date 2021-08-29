﻿using FluentValidation;

namespace HRM.Model.Assets
{
    public abstract class AssetValidator : AbstractValidator<AssetModel>
    {
        public void Id()
        {
            RuleFor(m => m.Id).NotEmpty().NotNull();
        }

        public void Code()
        {
            RuleFor(m => m.Code).NotEmpty().NotNull();
            RuleFor(m => m.Code).MaximumLength(50);
        }

        public void Name()
        {
            RuleFor(m => m.Name).NotEmpty().NotNull();
            RuleFor(m => m.Name).MaximumLength(150);
        }

        public void SerialNumber()
        {
            RuleFor(m => m.SerialNumber).MaximumLength(50);
        }

        public void AssetTypeId()
        {
            RuleFor(m => m.AssetTypeId).NotEmpty().NotNull();
        }

        public void VendorId()
        {
            RuleFor(m => m.VendorId).NotEmpty().NotNull();
        }

        public void Note()
        {
            RuleFor(m => m.Note).MaximumLength(500);
        }

        public void IsActive()
        {
            RuleFor(m => m.IsActive).NotNull();
        }
    }
}
