﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using TheBestCarShop___Admin.IN_PROGRESS;
using TheBestCarShop___Admin.Validators;

namespace TheBestCarShop___Admin.Commands
{
    public class RegisterCommand : ICommand
    {
        private ProductValidator _PRODUCTVALIDATOR = new ProductValidator();

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            Product product = parameter as Product;
            
            if(product is null)
            {
                return false;
            }
            ValidationResult output = _PRODUCTVALIDATOR.Validate(product);
            product.Errors = string.Join("\n", output.Errors);
            return output.IsValid;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("Hello", "Learning", MessageBoxButton.YesNo);
        }
    }
}
            
