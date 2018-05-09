﻿using System;
using FluentAssertions;
using Light.GuardClauses.Exceptions;
using Xunit;

namespace Light.GuardClauses.Tests.CommonAssertions
{
    public static class MustNotBeEmptyGuidTests
    {
        [Fact]
        public static void GuidEmpty()
        {
            var emptyGuid = Guid.Empty;

            Action act = () => emptyGuid.MustNotBeEmpty(nameof(emptyGuid));

            act.Should().Throw<EmptyGuidException>()
               .And.ParamName.Should().Be(nameof(emptyGuid));
        }

        [Fact]
        public static void GuidNotEmpty()
        {
            var validGuid = Guid.NewGuid();

            var result = validGuid.MustNotBeEmpty();

            result.Should().Be(validGuid);
        }

        [Fact]
        public static void CustomException() =>
            CustomExceptions.TestCustomException(exceptionFactory => Guid.Empty.MustNotBeEmpty(exceptionFactory));

        [Fact]
        public static void CustomMessage() =>
            CustomMessages.TestCustomMessage<EmptyGuidException>(message => Guid.Empty.MustNotBeEmpty(message: message));

    }
}