// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CleanArchWithCQRSPattern.Application.Blogs.Commands.CreateBlog;
public class CreateBlogCommandValidator: AbstractValidator<CreateBlogCommand>
{
    public CreateBlogCommandValidator()
    {
        RuleFor(x=>x.name)
            .NotEmpty().WithMessage("Name should not be empty")
            .MaximumLength(200).WithMessage("Name should not exceed with 200 characters.");

        RuleFor(x => x.description)
            .NotEmpty().WithMessage("Decription should not be empty");

        RuleFor(x => x.author)
            .NotEmpty().WithMessage("Author can't be empty")
            .MaximumLength(20).WithMessage("Author can't exceed with 20 characters.");
    }
}
