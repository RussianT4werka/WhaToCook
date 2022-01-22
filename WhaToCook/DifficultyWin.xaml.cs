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
using System.Windows.Shapes;

namespace WhaToCook
{
    /// <summary>
    /// Логика взаимодействия для DifficultyWin.xaml
    /// </summary>
    public partial class DifficultyWin : Window, INotifyPropertyChanged
    {
        private Difficulty selectedDifficulty;

        public ObservableCollection<Difficulty> Difficulty
        {
            get => Data.Difficulty;
        }
        public ObservableCollection<KP> KPs
        {
            get => Data.KP;
        }

        public Difficulty SelectedDifficulty
        {
            get => selectedDifficulty;
            set
            {
                selectedDifficulty = value;
                Signal();
            }
        }
        
        public DifficultyWin()
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

        private void AddDifficulty(object sender, RoutedEventArgs e)
        {
            Difficulty.Add(new Difficulty { dif = "Легко" , time = "1 час" });
            
        }

        private void DeleteDifficulty(object sender, RoutedEventArgs e)
        {
            if (SelectedDifficulty == null)
                return;
            if (MessageBox.Show("Вы действительно хотете удалить выбранную сложность?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Difficulty.Remove(SelectedDifficulty);
            }
        }

    }
}
