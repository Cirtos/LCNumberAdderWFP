using ScreeningAdder.Commands;
using ScreeningAdder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ScreeningAdder.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Adder _adder {  get; set; }
        private string _firstText;
        public string FirstText {
            get { 
                return _firstText; 
            }
            set {
                _firstText = value;
                Calculate.InvokeCanExecuteChanged();
            }
        }
        private string _secondText;
        public string SecondText {
            get { 
                return _secondText; 
            }
            set {
                _secondText = value;
                Calculate.InvokeCanExecuteChanged();
            }
        }

        private string _outcomeText;

        public string OutcomeText
        {
            get
            {
                return _outcomeText;
            }
            set
            {
                _outcomeText = value;
                RaisePropertyChangedEvent("OutcomeText");
            }
        }

        public DelegateCommand Calculate { get; private set; }

        public MainWindowViewModel()
        {
            if(_firstText == null) 
            {
                _firstText = "";
            }
            if (_secondText == null)
            {
                _secondText = "";
            }
            _adder = new Adder();
            Calculate = new DelegateCommand(() => SetAddition(), TextIsInt);
        }

        public bool TextIsInt(object obj)
        {
            if(int.TryParse(_firstText, out int value) && int.TryParse(_secondText, out int value2)){
                return true;
            }

            return false;
        }

        public void SetAddition()
        {
            OutcomeText = _adder.Add(int.Parse(_firstText), int.Parse(_secondText)).ToString();
        }
    }
}
