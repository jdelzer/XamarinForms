using JensCafeXamarinForms.Models;
using JensCafeXamarinForms.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace JensCafeXamarinForms.Services
{
    public class MenuDataService
    {
        private static MenuRepository menuRepository = new MenuRepository();

        public ObservableCollection<MenuItem> GetAllItems()
        {
            return menuRepository.GetAllMenuItems();
        }

        public IEnumerable<MenuGroup> GetGroupedItems()
        {
            return menuRepository.GetMenuGroups();
        }

        public ObservableCollection<MenuItem> GetItemsForGroup(int groupId)
        {
            return menuRepository.GetItemsForGroup(groupId);
        }

        public ObservableCollection<MenuItem> GetFavoriteItems()
        {
            return menuRepository.GetFavoriteItems();
        }

        public MenuItem GetItemById(int itemId)
        {
            return menuRepository.GetMenuItemById(itemId);
        }
    }
}