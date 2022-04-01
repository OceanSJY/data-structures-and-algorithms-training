// <copyright file="TestCase.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.LeetCodeCases.No5.LongestPalindromicSubstring
{
    using BenchmarkDotNet.Attributes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.LeetCode.No5.LongestPalindromicSubstring;

    /// <summary>
    /// The test class of LeetCode No.5 question: Longest Palindromic Substring.
    /// </summary>
    [TestClass]
    public class TestCase : LeetCodeBaseTestCase<string>
    {
        /// <summary>
        /// The solution of LeetCode No.5 question: Longest Palindromic Substring.
        /// </summary>
        private readonly IQuestion solution;

        /// <summary>
        /// The official answer A of LeetCode No.5 question: Longest Palindromic Substring.
        /// </summary>
        private readonly IQuestion officialAnswerA;

        /// <summary>
        /// The official answer B of LeetCode No.5 question: Longest Palindromic Substring.
        /// </summary>
        private readonly IQuestion officialAnswerB;

        /// <summary>
        /// The official answer C of LeetCode No.5 question: Longest Palindromic Substring.
        /// </summary>
        private readonly IQuestion officialAnswerC;

        /// <summary>
        /// The expected results from official answers.
        /// </summary>
        private readonly string[] expectedResultsFromOfficialAnswers;

        /// <summary>
        /// The test string.
        /// </summary>
        private readonly string testString =
            "mqizdjrfqtmcsruvvlhdgzfrmxgmmbguroxcbhalzggxhzwfznfkrdwsvzhieqvsrbyedqxwmnvovvnesphgddoikfwuujrhxwcrbttfbmlayrlmpromlzwzrkjkzdvdkpqtbzszrngczvgspzpfnvwuifzjdrmwfadophxscxtbavrhfkadhxrmvlmofbzqshqxazzwjextdpuszwgrxirmmlqitjjpijptmqfbggkwaolpbdglmsvlwdummsrdyjhmgrasrblpjsrpkkgknsucsshjuxunqiouzrdwwooxclutkrujpfebjpoodvhknayilcxjrvnykfjhvsikjabsdnvgguoiyldshbsmsrrlwmkfmyjbbsylhrusubcglaemnurpuvlyyknbqelmkkyamrcmjbncpafchacckhymtasylyfjuribqxsekbjkgzrvzjmjkquxfwopsbjudggnfbuyyfizefgxamocxjgkwxidkgursrcsjwwyeiymoafgyjlhtcdkgrikzzlenqgtdukivvdsalepyvehaklejxxmmoycrtsvzugudwirgywvsxqapxyjedbdhvkkvrxxsgifcldkspgdnjnnzfalaslwqfylmzvbxuscatomnmgarkvuccblpoktlpnazyeazhfucmfpalbujhzbykdgcirnqivdwxnnuznrwdjslwdwgpvjehqcbtjljnxsebtqujhmteknbinrloregnphwhnfidfsqdtaexencwzszlpmxjicoduejjomqzsmrgdgvlrfcrbyfutidkryspmoyzlgfltclmhaeebfbunrwqytzhuxghxkfwtjrfyxavcjwnvbaydjnarrhiyjavlmfsstewtxrcifcllnugldnfyswnsewqwnvbgtatccfeqyjgqbnufwttaokibyrldhoniwqsflvlwnjmffoirzmoxqxunkuepj";

        /// <summary>
        /// Initializes a new instance of the <see cref="TestCase"/> class.
        /// </summary>
        public TestCase()
        {
            this.solution = new Solution();
            this.officialAnswerA = new OfficialAnswerA();
            this.officialAnswerB = new OfficialAnswerB();
            this.officialAnswerC = new OfficialAnswerC();

            this.expectedResultsFromOfficialAnswers = new[]
            {
                this.officialAnswerA.LongestPalindrome(this.testString),
                this.officialAnswerB.LongestPalindrome(this.testString),
                this.officialAnswerC.LongestPalindrome(this.testString),
            };
        }

        /// <summary>
        /// Gets all official answers of LeetCode No.5 question: Longest Palindromic Substring.
        /// </summary>
        public IQuestion[] OfficialAnswers => new[]
        {
            this.officialAnswerA,
            this.officialAnswerB,
            this.officialAnswerC,
        };

        /// <summary>
        /// Gets or sets current official answer.
        /// </summary>
        [ParamsSource(nameof(OfficialAnswers))]
        public IQuestion CurrentOfficialAnswer { get; set; }

        /// <summary>
        /// Verifies the result from MedianOfTwoSortedArrays solution A whether it is as same as the result from official answers.
        /// </summary>
        [TestMethod]
        public void VerifyLongestPalindromicSubstringSolutionResult()
        {
            var actualResult = this.GetResultFromSolution();

            foreach (var expectedResult in this.expectedResultsFromOfficialAnswers)
            {
                Assert.AreEqual(expectedResult, actualResult);
            }
        }

        /// <inheritdoc />
        [Benchmark]
        public override string GetResultFromSolution()
        {
            return this.solution.LongestPalindrome(this.testString);
        }

        /// <inheritdoc />
        [Benchmark]
        public override string GetResultFromOfficialAnswer()
        {
            return this.CurrentOfficialAnswer.LongestPalindrome(this.testString);
        }
    }
}
