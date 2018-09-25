
namespace Quartic.ai.StreamingData.RuleEngine.Rules.RuleSets
{
    internal class IntegerRulesHelper
    {
        internal static bool CheckValidIntegerSignal(double SignalIntegerValue)
        {
            double _integerValueToCompare = 240.00;
            if (SignalIntegerValue > _integerValueToCompare) return true;
            return false;
        }
    }
}
