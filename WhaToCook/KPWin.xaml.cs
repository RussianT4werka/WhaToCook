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
    /// Логика взаимодействия для KPWin.xaml
    /// </summary>
    
        public partial class KPWin : Page, INotifyPropertyChanged
        {
            private KP selectedKP;

            public KP SelectedKP
            {
                get => selectedKP;
                set
                {
                    selectedKP = value;
                    Signal();
                }
            }
            public ObservableCollection<KP> KP
            {
                get => Data.KP;
            }
            public KPWin()
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

            private void AddKP(object sender, RoutedEventArgs e)
            {
                KP.Add(new KP { kp = "1 порция"});

            }

            private void DeleteKP(object sender, RoutedEventArgs e)
            {
                if (SelectedKP == null)
                    return;
                if (MessageBox.Show("Вы действительно хотете удалить выбранный объект?",
                    "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    KP.Remove(SelectedKP);
                }
            }
        private void OpenPageMainWindow(object sender, RoutedEventArgs e)
        {
            Data.CurrentPage = new PageMainWindow();
        }
    }  
}
