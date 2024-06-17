using Application.Abstractions.Pages;
using Domain.Guards;
using Presentation.ViewModels;

namespace Presentation.Views
{
    public partial class PondsPage : ContentPage, IGuardedEntity
    {

        public PondsPage(PondViewModel viewModel)
        {
            InitializeComponent();

            Page.Title = Locale.Resources.Resource.Ponds;
            FeedingSchedule.Text = Locale.Resources.Resource.FeedingSchedule;
            FeedingFrequency.Text = Locale.Resources.Resource.FeedingFrequency;
            FoodAmount.Text = Locale.Resources.Resource.FoodAmount;
            Update.Text = Locale.Resources.Resource.Update;
            BackToList.Text = Locale.Resources.Resource.BackToList;
            
            
            BindingContext = viewModel;
        }

        public IEnumerable<Guard> Guards => [Guard.LoginRequired];
    }
}