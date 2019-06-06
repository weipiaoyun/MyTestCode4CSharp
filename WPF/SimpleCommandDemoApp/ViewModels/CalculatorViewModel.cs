using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SimpleCommandDemoApp.Commands.Specific;
using SimpleCommandDemoApp.Model;

namespace SimpleCommandDemoApp.ViewModels
{
    public class CalculatorViewModel : ViewModelBase
    {

        private double firstValue;
        private double secondValue;
        private double output;

        ObservableCollection<DataList> dataLists = new ObservableCollection<DataList>();

        public ObservableCollection<DataList> DataLists
        {
            get { return dataLists;}
            set
            {
                OnPropertyChanged("DataLists");

            }
        }

        List<DataList> dataListsTest = new List<DataList>();

        public List<DataList> DataListsTest
        {
            get { return dataListsTest; }
            set
            {
                OnPropertyChanged("DataListsTest");

            }
        }

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
            //check The differences between ObservableCollection<T> and List<T> below,
            // DataLists is an ObservableCollection<T> class
            // and DataListsTest is a List<T> class
            if (DataLists != null)
            {
                DataLists.Add(new DataList() { Para = "p", Val = "v" });
                DataLists[0].Val = "v1";

                DataListsTest.Add(new DataList() {Para = "ptest", Val = "vtest"});
                DataListsTest[0].Val = "v1test";

            }
            else
            {
		DataLists = new ObservableCollection<DataList>();
                DataListsTest = new List<DataList>();
            }
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
