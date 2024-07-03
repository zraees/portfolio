// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace CleanArchWithCQRSPattern.Application.Common.Behaviours;
internal class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validator;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validator)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validator.Any()) {

            var context = new ValidationContext<TRequest>(request);

            var validationResult = await Task.WhenAll(
                _validator.Select(x => x.ValidateAsync(context, cancellationToken))).ConfigureAwait(false);

            var failures = validationResult
                .Where(x => x.Errors.Any())
                .SelectMany(x=>x.Errors)
                .ToList();

            if (failures.Any())
            {
                throw new ValidationException(failures);
            }

        }

        return await next().ConfigureAwait(false);
    }
}
