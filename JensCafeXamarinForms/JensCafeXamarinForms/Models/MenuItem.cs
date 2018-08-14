using JensCafeXamarinForms.Droid.Annotations;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace JensCafeXamarinForms.Models
{
    public class MenuItem
    {
        private int itemId;
        private string name;
        private string description;
        private string shortDescription;
        private string imagePath;
        private double price;
        private bool available;
        private int prepTime;
        private List<string> ingredients;
        private bool isFavorite;
        private string groupName;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public int ItemId
        {
            get => itemId;

            set
            {
                itemId = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => name;

            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => description;

            set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        public string ShortDescription
        {
            get => shortDescription;

            set
            {
                shortDescription = value;
                OnPropertyChanged();
            }
        }

        public string ImagePath
        {
            get => imagePath;

            set
            {
                imagePath = value;
                OnPropertyChanged();
            }
        }

        public double Price
        {
            get => price;

            set
            {
                price = value;
                OnPropertyChanged();
            }
        }

        public bool Available
        {
            get => available;

            set
            {
                available = value;
                OnPropertyChanged();
            }
        }

        public int PrepTime
        {
            get => prepTime;

            set
            {
                prepTime = value;
                OnPropertyChanged();
            }
        }

        public List<string> Ingredients
        {
            get => ingredients;

            set
            {
                ingredients = value;
                OnPropertyChanged();
            }
        }

        public bool IsFavorite
        {
            get => isFavorite;

            set
            {
                isFavorite = value;
                OnPropertyChanged();
            }
        }

        public string GroupName
        {
            get => groupName;

            set
            {
                groupName = value;
                OnPropertyChanged();
            }
        }
    }
}