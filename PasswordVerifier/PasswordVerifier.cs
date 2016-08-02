using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordVerifier
{
    public class PasswordVerifier
    {
        private readonly Dictionary<RuleKey, Func<string, bool>> _validationStrategies;

        public PasswordVerifier()
        {
            _validationStrategies = new Dictionary<RuleKey, Func<string, bool>>
            {
                [RuleKey.NotNull] = password => !string.IsNullOrEmpty(password),
                [RuleKey.Length] = password => password.Length > 8,
                [RuleKey.ContainsUpperCase] = password => password.Any(char.IsUpper),
                [RuleKey.ContainsLowerCase] = password => password.Any(char.IsLower),
                [RuleKey.ContainsNumber] = password => password.Any(char.IsNumber)
            };
        }

        public bool Verify(string password)
        {
            return !VerifyPassword(password, new[] {RuleKey.NotNull, RuleKey.Length, RuleKey.ContainsUpperCase, RuleKey.ContainsLowerCase, RuleKey.ContainsNumber}).Any();
        }

        public void Verify(string password, RuleKey[] ruleKeys)
        {
            var validationResult = VerifyPassword(password, ruleKeys);
            if (validationResult.Any())
            {
                throw new PasswordVerificationException($"Validation rule(s) were violated: {string.Join(",", validationResult)}");
            }
        }

        private RuleKey[] VerifyPassword(string password, RuleKey[] ruleKeys)
        {
            var violatedRules = new List<RuleKey>();
            foreach (var ruleKey in ruleKeys)
            {
                bool validationResult = false;
                try
                {
                    validationResult = _validationStrategies[ruleKey](password);
                }
                catch (Exception e)
                {
                    //TODO: add logging
                }
                finally
                {
                    if (!validationResult)
                    {
                        violatedRules.Add(ruleKey);
                    }
                }
            }

            return violatedRules.ToArray();
        }
    }
}
