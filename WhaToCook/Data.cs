using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace WhaToCook
{
    static class Data
    {
        public static ObservableCollection<Food> Foods = new ObservableCollection<Food>();
        public static ObservableCollection<BLD> BLD = new ObservableCollection<BLD>();
        public static ObservableCollection<Main> Main = new ObservableCollection<Main>();
        public static ObservableCollection<Difficulty> Difficulty = new ObservableCollection<Difficulty>();
        public static ObservableCollection<Tip> Tip = new ObservableCollection<Tip>();
        public static ObservableCollection<KP> KP = new ObservableCollection<KP>();
        private static Page currentPage;
        public static event EventHandler CurrentPageChanged;
        public static Page CurrentPage
        {
            get => currentPage;
            internal set
            {
                currentPage = value;
                CurrentPageChanged?.Invoke(CurrentPage, new EventArgs());
            }
        }
    }
}
