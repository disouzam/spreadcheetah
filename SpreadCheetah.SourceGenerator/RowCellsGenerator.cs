using Microsoft.CodeAnalysis;
using SpreadCheetah.SourceGenerator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpreadCheetah.SourceGenerator
{
    [Generator]
    public class RowCellsGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxReceiver is not SyntaxReceiver syntaxReceiver)
                throw new InvalidOperationException("We were given the wrong syntax receiver.");

            var classesToValidate = GetClassPropertiesInfo(context.Compilation, syntaxReceiver.ArgumentsToValidate);

            var sb = new StringBuilder();
            GenerateValidator(sb, classesToValidate);
            context.AddSource("SpreadsheetExtensions.cs", sb.ToString());

            ReportDiagnostics(context, classesToValidate);
        }

        private static void ReportDiagnostics(GeneratorExecutionContext context, IEnumerable<ClassPropertiesInfo> infos)
        {
            foreach (var info in infos)
            {
                if (info.PropertyNames.Count == 0)
                    context.ReportDiagnostics(Diagnostics.NoPropertiesFound, info.Locations, info.ClassType);

                if (info.UnsupportedPropertyNames.FirstOrDefault() is { } unsupportedProperty)
                    context.ReportDiagnostics(Diagnostics.UnsupportedTypeForCellValue, info.Locations, info.ClassType, unsupportedProperty);
            }
        }

        private static void GenerateValidator(StringBuilder sb, ICollection<ClassPropertiesInfo> infos)
        {
            sb.AppendLine("// <auto-generated />");
            sb.AppendLine("using System.Threading;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine();
            sb.AppendLine("namespace SpreadCheetah");
            sb.AppendLine("{");
            sb.AppendLine("    public static class SpreadsheetExtensions");
            sb.AppendLine("    {");

            var indent = 2;
            if (infos.Count == 0)
                WriteStub(sb, indent);
            else
                WriteMethods(sb, indent, infos);

            sb.AppendLine("    }");
            sb.AppendLine("}");
        }

        private static void WriteSummary(StringBuilder sb, int indent)
        {
            sb.AppendLine(indent, "/// <summary>");
            sb.AppendLine(indent, "/// Add object as a row in the active worksheet.");
            sb.AppendLine(indent, "/// Each property with a public getter on the object will be added as a cell in the row.");
            sb.AppendLine(indent, "/// The method is generated by a source generator.");
            sb.AppendLine(indent, "/// </summary>");
        }

        private static void WriteStub(StringBuilder sb, int indent)
        {
            WriteSummary(sb, indent);
            sb.AppendLine(indent, "public static ValueTask AddAsRowAsync(this Spreadsheet spreadsheet, object obj, CancellationToken token = default)");
            sb.AppendLine(indent, "{");
            sb.AppendLine(indent, "    // This will be filled in by the generator once you call AddAsRowAsync()");
            sb.AppendLine(indent, "    return new ValueTask();");
            sb.AppendLine(indent, "}");
        }

        private static void WriteMethods(StringBuilder sb, int indent, IEnumerable<ClassPropertiesInfo> infos)
        {
            foreach (var info in infos)
            {
                WriteSummary(sb, indent);
                sb.AppendLine(indent, $"public static ValueTask AddAsRowAsync(this Spreadsheet spreadsheet, {info.ClassType} obj, CancellationToken token = default)");
                sb.AppendLine(indent, "{");

                GenerateValidateMethodBody(sb, indent + 1, info);

                sb.AppendLine(indent, "}");
            }
        }

        private static void GenerateValidateMethodBody(StringBuilder sb, int indent, ClassPropertiesInfo info)
        {
            if (info.PropertyNames.Count > 0)
            {
                sb.AppendLine(indent, "var cells = new[]");
                sb.AppendLine(indent, "{");

                foreach (var propertyName in info.PropertyNames)
                {
                    sb.AppendLine(indent + 1, $"new DataCell(obj.{propertyName}),");
                }

                sb.AppendLine(indent, "};");
            }
            else
            {
                sb.AppendLine(indent, "var cells = System.Array.Empty<DataCell>();");
            }

            sb.AppendLine(indent, "return spreadsheet.AddRowAsync(cells, token);");
        }

        private static ICollection<ClassPropertiesInfo> GetClassPropertiesInfo(Compilation compilation, List<SyntaxNode> argumentsToValidate)
        {
            var foundTypes = new Dictionary<ITypeSymbol, ClassPropertiesInfo>(SymbolEqualityComparer.Default);

            foreach (var argument in argumentsToValidate)
            {
                var semanticModel = compilation.GetSemanticModel(argument.SyntaxTree);

                var classType = semanticModel.GetTypeInfo(argument).Type;
                if (classType is null)
                    continue;

                if (!foundTypes.TryGetValue(classType, out var info))
                {
                    info = ClassPropertiesInfo.CreateFrom(compilation, classType);
                    foundTypes.Add(classType, info);
                }

                info.Locations.Add(argument.GetLocation());
            }

            return foundTypes.Values;
        }
    }
}
