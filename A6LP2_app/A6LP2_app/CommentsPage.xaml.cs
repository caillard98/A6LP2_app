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
    public partial class CommentsPage : ContentPage
    {
        public static List<Comment> Comments = Constants.RecipeComments;
        public CommentsPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
        public void UpdateContext()
        {
            viewComments.ItemsSource = Comments;
            if (Comments.Count == 0)
                txtNoContent.IsVisible = true;
            else
                txtNoContent.IsVisible = false;
        }
        public void WriteComment(object sender, EventArgs e)
        {
            MessagingCenter.Subscribe<WriteComment>(this, "Back", (writeSender) =>
            {
                viewComments.ItemsSource = Comments;
            });
            Navigation.PushModalAsync(new WriteComment());
        }
    }
}