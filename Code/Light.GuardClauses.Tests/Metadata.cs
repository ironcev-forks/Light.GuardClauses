﻿using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace Light.GuardClauses.Tests
{
    [Trait("Category", Traits.InformativeTests)]
    public sealed class Metadata
    {
        private readonly ITestOutputHelper _output;

        public Metadata(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact(DisplayName = "Number of methods in Light.GuardClauses.")]
        public void NumberOfStaticMethods()
        {
            var totalNumberOfMethods = typeof(Check).GetTypeInfo()
                                                    .Assembly
                                                    .ExportedTypes
                                                    .Where(t => t.Namespace == typeof(Check).Namespace)
                                                    .SelectMany(t => t.GetMethods())
                                                    .Count(m => m.IsStatic);
            _output.WriteLine($"Number of Light.GuardClauses methods: {totalNumberOfMethods}");
        }
    }
}