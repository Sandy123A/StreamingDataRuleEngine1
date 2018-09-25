
namespace Quartic.ai.StreamingData.RuleEngine.Model
{
    internal class UIRuleModel:ViewModelBase
    {
        private string _signal1;

        public string Signal
        {
            get { return _signal1; }
            set
            {
                _signal1 = value;
                OnPropertyChanged("Signal");
            }
        }
    }
}
