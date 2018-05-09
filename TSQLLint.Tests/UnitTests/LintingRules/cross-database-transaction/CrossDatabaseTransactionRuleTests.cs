using System;
using System.Collections.Generic;
using NUnit.Framework;
using TSQLLint.Infrastructure.Rules;
using TSQLLint.Infrastructure.Rules.RuleViolations;

namespace TSQLLint.Tests.UnitTests.LintingRules
{
    public class CrossDatabaseTransactionRuleTests
    {
        private static readonly object[] TestCases =
        {
            new object[]
            {
                "cross-database-transaction", "cross-database-transaction-no-error",  typeof(CrossDatabaseTransactionRule), new List<RuleViolation>()
            },
            new object[]
            {
                "cross-database-transaction", "cross-database-transaction-no-commit-no-error",  typeof(CrossDatabaseTransactionRule), new List<RuleViolation>()
            },
            new object[]
            {
                "cross-database-transaction", "cross-database-transaction-no-begintran-no-error",  typeof(CrossDatabaseTransactionRule), new List<RuleViolation>()
            },
            new object[]
            {
                "cross-database-transaction", "cross-database-transaction-no-error-single-line",  typeof(CrossDatabaseTransactionRule), new List<RuleViolation>()
            },
            new object[]
            {
                "cross-database-transaction", "cross-database-transaction-one-error",  typeof(CrossDatabaseTransactionRule), new List<RuleViolation>
                {
                    new RuleViolation("cross-database-transaction", 1, 1)
                }
            },
            new object[]
            {
                "cross-database-transaction", "cross-database-transaction-multiple-errors",  typeof(CrossDatabaseTransactionRule), new List<RuleViolation>
                {
                    new RuleViolation("cross-database-transaction", 1, 1),
                    new RuleViolation("cross-database-transaction", 6, 1)
                }
            },
            new object[]
            {
                "cross-database-transaction", "cross-database-transaction-nested-two-errors",  typeof(CrossDatabaseTransactionRule), new List<RuleViolation>
                {
                    new RuleViolation("cross-database-transaction", 1, 1),
                    new RuleViolation("cross-database-transaction", 5, 5)
                }
            },
            new object[]
            {
                "cross-database-transaction", "cross-database-transaction-one-error-single-line",  typeof(CrossDatabaseTransactionRule), new List<RuleViolation>
                {
                    new RuleViolation("cross-database-transaction", 1, 1)
                }
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void TestRule(string rule, string testFileName, Type ruleType, List<RuleViolation> expectedRuleViolations)
        {
            RulesTestHelper.RunRulesTest(rule, testFileName, ruleType, expectedRuleViolations);
        }
    }
}
