using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SimpleCommandDemoApp.Commands.Specific;

namespace SimpleCommandDemoApp.ViewModels
{
    public class CalculatorViewModel : ViewModelBase
    {

        private double firstValue;
        private double secondValue;
        private double output;

        public double FirstValue
        {
            get
            {
                return firstValue;
            }
            set
            {
                firstValue = value;
                OnPropertyChanged("FirstValue");
            }
        }




        public double SecondValue
        {
            get
            {
                return secondValue;
            }
            set
            {
                secondValue = value;
                OnPropertyChanged("SecondValue");
            }
        }


        public double Output
        {
            get
            {
                return output;
            }
            set
            {
                output = value;

                OnPropertyChanged("Output");
            }
        }


        private PlusCommand plusCommand;
        public CalculatorViewModel()
        {

            plusCommand = new PlusCommand(this);
        }

        public void Add()
        {
            Output = firstValue + secondValue;
        }

        public ICommand AddCommand
        {
            get
            {
                return new Commands.Generic.RelayCommand(Add);
                //return plusCommand;
                // return new RelayCommand();
            }
        }



        public class RelayCommand : ICommand
        {
            private ICommand _commandImplementation;

            //public RelayCommand(Action add)
            //{
            //    throw new NotImplementedException();
            //}

            public bool CanExecute(object parameter)
            {
                return _commandImplementation.CanExecute(parameter);
            }

            public void Execute(object parameter)
            {
                _commandImplementation.Execute(parameter);
            }

            public event EventHandler CanExecuteChanged;

        }
    }
}
