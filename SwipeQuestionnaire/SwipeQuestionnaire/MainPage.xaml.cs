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

            Frame_theImage.IsVisible = false;
            btn_play.IsVisible = false;

        }

        void btn_play_clicked(object sender, EventArgs e)
        {
            amerPoints = 0;
            frenchPoints = 0;
            index = 0;
            theAmerImage.Source = PersonalityQuestions[index].ImageAmer.ToString();
            theLabel.Text = PersonalityQuestions[index].Question.ToString();
            theFrenchImage.Source = PersonalityQuestions[index].ImageFrench.ToString();

            Frame_theImage.IsVisible = false;
            btn_play.IsVisible = false;
            True.IsVisible = true;
            False.IsVisible = true;
            Frame_Amer.IsVisible = true;
            Frame_France.IsVisible = true;
            theFrenchImage.IsVisible = true;
            theAmerImage.IsVisible = true;

        }

        void OnSwiped(object sender, SwipedEventArgs e)
        {
            //Right is True and American
            if (e.Direction == SwipeDirection.Right)
            {
                amerPoints++;
                index++;
                if (index <= PersonalityQuestions.Count - 1)
                {
                    True.IsVisible = true;
                    False.IsVisible =true;
                    
                    theAmerImage.Source = PersonalityQuestions[index].ImageAmer.ToString();
                    theLabel.Text = PersonalityQuestions[index].Question.ToString();
                    theFrenchImage.Source = PersonalityQuestions[index].ImageFrench.ToString();
                    
                }
                else if (amerPoints > frenchPoints)
                {
                    Random rnd = new Random();
                    int image = rnd.Next(0, 4);
                    theImage.Source = amerImages[image].ToString();
                    theLabel.Text = "Yay!  You are a true American!";
                    theFrenchImage.IsVisible = false;
                    theAmerImage.IsVisible = false;

                    True.IsVisible = false;
                    False.IsVisible = false;
                    Frame_Amer.IsVisible = false;
                    Frame_France.IsVisible = false;
                    Frame_theImage.IsVisible = true;
                    btn_play.IsVisible = true;
                }
                else if (amerPoints < frenchPoints)
                {
                    Random rnd = new Random();
                    int image = rnd.Next(0, 4);
                    theImage.Source = frenchImages[image].ToString();
                    theLabel.Text = "Oui, oui!  Vous êtes un vrai Francophile!";
                    theFrenchImage.IsVisible = false;
                    theAmerImage.IsVisible = false;

                    True.IsVisible = false;
                    False.IsVisible = false;
                    Frame_Amer.IsVisible = false;
                    Frame_France.IsVisible = false;
                    Frame_theImage.IsVisible = true;
                    btn_play.IsVisible = true;
                }
            }

            //Left is False and French
            else if (e.Direction == SwipeDirection.Left)
            {
                frenchPoints++;
                index++;
                if (index <= PersonalityQuestions.Count - 1)
                {
                    
                    theAmerImage.Source = PersonalityQuestions[index].ImageAmer.ToString();
                    theLabel.Text = PersonalityQuestions[index].Question.ToString();
                    theFrenchImage.Source = PersonalityQuestions[index].ImageFrench.ToString();
                }
                else if (amerPoints > frenchPoints)
                {
                    Random rnd = new Random();
                    int image = rnd.Next(0, 4);
                    theImage.Source = amerImages[image].ToString();
                    theLabel.Text = "Yay!  You are a true American: lover of new ideas and a robust lifestyle.";
                    theFrenchImage.IsVisible = false;
                    theAmerImage.IsVisible = false;

                    True.IsVisible = false;
                    False.IsVisible = false;
                    Frame_Amer.IsVisible = false;
                    Frame_France.IsVisible = false;
                    Frame_theImage.IsVisible = true;
                    btn_play.IsVisible = true;
                }
                else if (amerPoints < frenchPoints)
                {
                    Random rnd = new Random();
                    int image = rnd.Next(0, 4);
                    theImage.Source = frenchImages[image].ToString();
                    theLabel.Text = "Oui, oui!  Vous êtes un vrai francophile. Vous êtes un amoureux de l'art, de la nourriture et de la culture.";
                    theFrenchImage.IsVisible = false;
                    theAmerImage.IsVisible = false;

                    True.IsVisible = false;
                    False.IsVisible = false;
                    Frame_Amer.IsVisible = false;
                    Frame_France.IsVisible = false;
                    Frame_theImage.IsVisible = true;
                    btn_play.IsVisible = true;
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


