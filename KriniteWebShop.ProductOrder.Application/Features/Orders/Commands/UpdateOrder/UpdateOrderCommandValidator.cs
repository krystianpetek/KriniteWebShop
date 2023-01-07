﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KriniteWebShop.ProductOrder.Application.Features.Orders.Commands.UpdateOrder;
internal class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(p => p.UserName)
            .NotEmpty().WithMessage("{UserName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{UserName} must not exceed 50 characters.");

        RuleFor(p => p.EmailAddress)
            .NotEmpty().WithMessage("{EmailAddress} is required.");

        RuleFor(p => p.TotalPrice)
            .NotEmpty().WithMessage("{TotalPrice} is required.")
            .GreaterThan(0).WithMessage("{TotalPrice} should be greather than zero.");
    }
}
