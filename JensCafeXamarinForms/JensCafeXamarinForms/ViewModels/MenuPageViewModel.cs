using JensCafeXamarinForms.Droid.Annotations;
using JensCafeXamarinForms.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace JensCafeXamarinForms.ViewModels
{
    public sealed class MenuPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Models.MenuItem> items { get; set; }
        public Models.MenuItem selectedItem;

        public MenuPageViewModel()
        {
            MenuDataService dataService = new MenuDataService();
            AllItems = dataService.GetAllItems();
        }

        public ObservableCollection<Models.MenuItem> AllItems
        {
            get { return items; }

            set
            {
                items = value;
                OnPropertyChanged();
            }
        }

        public Models.MenuItem SelectedItem
        {
            get { return selectedItem; }

            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}