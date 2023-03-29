using System;
using System.Collections;
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
using ICE_1__words_API;
using ICE_1__words_API.Controllers;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Wordle_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WordsController controller = new WordsController();
        GuessWord guessWord = new GuessWord();

        public static string? lang;
        public static string? word;

        public ArrayList arrPositionResults = new ArrayList();
        public ArrayList arrContainsResults = new ArrayList();
        int attempts = 5;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGuess_Click(object sender, RoutedEventArgs e)
        {
            string wordInput = txtGuess.Text;
            bool result = false;

            getLangauge();
            result = guessWord.checkWord(wordInput, word.ToLower());

           
                if (result)
                {
                    MessageBox.Show("Well done! You guessed correctly");

                }
                else
                {
                    attempts--;
                    MessageBox.Show("Sorry, that is the incorrect word. You have " + attempts + " left");
                }


            if (attempts == 0)
            {
                MessageBox.Show("GAME OVER!\n"+"THE CORRECT WORD WAS " + word.ToUpper());
                attempts = 5;
                SetDefualtValues();
            }


        }


        public void getWord()
        {
            word = controller.GetSingle(lang);
            txtTest.Text = word;
            txtHint.Text = "Hint: Word contains " + word.Length + " characters";
        }

        public void getLangauge()
        {
            if (cmbLanguages.SelectedIndex == 0){ lang = "Afrikaans";}
            else if (cmbLanguages.SelectedIndex == 1) { lang = "English"; }
            else if (cmbLanguages.SelectedIndex == 2) { lang = "Xhosa"; }
            
                          
        }

        private void cmbLanguages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            getLangauge();
            getWord();
            cmbLanguages.IsEnabled = false;

        }

        public void SetupScreen()
        {
            InitializeComponent();
            SetDefualtValues();

        }

        public void SetDefualtValues()
        {
            attempts = 5;
            cmbLanguages.SelectedIndex = -1;
            cmbLanguages.IsEnabled = true;
            txtGuess.Text = "";
            txtHint.Text = "";
            txtResult.Document.Blocks.Clear();
            txtTest.Text = "";
            

        }
        
    }


   

}
