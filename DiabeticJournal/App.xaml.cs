using DiabeticJournal.Models;
using DiabeticJournal.Handlers;
using Microsoft.Maui.Platform;

namespace DiabeticJournal;

public partial class App : Application
{

	public static User loggedInUser;

	//Database db;



	public App(Database database)
	{
		InitializeComponent();
		Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
		{
			if (view is BorderlessEntry)
			{
#if __ANDROID__
				handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif __IOS__
				handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
			}
		});
		//db = database;

		//db.Init();
		//db.setDemo();

		MainPage = new AppShell(database);

		

		
		
	}

	




}
