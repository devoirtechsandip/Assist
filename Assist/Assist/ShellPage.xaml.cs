using Assist.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assist
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShellPage : Shell
    {
        public ShellPage()
        {
            InitializeComponent();

            //TabBar.CurrentItem = TabBar.Items[1];

            //Routing.RegisterRoute("profile", typeof(ProfilePage));
            //Routing.RegisterRoute("about", typeof(AboutPage));
            
        }
    }
}