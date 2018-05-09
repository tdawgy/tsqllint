using System;
using System.Collections.Generic;
using NUnit.Framework;
using TSQLLint.Infrastructure.Rules;
using TSQLLint.Infrastructure.Rules.RuleViolations;

namespace TSQLLint.Tests.UnitTests.LintingRules
{
    public class MultiTableAliasRuleTests
    {
        private static readonly object[] TestCases =
        {
            new object[]
            {
                "multi-table-alias", "multi-table-alias-no-error",  typeof(MultiTableAliasRule), new List<RuleViolation>()
            },
            new object[]
            {
                "multi-table-alias", "multi-table-alias-one-error-with-tabs", typeof(MultiTableAliasRule), new List<RuleViolation>
                {
                    new RuleViolation("multi-table-alias", 2, 10)
                }
            },
            new object[]
            {
                "multi-table-alias", "multi-table-alias-one-error-with-spaces", typeof(MultiTableAliasRule), new List<RuleViolation>
                {
                    new RuleViolation("multi-table-alias", 2, 10)
                }
            },
            new object[]
            {
                "multi-table-alias", "multi-table-alias-multiple-errors-with-tabs", typeof(MultiTableAliasRule), new List<RuleViolation>
                {
                    new RuleViolation("multi-table-alias", 2, 6),
                    new RuleViolation("multi-table-alias", 3, 6),
                    new RuleViolation("multi-table-alias", 5, 6),
                    new RuleViolation("multi-table-alias", 14, 6)
                }
            },
            new object[]
            {
                "multi-table-alias", "multi-table-alias-multiple-errors-with-spaces", typeof(MultiTableAliasRule), new List<RuleViolation>
                {
                    new RuleViolation("multi-table-alias", 2, 6),
                    new RuleViolation("multi-table-alias", 3, 6),
                    new RuleViolation("multi-table-alias", 5, 6)
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
