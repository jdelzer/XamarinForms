using System.Collections.ObjectModel;

namespace JensCafeXamarinForms.Models
{
    public class MenuGroup
    {
        public int MenuGroupId { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public ObservableCollection<MenuItem> MenuItems { get; set; }
    }
}