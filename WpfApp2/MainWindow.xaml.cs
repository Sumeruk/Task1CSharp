using System;
using System.Windows;
using System.Windows.Controls;
using BookLibrary;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BookInformation bookInformation;
        public MainWindow()
        {
            InitializeComponent();

            comboBoxState.Items.Add("Нет статуса");
            comboBoxState.Items.Add(State.В_фонде);
            comboBoxState.Items.Add(State.Выдана);
            comboBoxState.Items.Add(State.В_реставрации);

            // Выбор элемента по умолчанию
            comboBoxState.SelectedIndex = 0;
            
            comboBoxChangedState.Items.Add("Нет статуса");
            comboBoxChangedState.Items.Add(State.В_фонде);
            comboBoxChangedState.Items.Add(State.Выдана);
            comboBoxChangedState.Items.Add(State.В_реставрации);

            // Выбор элемента по умолчанию
            comboBoxChangedState.SelectedIndex = 0;
        }

        private void BookIdChangeButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (bookInformation == null)
            {
                MessageBox.Show("Нельзя производить операции с книгой, которая не была создана");
            }
            else
            {
                try
                {
                    bookInformation.ChangeBookId(NewBookIdBox.Text);
                    MessageBox.Show(bookInformation.ToString());
                }
                catch (ArgumentException exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }

            RefreshApp();

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                bookInformation = new BookInformation(
                
                BookIdBox.Text,
                NameBox.Text,
                AuthorBox.Text,
                int.Parse(PagesBox.Text),
                GenreBox.Text,
                (State)Enum.Parse(typeof(State), comboBoxState.Text));

            MessageBox.Show(bookInformation.ToString());
            }

            catch (ArgumentException exc)
            {
               MessageBox.Show(exc.Message);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Введены некорректные значения для числовых полей");
            }

            RefreshApp();

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonChangeState_Click(object sender, RoutedEventArgs e)
        {
            if (bookInformation == null)
            {
                MessageBox.Show("Нельзя производить операции с книгой, которая еще не была создана");
            }
            else
            {
                try
                {
                    bookInformation.ChangeState((State)Enum.Parse(typeof(State), comboBoxChangedState.Text));
                }
                catch (ArgumentException exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }

            RefreshApp();

        }

        private void RefreshApp()
        {
            if (bookInformation != null)
                BookInformation.Text = bookInformation.ToString();
        }
    }
}
