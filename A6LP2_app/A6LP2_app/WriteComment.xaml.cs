using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace A6LP2_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WriteComment : ContentPage
    {
        public WriteComment()
        {
            InitializeComponent();
        }
        public void Send(object sender, EventArgs e)
        {
            string _author = author.Text;
            string _comment = comment.Text;

            if(!string.IsNullOrWhiteSpace(_author) && !string.IsNullOrWhiteSpace(_comment))
            {
                if(_author.ToLowerInvariant() == "admin")
                {
                    DisplayAlert("Alerta", "Bonito ein, tentando se passar de administrador? 😏", "Desculpa kkkkk");
                    return;
                }
                SendCommentToDatabase(_author, _comment).Wait();
                CommentsPage.Comments = Constants.RecipeComments;
                MessagingCenter.Send(this, "Back");
                Navigation.PopModalAsync();                
            }
            else
            {
                DisplayAlert("Alerta", "Ambos os campos precisam estar preenchidos para enviar o comentário!", "OK");
            }
        }
        public async Task SendCommentToDatabase(string author, string comment)
        {
            string dt = DateTime.Now.ToString("dd/MM/yyyy hh:MM:ss");
            var t = await App.Database.InsertCommentAsync(new Comment
            {
                Author = author,
                Text = comment,
                Recipe_ID = Constants.SelectedRecipe.ID,
                DateString = dt
            });
            Constants.RecipeComments = await App.Database.GetCommentsForRecipeAsync(Constants.SelectedRecipe.ID);
        }
    }
}