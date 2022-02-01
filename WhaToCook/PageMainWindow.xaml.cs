using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WhaToCook
{
    /// <summary>
    /// Логика взаимодействия для PageMainWindow.xaml
    /// </summary>
    public partial class PageMainWindow : Page, INotifyPropertyChanged
    {
        private Food selectedFood;

        public ObservableCollection<Food> Foods
        {
            get => Data.Foods;
        }
        public ObservableCollection<BLD> BLD
        {
            get => Data.BLD;
        }
        public ObservableCollection<Difficulty> Difficulty
        {
            get => Data.Difficulty;
        }
        public ObservableCollection<Tip> Tip
        {
            get => Data.Tip;
        }


        






        public Food SelectedFood
        {
            get => selectedFood;
            set
            {
                selectedFood = value;
                Signal();
            }
        }

        public PageMainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        void Signal([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this,
                      new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void AddFood(object sender, RoutedEventArgs e)
        {
            Foods.Add(new Food
            {
                Nazv = "\t\t\t*БЛЮДО*",
            });
        }

        private void DeleteFood(object sender, RoutedEventArgs e)
        {
            if (SelectedFood == null)
                return;
            if (MessageBox.Show("Вы действительно хотите удалить выбранный рецепт?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Foods.Remove(SelectedFood);
                SelectedFood = null;
            }
        }

        private void OpenBLD(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BLDWin());  
        }
        private void OpenDifficulty(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DifficultyWin());
        }
        private void OpenTip(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TipWin());
        }
        private void OpenKP(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new KPWin());
        }
        private void OpenAd(object sender, RoutedEventArgs e)
        {
            AdWin win = new AdWin();
            win.ShowDialog();
        }
    }
}
