using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace A6LP2_app
{
    public partial class MainPage : ContentPage
    {
        int servings = 1;
        public MainPage()
        {
            InitializeComponent();
            UpdateServingsControls();
        }

        private async void Servings_Minus(object sender, EventArgs e)
        {
            servings--;
            UpdateServingsControls();
        }

        private async void Servings_Plus(object sender, EventArgs e)
        {
            servings++;
            UpdateServingsControls();
        }
        private void UpdateServingsControls()
        {
            _Servings.Text = servings.ToString();
            if (servings == 1)
            {
                btnServingsMinus.IsEnabled = false;
            } 
            else if (servings == 15)
            {
                btnServingsPlus.IsEnabled = false;
            }
            else if (!btnServingsMinus.IsEnabled || !btnServingsPlus.IsEnabled)
            {
                btnServingsMinus.IsEnabled = true;
                btnServingsPlus.IsEnabled = true;
            }
        }
    }
}
