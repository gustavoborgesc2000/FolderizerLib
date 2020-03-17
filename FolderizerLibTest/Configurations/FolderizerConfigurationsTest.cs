using FolderizerLib;
using FolderizerLib.Configuration;
using NUnit.Framework;
using System;
using System.IO;
using static System.Environment;

namespace FolderizerLibTest.Configuration
{
    public class FolderizerConfigurationsTest
    {

        private FolderizerConfigurations configurations;

        [SetUp]
        public void Setup()
        {
            configurations = new FolderizerConfigurations();
        }

        #region Set Base Path Tests
        [Test]
        public void SetBasePath_WhenExistentDirectory_BasePathPropertyShouldBeSet()
        {
            configurations.SetBasePath(TestPaths.ValidBasePath);
            Assert.AreEqual(TestPaths.ValidBasePath, configurations.BasePath);
        }

        [Test]
        public void SetBasePath_WhenNotExistentDirectory_ShouldThrowDirectoryNotFoundException()
        {
            Assert.Throws<DirectoryNotFoundException>(() => configurations.SetBasePath(""));
        }
        #endregion

        #region Set Output Path Tests
        [Test]
        public void SetOutputPath_WhenNotSet_ShouldBeSameAsBasePath()
        {
            configurations.SetBasePath(TestPaths.ValidOutputPath);
            Assert.AreEqual(TestPaths.ValidOutputPath, configurations.OutputPath);
        }

        [Test]
        public void SetOutputPath_WhenExistentDirectory_OutputPathPropertyShouldBeSet()
        {
            configurations.SetOutputPath(TestPaths.ValidOutputPath);
            Assert.AreEqual(TestPaths.ValidOutputPath, configurations.OutputPath);
        }


        [Test]
        public void SetOutputPath_WhenNotExistentDirectory_OutputPathPropertyShouldBeSet()
        {
            configurations.SetOutputPath(TestPaths.NotCreatedDirectory);
            Assert.AreEqual(TestPaths.NotCreatedDirectory, configurations.OutputPath);
        }
        #endregion

        #region Set Both Paths Tests

        [Test]
        public void SetBothPathsAtTheSameTime_WhenBothPathsExist_BothPropertiesShouldBeSet()
        {
            configurations.SetPaths(TestPaths.ValidBasePath, TestPaths.ValidOutputPath);
            Assert.AreEqual(TestPaths.ValidBasePath, configurations.BasePath);
            Assert.AreEqual(TestPaths.ValidOutputPath, configurations.OutputPath);
        }

        [Test]
        public void SetBothPathsAtTheSameTime_WhenBasePathDoesNotExist_ShouldThrowDirectoryNotFoundException()
        {
            Assert.Throws<DirectoryNotFoundException>(
                () => configurations.SetPaths(TestPaths.NotCreatedDirectory, TestPaths.ValidOutputPath));
        }

        [Test]
        public void SetBothPathsAtTheSameTime_WhenOutputPathDoesNotExist_BothPropertiesShouldBeSet()
        {
            configurations.SetPaths(TestPaths.ValidBasePath, TestPaths.NotCreatedDirectory);
            Assert.AreEqual(TestPaths.ValidBasePath, configurations.BasePath);
            Assert.AreEqual(TestPaths.NotCreatedDirectory, configurations.OutputPath);
        }
        #endregion

        #region Set Operation Method Tests
        [Test]
        public void SetOperationMethod_WhenDifferentFromDefaultMethod_OperationMethodPropertyShouldBeSet()
        {
            configurations.SetOperationMethods(OperationMethods.MoveFiles);
            Assert.AreEqual(OperationMethods.MoveFiles, configurations.OperationMethod);
        }

        [Test]
        public void SetOperationMethod_WhenNotSet_OperationMethodPropertyShouldBeCopy()
        {
            Assert.AreEqual(OperationMethods.CopyFiles, configurations.OperationMethod);
        }

        #endregion

        #region Set Maximum Search Depth Tests
        [Test]
        public void SetMaxSearchDepth_WhenDepthNotSet_DepthShouldBeZero()
        {
            Assert.AreEqual(0, configurations.MaxSearchDepth);
        }

        [Test]
        public void SetMaxSearchDepth_WhenDepthBiggerThanFive_ShouldThrowSearchDepthExceedsAcceptableLimitException()
        {
            Assert.Throws<SearchDepthExceedsAcceptableLimitException>(
                () => configurations.SetMaxSearchDepth(6));
        }

        [Test]
        public void SetMaxSearchDepth_WhenDepthLesserThanOrEqualToFive_SearchDepthPropertyShouldBeSet()
        {
            configurations.SetMaxSearchDepth(5);
            Assert.AreEqual(5, configurations.MaxSearchDepth);
        }

        #endregion
    }
}