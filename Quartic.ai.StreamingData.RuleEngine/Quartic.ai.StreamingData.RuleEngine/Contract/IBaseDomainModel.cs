using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartic.ai.StreamingData.RuleEngine.Contract
{
    internal interface IBaseDomainModel
    {
         string signal { get; set; }
         string value { get; set; }
         string value_type { get; set; }
    }
}
