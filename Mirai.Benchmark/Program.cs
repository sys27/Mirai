using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.CsProj;

namespace Mirai.Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
                args = new[] { "--filter", "*" };

            BenchmarkSwitcher
                .FromAssembly(typeof(Program).Assembly)
                .Run(args,
                    ManualConfig.Create(DefaultConfig.Instance)
                        .AddJob(Job.MediumRun
                            .WithLaunchCount(1)
                            .WithToolchain(CsProjCoreToolchain.NetCoreApp31))
                        .AddDiagnoser(MemoryDiagnoser.Default)
                        .StopOnFirstError());
        }
    }
}