 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Finals
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        List<Button> buttons;
        List<ImageSource> images;
        List<Label> fieldC;
        string word;
        int counterMiss = 0;
        public Page2()
        {
            InitializeComponent();
            images = new List<ImageSource>();
            LoadImage();
            DoWordArea();
        }

        private void Btn_Clicked_NewGame(object sender, EventArgs e)
        {
            DoWordArea();
        }
        private void LoadImage()
        {
            for (int i = 0; i < 8; i++)
            {
                ImageSource image = ImageSource.FromFile("Hangman" + i.ToString() + ".png");
                images.Add(image);
            }
        }
        private void CreateKeyboard()
        {
            buttons = new List<Button>();
            firstRow.Children.Clear();
            secondRow.Children.Clear();
            thirdRow.Children.Clear();
            for (int i = 65; i < 95; i++)
            {
                Button button = new Button()
                {
                    Text = ((char)i).ToString(),
                    FontSize = 22,
                    WidthRequest = 40,
                    HeightRequest = 50
                };
                button.Clicked += BT_Click_Key;
                if (i % 65 < 8) firstRow.Children.Add(button);
                else if (i % 65 >= 8 && i % 65 < 17) secondRow.Children.Add(button);
                else thirdRow.Children.Add(button);
                buttons.Add(button);
            }
        }

        private void BT_Click_Key(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string chara = button.Text.ToString();
            bool hit = false;
            for (int i = 1; i < this.word.Length - 1; i++)
            {
                if (this.word[i].ToString().ToLower() == chara.ToLower())
                {
                    hit = true;
                    fieldC[i].Text = chara.ToLower();
                }
            }
            if (hit == false)
            {
                counterMiss += 1;
                imageMiss.Source = images[index: counterMiss];
            }
            if (counterMiss == 7)
            {
                MessageToUser("Try Harder");
            }
            int count = 0;
            for (int j = 0; j < this.word.Length; j++)
            {
                if (fieldC[j].Text != "-")
                {
                    count++;
                }
                if (count == this.word.Length)
                {
                    MessageToUser("Congratulations Bro!");
                }
                button.IsEnabled = false;
            }
        }

        private void MessageToUser(string v)
        {
            DisplayAlert(v, v, "Play again");
            DoWordArea();
        }

        private string RandomWord()
        {
            string[] words = {"Huwebes","HappyT","Wallet","Samgyupsal","SimpleLine","beach","UPad","Bro","CBreak","StBenilde"
            ,"Uniqlo","Caf","Greenway","Ejeep","Generator","Egg Waffle","Barn","EAF","Dixies",
            "Jun","OSB","EXO Monday"};
            Random r = new Random();
            return words[r.Next(words.Length)];
        }

        private void DoWordArea()
        {
            counterMiss = 0;
            CreateKeyboard();
            this.word = RandomWord();
            imageMiss.Source = images[0];
            fieldC = new List<Label>();
            WordArea.Children.Clear();
            for (int i = 0; i < this.word.Length; i++)
            {

                Label label = new Label()
                {
                    Text = "-",
                    Margin = new Thickness(10),
                    FontSize = 25,
                    TextColor = Color.Black
                };
                WordArea.Children.Add(label);
                fieldC.Add(label);
            }
            fieldC[0].Text = this.word[0].ToString();
            fieldC[this.word.Length - 1].Text = this.word[this.word.Length - 1].ToString();
        }
    }
}