
using DiabeticJournal.ViewModels.CorrectionFactor;

namespace DiabeticJournal.Views.CorrectionFactor;

public partial class AddCFPage : ContentPage
{

	
	public AddCFPage(AddCFPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}