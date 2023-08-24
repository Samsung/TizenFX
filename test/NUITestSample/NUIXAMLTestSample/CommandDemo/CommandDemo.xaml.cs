using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Examples
{
    public class NameModel
    {
        string userName;
        string companyName;

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        public string CompanyName
        {
            get
            {
                return companyName;
            }
            set
            {
                companyName = value;
            }
        }
    }

    public class NameViewModel : INotifyPropertyChanged
    {
        public NameViewModel()
        {
            userName = new NameModel()
            {
                UserName = "Adun",
                CompanyName = "Samsung"
            };
        }

        NameModel userName;

        public event PropertyChangedEventHandler PropertyChanged;

        public string UserName
        {
            get
            {
                return userName.UserName;
            }
            set
            {
                userName.UserName = value;
                RaisePropertyChanged("UserName");
            }
        }

        public string CompanyName
        {
            get
            {
                return userName.CompanyName;
            }
            set
            {
                userName.CompanyName = value;
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        void UpdateNameExecute()
        {
            UserName = "Xiaohui Fang";
        }

        bool CanUpdateNameExecute()
        {
            return true;
        }

        public ICommand UpdateName { get { return new RelayCommand(UpdateNameExecute, CanUpdateNameExecute); } }
    }

    public class RelayCommand : ICommand
    {
        readonly Func<Boolean> _canExecute;
        readonly Action _execute;

        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action execute, Func<Boolean> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                {
                    //CommandManager.RequerySuggested += value;
                }
            }
            remove
            {
                if (_canExecute != null)
                {
                    //CommandManager.RequerySuggested -= value;
                }
                   
            }
        }

        [DebuggerStepThrough]
        public bool CanExecute(Object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        public void Execute(Object parameter)
        {
            _execute();
        }
    }

    public partial class CommandDemo
    {
        public CommandDemo()
        {
            InitializeComponent();
        }
    }
}
