using System.Collections.Generic;
using NUnit.Framework;
using PackageManager = UnityEditor.PackageManager;

namespace Tests
{
    public class ExpectedPackages
    {
        private static string[] expectedPackages =
        {
            "com.unity.2d.sprite",
            "com.unity.2d.tilemap",
        };

        [Test]
        public void HasExpectedPackages()
        {
            var listRequest = PackageManager.Client.List(true);
            while (!listRequest.IsCompleted)
                System.Threading.Thread.Sleep(10);
            if (listRequest.Status == PackageManager.StatusCode.Failure)
                Assert.Fail("Failed to list local packages");

            var existingPackages = new List<PackageManager.PackageInfo>(listRequest.Result);
            foreach (var expectedPackage in expectedPackages)
            {
                if (!existingPackages.Exists(packageInfo => packageInfo.name.Equals(expectedPackage)))
                    Assert.Fail("{0} is not in the project template.", expectedPackage);
            }
        }
    }
}
