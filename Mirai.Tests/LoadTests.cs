using System.IO;
using Mirai.Emitting;
using Xunit;

namespace Mirai.Tests
{
    public class LoadTests
    {
        [Fact]
        public void LoadTest()
        {
            var reader = new Reader();
            // var file = reader.Load(@"../../../../Mirai/bin/Debug/netcoreapp3.1/Mirai.dll");
            // var file = reader.Load(@"/usr/local/share/dotnet/shared/Microsoft.NETCore.App/3.1.6/Microsoft.CSharp.dll");
            foreach (var file in Directory.GetFiles(@"/usr/local/share/dotnet/shared/Microsoft.NETCore.App/3.1.6/", "*.dll"))
                reader.Load(file);
        }
    }
}