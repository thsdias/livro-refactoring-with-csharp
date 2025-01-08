using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;

namespace Packt.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ToStringAnalyzer : DiagnosticAnalyzer
    {
        public static readonly DiagnosticDescriptor Rule =
          new DiagnosticDescriptor
          (
            id: "CSA1001",                                      // Um pedaco de codigo que começa com letras que identificam um provedor e, em seguida, um codigo numerico. Escolhemos o codigo CSA para Cloudy Skies Airlines.
            title: "Override ToString()",                       // O nome curto do aviso de analise de codigo. É o que aparecera nas dicas de ferramentas quando a regra for violada.
            messageFormat: "Override ToString on {0}",          // Uma string formatavel que aparecera na dica de ferramenta do Visual Studio.
            category: "Maintainability",                        // A categoria de regra ampla. Categorias comuns incluem: Naming, Performance, Maintainability, Security, Reliability, Design, e Usage.
            defaultSeverity: DiagnosticSeverity.Info,           // A gravidade da regra de analise de codigo sem que o usuario a ajuste. Isso será Hidden, Info, Warning, ou Error.
            isEnabledByDefault: true,                           // Se a regra inicia como habilitada.
            description: "Override ToString to help debugging." // Uma descricao detalhada da regra e por que ela é importante. Isso aparece no painel Error List quando uma violacao de regra é expandida.
          );

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => 
            ImmutableArray.Create(Rule);

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution();
            context.RegisterSymbolAction(Analyze, SymbolKind.NamedType);
        }

        private static void Analyze(SymbolAnalysisContext context)
        {
            INamedTypeSymbol symbol = (INamedTypeSymbol)context.Symbol;

            IMethodSymbol toString = symbol.GetMembers()
                .OfType<IMethodSymbol>()
                .FirstOrDefault(m => m.Name == "ToString" 
                    && m.IsOverride 
                    && m.Parameters.Length == 0);

            if (toString == null)
            {
                Diagnostic diagnostic = Diagnostic.Create(Rule, symbol.Locations[0], symbol.Name);
                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}