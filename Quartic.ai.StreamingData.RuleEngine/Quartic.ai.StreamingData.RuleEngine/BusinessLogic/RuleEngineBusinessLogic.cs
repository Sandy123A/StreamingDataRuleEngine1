using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Newtonsoft.Json;
using Quartic.ai.StreamingData.RuleEngine.Contract;
using Quartic.ai.StreamingData.RuleEngine.Model;
using Quartic.ai.StreamingData.RuleEngine.Rules.RuleSets;


namespace Quartic.ai.StreamingData.RuleEngine.BusinessLogic
{
    internal class RuleEngineBusinessLogic : IRuleEngineBusinessLogic<BaseDomainModel, UIRuleModel>
    {
        #region Fields/Properties

        private string _filePath;
        #endregion

        #region Properties
        public IList<BaseDomainModel> ExtractedSignals { get; set; }
        #endregion

        #region Construction/Destruction

        internal RuleEngineBusinessLogic(string filePath)
        {
            _filePath = filePath;
        }
        #endregion

        #region Methods

        public List<BaseDomainModel> ExtractSignals()
        {
            List<BaseDomainModel> extractedSignalList;
            using (StreamReader read = new StreamReader(_filePath))
            {
                string json = read.ReadToEnd();
                extractedSignalList = JsonConvert.DeserializeObject<List<BaseDomainModel>>(json);
            }
            return extractedSignalList;
        }

        public List<UIRuleModel> GetFaultSignals(IRuleEngineBusinessLogic<BaseDomainModel, UIRuleModel> extractedSignals)
        {
            ExtractedSignals = extractedSignals.ExtractedSignals;
            var _faultSignals = new List<UIRuleModel>();
            var isFaultSignal = false;

            foreach (var item in ExtractedSignals)
            {
                switch (item.value_type)
                {
                    case "Integer":
                        isFaultSignal = IntegerRulesHelper.CheckValidIntegerSignal(Convert.ToDouble(item.value));
                        break;
                    case "String":
                        isFaultSignal = StringRulesHelper.CheckValidStringSignal(Convert.ToString(item.value));
                        break;
                    case "Datetime":
                        isFaultSignal = DateTimeRuleHelper.CheckValidDateTimeSignal(Convert.ToDateTime(item.value));
                        break;
                    default:
                        throw new InvalidOperationException("Invalid Value Type");
                }
                if (isFaultSignal)
                {
                    _faultSignals.Add(new UIRuleModel() { Signal = item.signal });
                }
            }

            WriteToFile(_faultSignals);

            return _faultSignals;
        }

        private void WriteToFile(List<UIRuleModel> FaultSignals)
        {
            try
            {
                //TODO:for now path is hardcoded due to time constraints 
             //   var path = @"E:\WriteLines2.txt";
                var FD = new System.Windows.Forms.SaveFileDialog();
                if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string path = FD.FileName;

                    using (StreamWriter str = new StreamWriter(path))
                    {
                        foreach (UIRuleModel item in FaultSignals)
                        {
                            str.WriteLine(item.Signal);
                        }
                        str.Flush();
                    }
                    MessageBox.Show(string.Format("File created successfuly in {0} ", path));
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show("Directory Not Found :" + ex.ToString());
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("File Not Found :" + ex.ToString());
            }
            catch (IOException ex)
            {
                MessageBox.Show("IO Exception :" + ex.ToString());
            }
        }
        #endregion
    }



}

