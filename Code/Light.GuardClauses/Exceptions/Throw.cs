﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Light.GuardClauses.FrameworkExtensions;

namespace Light.GuardClauses.Exceptions
{
    /// <summary>
    /// Provides static factory methods that throw default exceptions.
    /// </summary>
    public static class Throw
    {
        /// <summary>
        /// Throws the default <see cref="ArgumentNullException" />, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void ArgumentNull(string parameterName = null, string message = null) =>
            throw new ArgumentNullException(parameterName, message ?? $"{parameterName ?? "The value"} must not be null.");

        /// <summary>
        /// Throws the default <see cref="ArgumentDefaultException" /> indicating that a value is the default value of its type, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void ArgumentDefault(string parameterName = null, string message = null) =>
            throw new ArgumentDefaultException(parameterName, message ?? $"{parameterName ?? "The value"} must not be the default value.");

        /// <summary>
        /// Throws the default <see cref="TypeCastException" /> indicating that a reference cannot be downcasted, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void InvalidTypeCast(object parameter, Type targetType, string parameterName = null, string message = null) =>
            throw new TypeCastException(parameterName, message ?? $"{parameterName ?? "The value"} \"{parameter}\" cannot be casted to \"{targetType}\".");

        /// <summary>
        /// Throws the default <see cref="TypeIsNoEnumException" /> indicating that a type is no enum type, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void TypeIsNoEnum(Type type, string parameterName = null, string message = null) =>
            throw new TypeIsNoEnumException(parameterName, message ?? $"{parameterName ?? "The type"} \"{type}\" must be an enum type, but it actually is not.");

        /// <summary>
        /// Throws the default <see cref="EnumValueNotDefinedException" /> indicating that a value is not one of the constants defined in an enum, using the optional paramter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void EnumValueNotDefined<T>(T parameter, string parameterName = null, string message = null) =>
            throw new EnumValueNotDefinedException(parameterName, message ?? $"{parameterName ?? "The value"} \"{parameter}\" must be one of the defined constants of enum \"{parameter.GetType()}\", but it actually is not.");

        /// <summary>
        /// Throws the default <see cref="EmptyGuidException" /> indicating that a GUID is empty, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void EmptyGuid(string parameterName = null, string message = null) =>
            throw new EmptyGuidException(parameterName, message ?? $"{parameterName ?? "The value"} must be a valid GUID, but it actually is an empty one.");

        /// <summary>
        /// Throws an <see cref="InvalidOperationException" /> using the optional message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void InvalidOperation(string message = null) => throw new InvalidOperationException(message);

        /// <summary>
        /// Throws an <see cref="InvalidStateException" /> using the optional message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void InvalidState(string message = null) => throw new InvalidStateException(message);

        /// <summary>
        /// Throws the default <see cref="NullableHasNoValueException" /> indicating that a <see cref="Nullable{T}" /> has no value, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void NullableHasNoValue(string parameterName = null, string message = null) =>
            throw new NullableHasNoValueException(parameterName, message ?? $"{parameterName ?? "The nullable"} must have a value, but it actually is null.");

        /// <summary>
        /// Throws the default <see cref="ArgumentOutOfRangeException" /> indicating that a comparable value must not be less than the given boundary value, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void MustNotBeLessThan<T>(T parameter, T boundary, string parameterName = null, string message = null) where T : IComparable<T> =>
            throw new ArgumentOutOfRangeException(parameterName, message ?? $"{parameterName ?? "The value"} must not be less than {boundary}, but it actually is {parameter}.");

        /// <summary>
        /// Throws the default <see cref="ArgumentOutOfRangeException" /> indicating that a comparable value must be less than the given boundary value, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void MustBeLessThan<T>(T parameter, T boundary, string parameterName = null, string message = null) where T : IComparable<T> =>
            throw new ArgumentOutOfRangeException(parameterName, message ?? $"{parameterName ?? "The value"} must be less than {boundary}, but it actually is {parameter}.");

        /// <summary>
        /// Throws the default <see cref="ArgumentOutOfRangeException" /> indicating that a comparable value must not be less than or equal to the given boundary value, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void MustNotBeLessThanOrEqualTo<T>(T parameter, T boundary, string parameterName = null, string message = null) where T : IComparable<T> =>
            throw new ArgumentOutOfRangeException(parameterName, message ?? $"{parameterName ?? "The value"} must not be less than or equal to {boundary}, but it actually is {parameter}.");

        /// <summary>
        /// Throws the default <see cref="ArgumentOutOfRangeException" /> indicating that a comparable value must not be greater than or equal to the given boundary value, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void MustNotBeGreaterThanOrEqualTo<T>(T parameter, T boundary, string parameterName = null, string message = null) where T : IComparable<T> =>
            throw new ArgumentOutOfRangeException(parameterName, message ?? $"{parameterName ?? "The value"} must not be greater than or equal to {boundary}, but it actually is {parameter}.");

        /// <summary>
        /// Throws the default <see cref="ArgumentOutOfRangeException" /> indicating that a comparable value must be greater than or equal to the given boundary value, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void MustBeGreaterThanOrEqualTo<T>(T parameter, T boundary, string parameterName = null, string message = null) where T : IComparable<T> =>
            throw new ArgumentOutOfRangeException(parameterName, message ?? $"{parameterName ?? "The value"} must be greater than or equal to {boundary}, but it actually is {parameter}.");

        /// <summary>
        /// Throws the default <see cref="ArgumentOutOfRangeException" /> indicating that a comparable value must be greater than the given boundary value, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void MustBeGreaterThan<T>(T parameter, T boundary, string parameterName = null, string message = null) where T : IComparable<T> =>
            throw new ArgumentOutOfRangeException(parameterName, message ?? $"{parameterName ?? "The value"} must be greater than {boundary}, but it actually is {parameter}.");

        /// <summary>
        /// Throws the default <see cref="ArgumentOutOfRangeException" /> indicating that a comparable value must not be greater than the given boundary value, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void MustNotBeGreaterThan<T>(T parameter, T boundary, string parameterName = null, string message = null) where T : IComparable<T> =>
            throw new ArgumentOutOfRangeException(parameterName, message ?? $"{parameterName ?? "The value"} must not be greater than {boundary}, but it actually is {parameter}.");

        /// <summary>
        /// Throws the default <see cref="ArgumentOutOfRangeException" /> indicating that a comparable value must be less than or equal to the given boundary value, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void MustBeLessThanOrEqualTo<T>(T parameter, T boundary, string parameterName = null, string message = null) where T : IComparable<T> =>
            throw new ArgumentOutOfRangeException(parameterName, message ?? $"{parameterName ?? "The value"} must be less than or equal to {boundary}, but it actually is {parameter}.");

        /// <summary>
        /// Throws the default <see cref="ArgumentOutOfRangeException" /> indicating that a value is not within a specified range, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void MustBeInRange<T>(T parameter, Range<T> range, string parameterName = null, string message = null) where T : IComparable<T> =>
            throw new ArgumentOutOfRangeException(parameterName, message ?? $"{parameterName ?? "The value"} must be between {range.From} ({(range.IsFromInclusive ? "inclusive" : "exclusive")}) and {range.To} ({(range.IsToInclusive ? "inclusive" : "exclusive")}), but it actually is {parameter}.");

        /// <summary>
        /// Throws the default <see cref="ArgumentOutOfRangeException" /> indicating that a value is within a specified range, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void MustNotBeInRange<T>(T parameter, Range<T> range, string parameterName = null, string message = null) where T : IComparable<T> =>
            throw new ArgumentOutOfRangeException(parameterName, message ?? $"{parameterName ?? "The value"} must not be between {range.From} ({(range.IsFromInclusive ? "inclusive" : "exclusive")}) and {range.To} ({(range.IsToInclusive ? "inclusive" : "exclusive")}), but it actually is {parameter}.");

        /// <summary>
        /// Throws the default <see cref="SameObjectReferenceException" /> indicating that two references point to the same object, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void SameObjectReference<T>(T parameter, string parameterName = null, string message = null) where T : class =>
            throw new SameObjectReferenceException(parameterName, message ?? $"{parameterName ?? "The reference"} must not point to object \"{parameter}\", but it actually does.");

        /// <summary>
        /// Throws the default <see cref="EmptyStringException" /> indicating that a string is empty, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void EmptyString(string parameterName = null, string message = null) =>
            throw new EmptyStringException(parameterName, message ?? $"{parameterName ?? "The string"} must not be an empty string, but it actually is.");

        /// <summary>
        /// Throws the default <see cref="WhiteSpaceStringException" /> indicating that a string contains only white space, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void WhiteSpaceString(string parameter, string parameterName, string message) =>
            throw new WhiteSpaceStringException(parameterName, message ?? $"{parameterName ?? "The string"} must not contain only white space, but it actually is \"{parameter}\".");

        /// <summary>
        /// Throws the default <see cref="StringDoesNotMatchException" /> indicating that a string does not match a regular expression, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void StringDoesNotMatch(string parameter, Regex regex, string parameterName = null, string message = null) => 
            throw new StringDoesNotMatchException(parameterName, message ?? $"{parameterName ?? "The string"} must match the regular expression \"{regex}\", but it actually is \"{parameter}\".");

        /// <summary>
        /// Throws the default <see cref="SubstringException"/> indicating that a string does not contain another string as a substring, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void StringDoesNotContain(string parameter, string substring, string parameterName = null, string message = null) => 
            throw new SubstringException(parameterName, message ?? $"{parameterName ?? "The string"} must contain {substring.ToStringOrNull()}, but it actually is {parameter.ToStringOrNull()}.");

        /// <summary>
        /// Throws the default <see cref="SubstringException"/> indicating that a string does not contain another string as a substring, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void StringDoesNotContain(string parameter, string substring, StringComparison comparisonType, string parameterName = null, string message = null) => 
            throw new SubstringException(parameterName, message ?? $"{parameterName ?? "The string"} must contain {substring.ToStringOrNull()} ({comparisonType}), but it actually is {parameter.ToStringOrNull()}.");

        /// <summary>
        /// Throws the default <see cref="SubstringException"/> indicating that a string does contain another string as a substring, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void StringContains(string parameter, string substring, string parameterName = null, string message = null) =>
            throw new SubstringException(parameterName, message ?? $"{parameterName ?? "The string"} must not contain {substring.ToStringOrNull()} as a substring, but it actually is {parameter.ToStringOrNull()}.");

        /// <summary>
        /// Throws the default <see cref="SubstringException"/> indicating that a string does contain another string as a substring, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void StringContains(string parameter, string substring, StringComparison comparisonType, string parameterName = null, string message = null) =>
            throw new SubstringException(parameterName, message ?? $"{parameterName ?? "The string"} must not contain {substring.ToStringOrNull()} as a substring ({comparisonType}), but it actually is {parameter.ToStringOrNull()}.");

        /// <summary>
        /// Throws the default <see cref="SubstringException"/> indicating that a string is not a substring of another one, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void NotSubstring(string parameter, string other, string parameterName = null, string message = null) => 
            throw new SubstringException(parameterName, message ?? $"{parameterName ?? "The string"} must be a substring of \"{other}\", but it actually is {parameter.ToStringOrNull()}.");

        /// <summary>
        /// Throws the default <see cref="SubstringException"/> indicating that a string is not a substring of another one, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void NotSubstring(string parameter, string other, StringComparison comparisonType, string parameterName = null, string message = null) =>
            throw new SubstringException(parameterName, message ?? $"{parameterName ?? "The string"} must be a substring of \"{other}\" ({comparisonType}), but it actually is {parameter.ToStringOrNull()}.");

        /// <summary>
        /// Throws the default <see cref="ValuesNotEqualException" /> indicating that two values are not equal, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void ValuesNotEqual<T>(T parameter, T other, string parameterName = null, string message = null) =>
            throw new ValuesNotEqualException(parameterName, message ?? $"{parameterName ?? "The value"} must be equal to {other.ToStringOrNull()}, but it actually is {parameter.ToStringOrNull()}.");

        /// <summary>
        /// Throws the default <see cref="ValuesEqualException" /> indicating that two values are equal, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void ValuesEqual<T>(T parameter, T other, string parameterName = null, string message = null) =>
            throw new ValuesEqualException(parameterName, message ?? $"{parameterName ?? "The value"} must not be equal to {other.ToStringOrNull()}, but it actually is {parameter.ToStringOrNull()}.");

        /// <summary>
        /// Throws the default <see cref="InvalidCollectionCountException" /> indicating that a collection has an invalid number of items, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void InvalidCollectionCount(IEnumerable parameter, int count, string parameterName = null, string message = null) =>
            throw new InvalidCollectionCountException(parameterName, message ?? $"{parameterName ?? "The collection"} must have count {count}, but it actually has count {parameter.Count()}.");

        /// <summary>
        /// Throws the default <see cref="InvalidCollectionCountException" /> indicating that a collection has less than a minimum number of items, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void InvalidMinimumCollectionCount(IEnumerable parameter, int count, string parameterName = null, string message = null) =>
            throw new InvalidCollectionCountException(parameterName, message ?? $"{parameterName ?? "The collection"} must have at least count {count}, but it actually has count {parameter.Count()}.");

        /// <summary>
        /// Throws the default <see cref="InvalidCollectionCountException" /> indicating that a collection has more than a maximum number of items, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void InvalidMaximumCollectionCount(IEnumerable parameter, int count, string parameterName = null, string message = null) =>
            throw new InvalidCollectionCountException(parameterName, message ?? $"{parameterName ?? "The collection"} must have at most count {count}, but it actually has count {parameter.Count()}.");

        /// <summary>
        /// Throws the default <see cref="EmptyCollectionException" /> indicating that a collection has no items, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void EmptyCollection(IEnumerable parameter, string parameterName = null, string message = null) =>
            throw new EmptyCollectionException(parameterName, message ?? $"{parameterName ?? "The collection"} must not be an empty collection, but it actually is.");

        /// <summary>
        /// Throws the default <see cref="MissingItemException" /> indicating that a collection is not containing the specified item, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void MissingItem<TItem>(IEnumerable<TItem> parameter, TItem item, string parameterName = null, string message = null) =>
            throw new MissingItemException(parameterName,
                                           message ??
                                           new StringBuilder().AppendLine($"{parameterName ?? "The collection"} must contain {item.ToStringOrNull()}, but it actually does not.")
                                                              .AppendCollectionContent(parameter)
                                                              .ToString());

        /// <summary>
        /// Throws the default <see cref="ExistingItemException" /> indicating that a collection contains the specified item that should not be part of it, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void ExistingItem<TItem>(IEnumerable<TItem> parameter, TItem item, string parameterName = null, string message = null) =>
            throw new ExistingItemException(parameterName,
                                            message ??
                                            new StringBuilder().AppendLine($"{parameterName ?? "The collection"} must not contain {item.ToStringOrNull()}, but it actually does.")
                                                               .AppendCollectionContent(parameter)
                                                               .ToString());

        /// <summary>
        /// Throws the default <see cref="ValueIsNotOneOfException" /> indicating that a value is not one of a specified collection of items, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void ValueNotOneOf<TItem>(TItem parameter, IEnumerable<TItem> items, string parameterName = null, string message = null) =>
            throw new ValueIsNotOneOfException(parameterName,
                                               message ??
                                               new StringBuilder().AppendLine($"{parameterName ?? "The value"} must be one of the following items")
                                                                  .AppendItemsWithNewLine(items)
                                                                  .AppendLine($"but it actually is {parameter.ToStringOrNull()}.")
                                                                  .ToString());

        /// <summary>
        /// Throws the default <see cref="ValueIsOneOfException" /> indicating that a value is one of a specified collection of items, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void ValueIsOneOf<TItem>(TItem parameter, IEnumerable<TItem> items, string parameterName = null, string message = null) =>
            throw new ValueIsOneOfException(parameterName,
                                            message ??
                                            new StringBuilder().AppendLine($"{parameterName ?? "The value"} must not be one of the following items")
                                                               .AppendItemsWithNewLine(items)
                                                               .AppendLine($"but it actually is {parameter.ToStringOrNull()}.")
                                                               .ToString());

        /// <summary>
        /// Throws the default <see cref="RelativeUriException" /> indicating that a URI is relative instead of absolute, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void MustBeAbsoluteUri(Uri parameter, string parameterName = null, string message = null) =>
            throw new RelativeUriException(parameterName, message ?? $"{parameterName ?? "The URI"} must be an absolute URI, but it actually is \"{parameter}\".");

        /// <summary>
        /// Throws the default <see cref="AbsoluteUriException" /> indicating that a URI is absolute instead of relative, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void MustBeRelativeUri(Uri parameter, string parameterName = null, string message = null) => 
            throw new AbsoluteUriException(parameterName, message ?? $"{parameterName ?? "The URI"} must be a relative URI, but it actually is \"{parameter}\".");

        /// <summary>
        /// Throws the default <see cref="InvalidUriSchemeException" /> indicating that a URI has an unexpected scheme, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void UriMustHaveScheme(Uri uri, string scheme, string parameterName = null, string message = null) =>
            throw new InvalidUriSchemeException(parameterName, message ?? $"{parameterName ?? "The URI"} must use the scheme \"{scheme}\", but it actually is \"{uri}\".");

        /// <summary>
        /// Throws the default <see cref="InvalidUriSchemeException" /> indicating that a URI does not use one of a set of expected schemes, using the optional parameter name and message.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void UriMustHaveOneSchemeOf(Uri uri, IEnumerable<string> schemes, string parameterName = null, string message = null) =>
            throw new InvalidUriSchemeException(parameterName,
                                                message ??
                                                new StringBuilder().AppendLine($"{parameterName ?? "The URI"} must use one of the following schemes")
                                                                   .AppendItemsWithNewLine(schemes)
                                                                   .AppendLine($"but it actually is \"{uri}\".")
                                                                   .ToString());

        /// <summary>
        /// Throws the exception that is returned by <paramref name="exceptionFactory" />.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void CustomException(Func<Exception> exceptionFactory) => 
            throw exceptionFactory.MustNotBeNull(nameof(exceptionFactory))();

        /// <summary>
        /// Throws the exception that is returned by <paramref name="exceptionFactory" />. <paramref name="parameter" /> is passed to <paramref name="exceptionFactory" />.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void CustomException<T>(Func<T, Exception> exceptionFactory, T parameter) => 
            throw exceptionFactory.MustNotBeNull(nameof(exceptionFactory))(parameter);

        /// <summary>
        /// Throws the exception that is returned by <paramref name="exceptionFactory" />. <paramref name="first" /> and <paramref name="second" /> are passed to <paramref name="exceptionFactory" />.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void CustomException<T1, T2>(Func<T1, T2, Exception> exceptionFactory, T1 first, T2 second) => 
            throw exceptionFactory.MustNotBeNull(nameof(exceptionFactory))(first, second);

        /// <summary>
        /// Throws the exception that is returned by <paramref name="exceptionFactory" />. <paramref name="first" />, <paramref name="second" />, and <paramref name="third"/> are passed to <paramref name="exceptionFactory" />.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void CustomException<T1, T2, T3>(Func<T1, T2, T3, Exception> exceptionFactory, T1 first, T2 second, T3 third) =>
            throw exceptionFactory.MustNotBeNull(nameof(exceptionFactory))(first, second, third);
    }
}