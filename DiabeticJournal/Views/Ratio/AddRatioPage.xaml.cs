
using DiabeticJournal.ViewModels.Ratio;

namespace DiabeticJournal.Views.Ratio;

public partial class AddRatioPage : ContentPage
{

	
	public AddRatioPage(AddRatioPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}