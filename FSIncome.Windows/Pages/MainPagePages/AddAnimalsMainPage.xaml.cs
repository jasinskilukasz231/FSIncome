﻿using System;
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

namespace FSIncome.Windows.Pages.MainPagePages
{
    //THIS IS A COPY OF ADDANIMALSPAGE2 BUT WITH DIFFERENT SIZE
    public partial class AddAnimalsMainPage : Page
    {
        public bool goBack { get; set; } = false;
        public AddAnimalsMainPage()
        {
            InitializeComponent();
        }
        public string[] ReturnData()
        {
            string[] dataLine = new string[2];
            dataLine[0] = AnimalTypeExpander.Header.ToString();
            dataLine[1] = AmountTextBox.Text;

            AmountTextBox.Text = string.Empty;

            return dataLine;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (AmountTextBox.Text != string.Empty)
            {
                if (int.TryParse(AmountTextBox.Text, out int value))
                {
                    if (value > 0) goBack = true;
                    else MessageBox.Show("Inappropriate value");
                }
                else MessageBox.Show("Inappropriate value");
            }
            else MessageBox.Show("Enter all required data");

        }
        private void PigsCategoryButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AnimalTypeExpander.Header = "PIGS";
            AnimalTypeExpander.IsExpanded = false;
        }
        private void CowsCategoryButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AnimalTypeExpander.Header = "COWS";
            AnimalTypeExpander.IsExpanded = false;
        }

        private void ChickensCategoryButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AnimalTypeExpander.Header = "CHICKENS";
            AnimalTypeExpander.IsExpanded = false;
        }

        private void HorsesCategoryButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AnimalTypeExpander.Header = "HORSES";
            AnimalTypeExpander.IsExpanded = false;
        }
        private void SheepsCategoryButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AnimalTypeExpander.Header = "SHEEPS";
            AnimalTypeExpander.IsExpanded = false;
        }
    }
}
