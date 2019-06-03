﻿using SimpleCommandDemoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleCommandDemoApp.Commands.Specific
{
    public  class PlusCommand : ICommand
    {
        // Creating private field of CalculatorViewModel and passing calculatorViewModel into the constructor
        private CalculatorViewModel calculatorViewModel;
        public PlusCommand(CalculatorViewModel vm)
        {
            calculatorViewModel = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            calculatorViewModel.Add();
        }

        public event EventHandler CanExecuteChanged;
    }
}
