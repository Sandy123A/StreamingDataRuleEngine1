using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Quartic.ai.StreamingData.RuleEngine.Model;
using Quartic.ai.StreamingData.RuleEngine.Contract;
using Quartic.ai.StreamingData.RuleEngine.BusinessLogic;
using Quartic.ai.StreamingData.RuleEngine.Rules.RuleSets;
using System.Collections.ObjectModel;

namespace Quartic.ai.StreamingData.RuleEngine.ViewModel
{
    internal class RuleViewModel : ViewModelBase
    {
        #region Fields

        private UIRuleModel _uiRuleModel;
        private readonly IRuleEngine<BaseDomainModel,UIRuleModel> _ruleEngine;
        private readonly IRuleEngineBusinessLogic<BaseDomainModel, UIRuleModel> _ruleBusinessLogic;
        private string _filepath;
        #endregion

        #region Construction/Destruction

        internal RuleViewModel(string filepath)
        {
            _uiRuleModel = new UIRuleModel();
            _ruleBusinessLogic = new RuleEngineBusinessLogic(filepath);
            _ruleEngine = new RuleEngine.RuleEngine(_ruleBusinessLogic);
            _filepath = filepath;
        }
        #endregion

        #region Properties

        public UIRuleModel UiRuleModel
        {
            get { return _uiRuleModel; }
            set { _uiRuleModel = value; OnPropertyChanged("UiRuleModel"); }
        }

        public List<BaseDomainModel> ListExtractedSignalFromJson { get; set; }

        private List<UIRuleModel> _faultSignalsList;
        public List<UIRuleModel> FaultSignalsList
        {
            get { return _faultSignalsList; }
            set
            {
                _faultSignalsList = value;
                OnPropertyChanged("FaultSignalsList");
            }
        }
        #endregion

        #region Commands

        RelayCommand _getFaultSignalsCommand;
        public ICommand GetFaultSignalsCommand
        {
            get
            {
                if (_getFaultSignalsCommand == null)
                {
                    _getFaultSignalsCommand = new RelayCommand(param => GetAllFaultSignals());
                }
                return _getFaultSignalsCommand;
            }
        }
        #endregion

        #region Methods
        public void GetAllFaultSignals()
        {
            BaseDomainModel model = new DomainRuleModel();
            ListExtractedSignalFromJson = _ruleEngine.ExtractSignals();
            FaultSignalsList = _ruleEngine.GetFaultSignals(ListExtractedSignalFromJson);
        }
        #endregion
    }
}
