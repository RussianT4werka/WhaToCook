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
    /// Логика взаимодействия для BLDWin.xaml
    /// </summary>

    public partial class BLDWin : Window, INotifyPropertyChanged
    {
        private BLD selectedBLD;

        public BLD SelectedBLD
        {
            get => selectedBLD;
            set
            {
                selectedBLD = value;
                Signals();
            }
        }

        public ObservableCollection<BLD> BLD
        {
            get => Data.BLD;
        }
        public BLDWin()
        {
            InitializeComponent();
            DataContext = this;
        }
        void Signals([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this,
                      new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void AddBLD(object sender, RoutedEventArgs e)
        {
            BLD.Add(new BLD { bld = "Завтрак" });
        }

        private void DeleteBLD(object sender, RoutedEventArgs e)
        {
            if (SelectedBLD == null)
                return;
            if (MessageBox.Show("Вы действительно хотете удалить выбранное?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                BLD.Remove(SelectedBLD);
            }
        }
    }

    }

