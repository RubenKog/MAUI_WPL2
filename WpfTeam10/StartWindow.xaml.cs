using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using ClassLibTeam10.Business.Entities;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClassLibTeam10.Business;

namespace WpfTeam10
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }


        private void StudentWindow_Click(object sender, RoutedEventArgs e)
        {
            StudentWindow studentWindow = new StudentWindow();
            studentWindow.Show();
        }

        private void SqlWindow_Click(object sender, RoutedEventArgs e)
        {
            var window = new SqlWindow(); 
            window.ShowDialog();
        }

        private void Close_Click(object sener, RoutedEventArgs e)
        {
            Close();
        }

        private void StartWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //for each item var in list convert to string
            //add to itemsource

            /*foreach (var item in Students.List() )
            {
                Convert.ToString(item.FirstName + " " + item.LastName);
                LbStartWindow.Items.Add(item.FirstName + " " + item.LastName);
            }*/
        }
    }
}
