using NUnit.Framework;
using UnityEditor;
using System.Collections;
using UnityEngine;

namespace Tests
{
    public class ExpectedSettings
    {
        static IEnumerable GraphicsJobsValidBuildTargets
        {
            get
            {
                yield return new TestCaseData(BuildTarget.Android);
                yield return new TestCaseData(BuildTarget.iOS);
                yield return new TestCaseData(BuildTarget.Lumin);
                yield return new TestCaseData(BuildTarget.PS4);
                yield return new TestCaseData(BuildTarget.Stadia);
                yield return new TestCaseData(BuildTarget.StandaloneLinux64);
                yield return new TestCaseData(BuildTarget.StandaloneOSX);
                yield return new TestCaseData(BuildTarget.StandaloneWindows);
                yield return new TestCaseData(BuildTarget.StandaloneWindows64);
                yield return new TestCaseData(BuildTarget.Switch);
                yield return new TestCaseData(BuildTarget.tvOS);
                yield return new TestCaseData(BuildTarget.WebGL);
                yield return new TestCaseData(BuildTarget.WSAPlayer);
                yield return new TestCaseData(BuildTarget.XboxOne);
            }
        }

        [Test]
        [TestCaseSource("GraphicsJobsValidBuildTargets")]
        public void GraphicsJobsIsDisabled(BuildTarget buildTarget)
        {
            bool actualValue = PlayerSettings.GetGraphicsJobsForPlatform(buildTarget);
            Assert.That(actualValue, Is.False);
        }

        [Test]
        public void Physics_AutoSyncTransformsShouldBeDisabled()
        {
            Assert.That(Physics.autoSyncTransforms, Is.False, "Physics.autoSyncTransforms should be OFF by default.");
        }

        [Test]
        public void Physics_ReuseCollisionCallbacksShouldBeEnabled()
        {
            Assert.That(Physics.reuseCollisionCallbacks, Is.True, "Physics.reuseCollisionCallbacks should be ON by default.");
        }

        [Test]
        public void Physics2D_AutoSyncTransformsShouldBeDisabled()
        {
            Assert.That(Physics2D.autoSyncTransforms, Is.False, "Physics2D.AutoSyncTransforms should be OFF by default.");
        }

        [Test]
        public void Physics2D_ReuseCollisionCallbacksShouldBeEnabled()
        {
            Assert.That(Physics2D.reuseCollisionCallbacks, Is.True, "Physics2D.reuseCollisionCallbacks should be ON by default.");
        }

        [Test]
        public void EditorSettings_LineEndingsForNewScriptsShouldBeOSNative()
        { 
            Assert.That(EditorSettings.lineEndingsForNewScripts, Is.EqualTo(LineEndingsMode.OSNative), "EditorSettings.lineEndingsForNewScripts is not set to OSNative");
        }
    }
}