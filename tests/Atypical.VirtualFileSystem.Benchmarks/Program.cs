using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Reports;

namespace Atypical.VirtualFileSystem.Benchmarks;

class Program
{
    static void Main(string[] args)
    {
        var config = DefaultConfig.Instance
            .AddExporter(MarkdownExporter.GitHub)
            .AddExporter(HtmlExporter.Default)
            .AddLogger(ConsoleLogger.Default)
            .AddColumn(StatisticColumn.Mean)
            .AddColumn(StatisticColumn.StdDev)
            .AddColumn(StatisticColumn.P95)
            .AddColumn(BaselineRatioColumn.RatioMean)
            .WithSummaryStyle(SummaryStyle.Default.WithRatioStyle(RatioStyle.Trend));

        // If no specific benchmark is requested, run all
        if (args.Length == 0)
        {
            Console.WriteLine("🚀 Virtual File System Benchmark Suite");
            Console.WriteLine("======================================");
            Console.WriteLine();
            Console.WriteLine("Available benchmark categories:");
            Console.WriteLine("  FileOperations    - File CRUD operations");
            Console.WriteLine("  DirectoryOperations - Directory operations");
            Console.WriteLine("  Search           - Search and navigation");
            Console.WriteLine("  Scale            - Large file system tests");
            Console.WriteLine("  UndoRedo         - Undo/Redo operations");
            Console.WriteLine();
            Console.WriteLine("Running ALL benchmarks...");
            Console.WriteLine();
            
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);
        }
        else
        {
            // Run specific benchmark based on command line argument
            var category = args[0].ToLowerInvariant();
            
            switch (category)
            {
                case "file":
                case "fileoperations":
                    BenchmarkRunner.Run<FileOperationsBenchmark>(config);
                    break;
                    
                case "dir":
                case "directory":
                case "directoryoperations":
                    BenchmarkRunner.Run<DirectoryOperationsBenchmark>(config);
                    break;
                    
                case "search":
                    BenchmarkRunner.Run<SearchBenchmark>(config);
                    break;
                    
                case "scale":
                    BenchmarkRunner.Run<ScaleBenchmark>(config);
                    break;
                    
                case "undo":
                case "undoredo":
                    BenchmarkRunner.Run<UndoRedoBenchmark>(config);
                    break;
                    
                case "all":
                    BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(new string[0], config);
                    break;
                    
                default:
                    Console.WriteLine($"❌ Unknown benchmark category: {category}");
                    Console.WriteLine("Available categories: file, directory, search, scale, undoredo, all");
                    Environment.Exit(1);
                    break;
            }
        }
        
        Console.WriteLine();
        Console.WriteLine("✅ Benchmark completed!");
        Console.WriteLine("📊 Results are available in:");
        Console.WriteLine("   - BenchmarkDotNet.Artifacts/results/ (detailed reports)");
        Console.WriteLine("   - Console output (summary)");
    }
}