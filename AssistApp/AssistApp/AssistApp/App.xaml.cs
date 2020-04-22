using Prism;
using Prism.Ioc;
using AssistApp.ViewModels;
using AssistApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AssistApp.Data;
using System.IO;
using System;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AssistApp
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MyTab");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<AddContact, AddContactViewModel>();
            containerRegistry.RegisterForNavigation<ViewContact, ViewContactViewModel>();
            containerRegistry.RegisterForNavigation<MyTab, MyTabViewModel>();
        }


        static AssistDB database;
        public static AssistDB Database
        {
            get
            {
                if (database == null)
                {
                    database = new AssistDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AssistDataBase.db3"));
                }
                return database;
            }
        }
    }
}
