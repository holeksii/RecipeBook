using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using wpf.ViewModels;
using wpf.Views;

namespace wpf.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "SignUp")
            {
                viewModel.SelectedViewModel = new RegisterViewModel();
            }
            else if (parameter.ToString() == "Login")
            {
                viewModel.SelectedViewModel = new LoginViewModel();
            }
        }
    }
}
