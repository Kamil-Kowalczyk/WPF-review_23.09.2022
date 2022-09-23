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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_review
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isMale;
        public char firstNumber;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //&& (radioButtonSex1 == checked || radioButtonSex2 == checked || radioButtonSex3 == checked)
            if (!checkDate())
                MessageBox.Show("Try to choose other date");
            else if (textBoxName.Text != String.Empty && textBoxLastName.Text != String.Empty && (radioButtonSex1.IsChecked == true || radioButtonSex2.IsChecked == true || radioButtonSex3.IsChecked == true))
            {
                String name = textBoxName.Text;
                String lastName = textBoxLastName.Text;
                String mrOrMs = _isMale ? "Mr." : "Ms.";
                MessageBox.Show(firstNumber.ToString());
                MessageBox.Show($"Hello there {mrOrMs} {name} {lastName}!");
            }
            else
                MessageBox.Show("Make sure you filled in all fields");

        }

        private bool checkName(String name) 
        { 
        
            if (name.ToLower() == "kuba")
                return true;
            if (name[name.Length - 1] == 'a')
                return false;
            if (name.ToLower() == "Ines" || name.ToLower() == "Inez" || name.ToLower() == "Dolores")
                return false;

            return true;
        }

        private void radioGroupSex_Checked(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text != String.Empty)
            {
                var radio = sender as RadioButton;
                if (radio.Content.ToString() == "Male") 
                    if (!checkName(textBoxName.Text))
                    {
                        MessageBox.Show("Check if you entered the name correctly");
                        _isMale = false;
                        radio.IsChecked = false;   
                    }
                if (radio.Content.ToString() == "Female")
                    if (checkName(textBoxName.Text))
                    {
                        MessageBox.Show("Check if you entered the name correctly");
                        _isMale = true;
                        radio.IsChecked = false;
                    }
            }
        }

        private void datePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            /*var date = datePicker.SelectedDate;
            MessageBox.Show(date.ToString().Substring(6, 4));*/
        }

        private bool checkDate()
        {
            String date = datePicker.SelectedDate.ToString();
            if (date == String.Empty) 
                return false;
            if (int.Parse(date.Substring(6, 4)) < 1922 || int.Parse(date.Substring(6, 4)) > 2022) 
                return false;

            return true;
        }
    }
}
