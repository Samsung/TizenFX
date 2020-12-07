using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tizen.NUI;

namespace NUIBrokerSample
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Position2D mainPosition;

        public MainViewModel()
        {
            mainPosition = new Position2D(-50, 500);
        }

        public Position2D MainPosition
        {
            get
            {
                return mainPosition;
            }
            set
            {
                mainPosition = value;
                PageContents = string.Format($"Move {mainPosition.X}, {mainPosition.Y}");
                OnPropertyChanged("MainPosition");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private ICommand minusCommand;
        public ICommand MinusCommand
        {
            get { return (this.minusCommand) ?? (this.minusCommand = new DelegateCommand(Minus)); }
        }

        private void Minus()
        {
        }


        private ICommand plusCommand;
        public ICommand PlusCommand
        {
            get { return (this.plusCommand) ?? (this.plusCommand = new DelegateCommand(Plus)); }
        }

        private void Plus()
        {
        }

        private string pageContent;
        public string PageContents
        {
            get
            {
                return pageContent;
            }
            set
            {
                pageContent = value;
                OnPropertyChanged("PageContents");
            }
        }

    }
}
