﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KriniteWebShop.Order.Application.Exceptions;
public class ValidationException : ApplicationException
{
	public IDictionary<string, string[]> Errors { get; init; }

	public ValidationException() : base("One or more validation failures have occured.")
	{
		Errors = new Dictionary<string, string[]>();
	}

	public ValidationException(IEnumerable<ValidationFailure> failures) : this()
	{
		Errors = failures
			.GroupBy(fail => fail.PropertyName, fail => fail.ErrorMessage)
			.ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
	}
}
