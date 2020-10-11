using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Z.Expressions;

namespace kalkulacka5
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public string Count(string expression)
        {
            string result = "";
            try
            {
                var outcome = Eval.Execute<int>(expression);

                result = outcome.ToString();

            }
            catch
            {
                result = "ERROR";
            }
            return result;
        }

        void onButtonClicked(object sender, EventArgs args)
        {

            // Rozpozna tlacitko
            Button button = (Button)sender;
            string buttonText = button.Text;

            // Akce pro ruzna tlacitka
            if (buttonText == "=")
            {
                LabelCal.Text = Count(LabelCal.Text);
            }
            if (buttonText == "DEL")
            {
                string text = LabelCal.Text;
                if (text == "ERROR")
                {
                    LabelCal.Text = "";
                }
                else
                {
                    LabelCal.Text = text.Substring(0, text.Length - 1);
                }
            }
            if (buttonText == "C")
            {
                LabelCal.Text = "";
            }
            if (buttonText != "=" && buttonText != "DEL" && buttonText != "C")
            {
                if (LabelCal.Text == "ERROR")
                {
                    LabelCal.Text = buttonText;
                }
                else
                {
                    LabelCal.Text += buttonText;
                }
            }
        }
    }
}
