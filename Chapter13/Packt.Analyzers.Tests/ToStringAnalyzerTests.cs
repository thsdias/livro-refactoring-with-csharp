using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using RoslynTestKit;

namespace Packt.Analyzers.Tests; 

public class ToStringAnalyzerTests : AnalyzerTestFixture
{
    protected override string LanguageName
        => LanguageNames.CSharp;

    protected override DiagnosticAnalyzer CreateAnalyzer()
        => new ToStringAnalyzer();

    public const string GoodCode = @"
        using System;
        public class Flight
        {
          public string Id {get; set;}
          public string DepartAirport {get; set;}
          public string ArriveAirport {get; set;}
          public override string ToString() => Id;
        }";

    public const string BadCode = @"
        using System;
        public class [|Flight|]
        {
          public string Id {get; set;}
          public string DepartAirport {get; set;}
          public string ArriveAirport {get; set;}
        }";

    [Fact]
    public void AnalyzerShouldNotFlagGoodCode()
    {
        NoDiagnostic(GoodCode, ToStringAnalyzer.Rule.Id);
    }

    [Fact]
    public void AnalyzerShouldFlagViolations()
    {
        HasDiagnostic(BadCode, ToStringAnalyzer.Rule.Id);
    }
}