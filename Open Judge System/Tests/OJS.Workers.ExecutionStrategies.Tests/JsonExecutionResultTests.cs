﻿namespace OJS.Workers.ExecutionStrategies.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class JsonExecutionResultTests
    {
        private const string ParseErrorMessage = "Invalid console output!";

        [Test]
        public void MochaExecutionResultParseShouldReturnCorrectNumberOfTotalTests()
        {
            var jsonString = "{stats: {passes: 3, tests: 4}, tests: []}";

            var result = JsonExecutionResult.Parse(jsonString);

            var expected = 4;
            Assert.AreEqual(expected, result.TotalTests, "Incorrect amount of Total Tests returned");
            Assert.IsNullOrEmpty(result.Error, "Error field was not empty with a correct output");
        }

        [Test]
        public void MochaExecutionResultParseShouldReturnCorrectNumberOfPassedTests()
        {
            var jsonString = "{stats: {passes: 3, tests: 4}, tests: []}";

            var result = JsonExecutionResult.Parse(jsonString);

            var expected = 3;
            Assert.AreEqual(expected, result.TotalPasses, "Incorrect ammount of passed tests returned.");
            Assert.IsNullOrEmpty(result.Error, "Error field was not empty with a correct output");
        }

        [Test]
        public void MochaExecutionResultParseShouldReturnCorrectErrorMessageWhenTheInputCannotBeParsed()
        {
            var jsonString = "{stats: {passes: 0}, f";

            var result = JsonExecutionResult.Parse(jsonString);

            Assert.AreEqual(ParseErrorMessage, result.Error, "Incorrect Error message set.");
        }

        [Test]
        public void MochaExecutionResultParseShouldReturnCorrectErrorMessageWhenTheInputDoesNotContainAllRequiredFields()
        {
            var jsonString = "{stats: {passes: 0, tests: 3}}";

            var result = JsonExecutionResult.Parse(jsonString);

            Assert.AreEqual(ParseErrorMessage, result.Error, "Incorrect Error message set.");
        }

        [Test]
        public void MochaExecutionResultParseShouldReturnCorrectErrorMessages()
        {
            var jsonString = @"{stats: {passes: 1, tests: 3}, tests:[ {err: {message: ""Error: expected 1 to equal 2"", stack: ""Some stack""}}, {err:{}}, {err: {message: ""Error: expected 'a' to equal 'b'"", stack: ""Another stack trace""}}]}";

            var result = JsonExecutionResult.Parse(jsonString);

            var errorMessage1 = "Error: expected 1 to equal 2";
            var errorMessage2 = "Error: expected 'a' to equal 'b'";
            Assert.AreEqual(errorMessage1, result.TestsErrors[0], "Incorrect Error message returned");
            Assert.IsNull(result.TestsErrors[1], "Error message was returned on a passing test");
            Assert.AreEqual(errorMessage2, result.TestsErrors[2], "Incorrect Error message returned");
            Assert.IsNullOrEmpty(result.Error, "Error field was not empty with a correct output");
        }

        [Test]
        public void MochaExecutionResultParseShouldFailParsingWithCommentInJsonString()
        {
            var jsonString = "{stats: {passes: 1, tests: 6}, tests: []} /* comment */ {stats: {passes: 1, tests: 1}, tests: []}";

            var result = JsonExecutionResult.Parse(jsonString);

            Assert.AreEqual(0, result.TotalPasses, "Incorrect number of Passed Tests returned.");
            Assert.AreEqual(0, result.TotalTests, "Incorrect number of Total Tests returned");
            Assert.AreEqual(ParseErrorMessage, result.Error, "Incorrect Error message set.");
        }

        [Test]
        public void MochaExecutionResultParseShouldFailParsingWithDoubleCommentInJsonString()
        {
            var jsonString = @"{stats: {passes: 1, tests:2}, tests: []} //** comment **// {stats: {passes: 2, tests:3}, tests: [{err: {message: ""Error: expected 1 to equal 2"", stack: ""Some stack""}}]}";

            var result = JsonExecutionResult.Parse(jsonString);

            Assert.AreEqual(0, result.TotalPasses, "Incorrect number of Passed Tests returned.");
            Assert.AreEqual(0, result.TotalTests, "Incorrect number of Total Tests returned");
            Assert.AreEqual(ParseErrorMessage, result.Error, "Incorrect Error message set.");
        }
    }
}
