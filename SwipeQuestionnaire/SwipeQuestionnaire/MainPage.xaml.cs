using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using static System.Net.Mime.MediaTypeNames;

namespace SwipeQuestionnaire
{
    public partial class MainPage : ContentPage
    {
        List<QandImages> PersonalityQuestions = new List<QandImages>();
        public int amerPoints { get; set; }
        public int frenchPoints { get; set; }
        public int index { get; set; }

        public string[] frenchImages = { "france_1.jpg", "france_2.jpg", "france_3.jpg", "france_4.jpg", "france_5.jpg" };
        public string[] amerImages = { "america_1.jpg", "america_2.jpg", "america_3.jpg", "america_4.jpg", "america_5.jpg", };


        public MainPage()
        {
            InitializeComponent();

            amerPoints = 0;
            frenchPoints = 0;
            index = 0;


            PersonalityQuestions.Add(new QandImages("A Hamburger is tastier than a Croque Monsieur sandwich.", "_1burger.jpg", "_1croqueMonsieur.jpg"));
            PersonalityQuestions.Add(new QandImages("T-Bone steaks are yummier than filet mignon.", "_2tboneSteak.jpg", "_2filetMignon.jpg"));
            PersonalityQuestions.Add(new QandImages("I'd rather wake up with a black coffee than cafe au lait.", "_3blackCoffee.jpg", "_3cafeAuLait.jpg"));
            PersonalityQuestions.Add(new QandImages("Ice cold Coca-Cola is more refreshing than fresh squeezed lemonade.", "_4cocaCola.jpg", "_4lemonade.jpg"));
            PersonalityQuestions.Add(new QandImages("Maine lobster over escargot.", "_5maineLobster.jpg", "_5escargot.jpg"));

            theAmerImage.Source = PersonalityQuestions[index].ImageAmer.ToString();
            theLabel.Text = PersonalityQuestions[index].Question.ToString();
            theFrenchImage.Source = PersonalityQuestions[index].ImageFrench.ToString();

        }

        void OnSwiped(object sender, SwipedEventArgs e)
        {
            //Right is True and French
            if (e.Direction == SwipeDirection.Right)
            {
                frenchPoints++;
                if (index <= PersonalityQuestions.Count - 1)
                {
                    lbl_Question_Number.IsVisible = true;
                    True.IsVisible = true;
                    False.IsVisible =true;
                    theAmerImage.Source = PersonalityQuestions[index].ImageAmer.ToString();
                    theLabel.Text = PersonalityQuestions[index].Question.ToString();
                    theFrenchImage.Source = PersonalityQuestions[index].ImageFrench.ToString();
                    index++;
                }
                else if (amerPoints > frenchPoints)
                {
                    Random rnd = new Random();
                    int image = rnd.Next(0, 4);
                    theAmerImage.Source = amerImages[image].ToString();
                    theLabel.Text = "Yay!  You are a true American: lover of new ideas and a robust lifestyle.";
                    theFrenchImage.Source = "";
                    lbl_Question_Number.IsVisible = false;
                    True.IsVisible = false;
                    False.IsVisible = false;
                }
                else if (amerPoints < frenchPoints)
                {
                    Random rnd = new Random();
                    int image = rnd.Next(0, 4);
                    theFrenchImage.Source = frenchImages[image].ToString();
                    theLabel.Text = "Oui, oui!  Vous êtes un vrai francophile. Vous êtes un amoureux de l'art, de la nourriture et de la culture";
                    theAmerImage.Source = "";

                    lbl_Question_Number.IsVisible = false;
                    True.IsVisible = false;
                    False.IsVisible = false;
                }
            }

            //Left is False and American
            else if (e.Direction == SwipeDirection.Left)
            {
                amerPoints++;
                if (index <= PersonalityQuestions.Count - 1)
                {
                    theAmerImage.Source = PersonalityQuestions[index].ImageAmer.ToString();
                    theLabel.Text = PersonalityQuestions[index].Question.ToString();
                    theFrenchImage.Source = PersonalityQuestions[index].ImageFrench.ToString();
                    index++;
                }
                else if (amerPoints > frenchPoints)
                {
                    Random rnd = new Random();
                    int image = rnd.Next(0, 4);
                    theAmerImage.Source = amerImages[image].ToString();
                    theLabel.Text = "Yay!  You are a true American: lover of new ideas and a robust lifestyle.";
                    theFrenchImage.Source = "";

                    lbl_Question_Number.IsVisible = false;
                    True.IsVisible = false;
                    False.IsVisible = false;
                }
                else if (amerPoints < frenchPoints)
                {
                    Random rnd = new Random();
                    int image = rnd.Next(0, 4);
                    theFrenchImage.Source = frenchImages[image].ToString();
                    theLabel.Text = "Oui, oui!  Vous êtes un vrai francophile. Vous êtes un amoureux de l'art, de la nourriture et de la culture";
                    theAmerImage.Source = "";

                    lbl_Question_Number.IsVisible = false;
                    True.IsVisible = false;
                    False.IsVisible = false;
                }
            }
            else if (e.Direction == SwipeDirection.Up)
            {
                theLabel.Text = "Don't swipe Up.  Swipe Left or Right.";
            }
            else if (e.Direction == SwipeDirection.Down)
            {
                theLabel.Text = "Don't swipe Down.  Swipe Left or Right.";
            }
        }
    }

}


