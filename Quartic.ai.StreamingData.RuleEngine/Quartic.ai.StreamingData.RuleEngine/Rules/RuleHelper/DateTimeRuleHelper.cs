using System;

namespace Quartic.ai.StreamingData.RuleEngine.Rules.RuleSets
{
   internal class DateTimeRuleHelper
    {     
        internal static bool CheckValidDateTimeSignal(DateTime DateSignalValue)
        {
            var currentDate = DateTime.Now;
            var result = DateTime.Compare(DateSignalValue, currentDate);
            if (result > 0) return true;
            return false;
        }
    }
}
