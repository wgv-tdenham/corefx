// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.IO;
using Xunit;

namespace System.Net.NetworkInformation.Tests
{
    public class MiscParsingTests : FileCleanupTestBase
    {
        [Fact]
        public void NumRoutesParsing()
        {
            string fileName = GetTestFilePath();
            FileUtil.NormalizeLineEndings("route", fileName);
            int numRoutes = StringParsingHelpers.ParseNumRoutesFromRouteFile(fileName);
            Assert.Equal(4, numRoutes);
        }

        [Fact]
        public void DefaultTtlParsing()
        {
            string fileName = GetTestFilePath();
            FileUtil.NormalizeLineEndings("snmp", fileName);
            int ttl = StringParsingHelpers.ParseDefaultTtlFromFile(fileName);
            Assert.Equal(64, ttl);
        }

        [Fact]
        public static void RawIntFileParsing()
        {
            int val = StringParsingHelpers.ParseRawIntFile("rawint");
            Assert.Equal(12, val);

            int max = StringParsingHelpers.ParseRawIntFile("rawint_maxvalue");
            Assert.Equal(int.MaxValue, max);
        }

        [Fact]
        public static void RawLongFileParsing()
        {
            long val = StringParsingHelpers.ParseRawLongFile("rawlong");
            Assert.Equal(3147483647L, val);

            long max = StringParsingHelpers.ParseRawLongFile("rawlong_maxvalue");
            Assert.Equal(long.MaxValue, max);
        }

        [Fact]
        public static void RawHexIntParsing()
        {
            int val = StringParsingHelpers.ParseRawHexFileAsInt("rawhexint");
            Assert.Equal(10, val);
        }
    }
}
