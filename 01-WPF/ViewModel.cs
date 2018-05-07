using System.ComponentModel;
using System.Windows.Input;

namespace WpfApp
{
    public class ViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _clickCount;
        private ICommand _clickMeCommand;

        public ViewModel()
        {
            _clickMeCommand = new Command(() => ClickCount++);
        }
        
        public int ClickCount
        {
            get { return _clickCount; }
            set
            {
                // optional if value not changed
                _clickCount = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(ClickCount)));
            }
        }

        public ICommand ClickMeCommand => _clickMeCommand;

    }
}
