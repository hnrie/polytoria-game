using System;
using System.IO;
using Polytoria.Utils;
using Xunit;

namespace Polytoria.Tests
{
    public class PathUtilsTest
    {
        [Fact]
        public void Test_IsPathInsideDirectory()
        {
            string baseFolder = "/tmp/myproject";

            // Expected true: typical inside file
            Assert.True(PathUtils.IsPathInsideDirectory(Path.Combine(baseFolder, "docs/readme.txt"), baseFolder));
            // Expected true: base directory itself
            Assert.True(PathUtils.IsPathInsideDirectory(baseFolder, baseFolder));
            // Expected true: with trailing slash
            Assert.True(PathUtils.IsPathInsideDirectory(baseFolder + "/", baseFolder));

            // Expected false: different directory that starts with the same string (the vulnerability)
            Assert.False(PathUtils.IsPathInsideDirectory(Path.Combine("/tmp/myproject-secret", "flag.txt"), baseFolder));
            // Expected false: traversal escaping the base directory
            Assert.False(PathUtils.IsPathInsideDirectory(Path.Combine(baseFolder, "../myproject-secret/flag.txt"), baseFolder));
            // Expected false: complete escape
            Assert.False(PathUtils.IsPathInsideDirectory("/etc/passwd", baseFolder));
        }
    }
}
