// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using FluentResults;

namespace CleanArchWithCQRSPattern.Application.Common.Exceptions.Errors;
public class ValidationError : Error
{
    public ValidationError(string message)
        : base(message)
    {
    }
}
