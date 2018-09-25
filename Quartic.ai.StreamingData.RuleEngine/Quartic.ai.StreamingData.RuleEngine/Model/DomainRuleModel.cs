namespace Quartic.ai.StreamingData.RuleEngine.Model
{
   internal class DomainRuleModel :BaseDomainModel
    {
        public override string signal { get; set; }
        public override string value { get; set; }
        public override string value_type { get; set; }
    }
}
