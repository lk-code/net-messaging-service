using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace MessagingService.Test
{
    [TestClass]
    public class Initialize
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            Debug.WriteLine("Assembly Initialize");

            Startup.Init();

            Debug.WriteLine("Assembly Initialized");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            Debug.WriteLine("Assembly Cleanup");

            Debug.WriteLine("Assembly Cleanup finished");
        }
    }
}
