using Quartic.ai.StreamingData.RuleEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartic.ai.StreamingData.RuleEngine.Contract
{
    internal interface IRuleEngine<T1,T2> where T1 : BaseDomainModel where T2 : UIRuleModel
    {
        List<T1> ExtractSignals();
        List<T2> GetFaultSignals(IList<T1> model);
    }
}
