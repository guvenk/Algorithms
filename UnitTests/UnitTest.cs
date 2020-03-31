using Algorithms;
using System;
using System.Linq;
using Xunit;

namespace UnitTests
{
    public class UnitTest
    {
        [Theory]
        [InlineData("{[()]}", "YES")]
        [InlineData("{[(])}", "NO")]
        [InlineData("{{[[(())]]}}", "YES")]
        [InlineData("}][}}(}][))]", "NO")]
        [InlineData("[](){()}", "YES")]
        [InlineData("()", "YES")]
        [InlineData("({}([][]))[]()", "YES")]
        [InlineData("{)[](}]}]}))}(())(", "NO")]
        [InlineData("([[)", "NO")]
        public void Test1(string word, string expected)
        {
            string ans = BalancedParanthesis.IsBalanced(word);

            Assert.Equal(expected, ans);
            Assert.Equal(expected, ans);
            Assert.Equal(expected, ans);
        }

        //[Theory]
        //[InlineData("A2Le", "2pL1", true)]
        //[InlineData("ba1", "1Ad", false)]
        //[InlineData("a10", "10a", true)]
        //[InlineData("3x2x", "8", false)]
        //[InlineData("aaa2", "3cc", true)]
        //[InlineData("aaa10", "3cctt6", true)]
        //[InlineData("aaa10", "3cctt14", false)]
        //public void Test(string str1, string str2, bool expected)
        //{
        //    bool result = Helper.AreStringsEqual(str1, str2);
        //    Assert.Equal(expected, result);

        //}

    }
}
