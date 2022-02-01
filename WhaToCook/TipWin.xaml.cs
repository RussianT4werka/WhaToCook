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
    /// Логика взаимодействия для TipWin.xaml
    /// </summary>
    public partial class TipWin : Page, INotifyPropertyChanged
    {
        private Tip selectedTip;

        public Tip SelectedTip
        {
            get => selectedTip;
            set
            {
                selectedTip = value;
                Signal();
            }
        }
        public ObservableCollection<Tip> Tip
        {
            get => Data.Tip;
        }
        public TipWin()
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

        private void AddTip(object sender, RoutedEventArgs e)
        {
            Tip.Add(new Tip { tip = "Напиток"});
        }

        private void DeleteTip(object sender, RoutedEventArgs e)
        {
            if (SelectedTip == null)
                return;
            if (MessageBox.Show("Вы действительно хотете удалить выбранный тип?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Tip.Remove(SelectedTip);
            }
        }
        private void OpenPageMainWindow(object sender, RoutedEventArgs e)
        {
            Data.CurrentPage = new PageMainWindow();
        }
    }
}
