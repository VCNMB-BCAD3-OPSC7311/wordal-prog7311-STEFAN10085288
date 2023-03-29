using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Razor;
using NLog.Layouts;

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

        public List<bool> arrPositionResults = new List<bool>();  
        public List<bool> arrContainsResults = new List<bool>();

        public ArrayList arrWordInputLetter = new ArrayList();
        public List<TextBlock> arrTextBlocks = new List<TextBlock>();
        public TextBox[] textBoxes = new TextBox[5];
        
        int attempts = 5;

        private Paragraph paragraph;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGuess_Click(object sender, RoutedEventArgs e)
        {
            arrTextBlocks.Add(txt1);
            arrTextBlocks.Add(txt2);
            arrTextBlocks.Add(txt3);
            arrTextBlocks.Add(txt4);
            arrTextBlocks.Add(txt5);


            string wordInput = txtGuess.Text;
            bool result = false;

            getLangauge();
            result = guessWord.checkWord(wordInput.ToLower(), word.ToLower());
           
            if (result)
            {
                MessageBox.Show("Well done! You guessed correctly");
                attempts = 5;
                SetDefualtValues();
            }
            else
            {
                attempts--;
                MessageBox.Show("Sorry, that is the incorrect word. You have " + attempts + " attempts left");
             }


            if (attempts == 0)
            {
                MessageBox.Show("GAME OVER!\n"+"THE CORRECT WORD WAS " + word.ToUpper() + "\nCLICK OK TO RESET");
                attempts = 5;
                SetDefualtValues();
            }
            

 
            for (int i = 0; i <= wordInput.Length-1; i++)
            {

                arrContainsResults = guessWord.checkCharacterContain(wordInput[i].ToString().ToLower(), word.ToLower());
                arrPositionResults = guessWord.checkCharacterPosition(wordInput[i].ToString().ToLower(), word.ToLower());
                arrTextBlocks[i].Text = wordInput[i].ToString();

                if (arrPositionResults[i] && arrContainsResults[i])
                {                 
                    arrTextBlocks[i].Foreground = Brushes.Green;
                }
                else if (arrContainsResults[i] && !arrPositionResults[i])
                {
                    arrTextBlocks[i].Foreground = Brushes.Yellow;
                }
                else if (!arrContainsResults[i] && !arrPositionResults[i])
                {
                    arrTextBlocks[i].Foreground = Brushes.Red;
                }
                
            }

            SetDefualtValues();

        }


        public void getWord()
        {
            word = controller.GetSingle(lang);
            txtTest.Text = word;
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

        public void SetDefualtValues()
        {
            attempts = 5;
            cmbLanguages.SelectedIndex = -1;
            cmbLanguages.IsEnabled = true;
            txtGuess.Text = "";
            txtTest.Text = "";      
            txt1.Text = " ";
            txt2.Text = " ";
            txt3.Text = " ";
            txt4.Text = " ";
            txt5.Text = " ";
            
        }

        private void txtResult_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }


   

}
