
namespace Quartic.ai.StreamingData.RuleEngine.Rules.RuleSets
{
    internal class StringRulesHelper
    {
        internal static bool CheckValidStringSignal(string SignalStringValue)
        {
            string _stringValueToCompare = "LOW";
            if (SignalStringValue.Equals(_stringValueToCompare)) return true;
            return false;
        }
    }
}
