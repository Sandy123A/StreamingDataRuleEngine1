using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartic.ai.StreamingData.RuleEngine.Contract;
using Quartic.ai.StreamingData.RuleEngine.Model;

namespace Quartic.ai.StreamingData.RuleEngine.RuleEngine
{
   internal class RuleEngine:IRuleEngine<BaseDomainModel,UIRuleModel>
    {
        private readonly IRuleEngineBusinessLogic<BaseDomainModel,UIRuleModel>  _ruleBusinessLogic;
 
        internal RuleEngine(IRuleEngineBusinessLogic<BaseDomainModel, UIRuleModel> RuleBusinessLogic)
        {
            _ruleBusinessLogic = RuleBusinessLogic;
        }

        public List<BaseDomainModel> ExtractSignals()
        {
           return _ruleBusinessLogic.ExtractSignals();
      
        }

        public List<UIRuleModel> GetFaultSignals(IList<BaseDomainModel> extractedSignals)
        {
            _ruleBusinessLogic.ExtractedSignals = extractedSignals;
           return _ruleBusinessLogic.GetFaultSignals(_ruleBusinessLogic);
        }
    }
}
