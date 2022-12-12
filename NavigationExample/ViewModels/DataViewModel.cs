using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationExample.ViewModels
{
    public partial class DataViewModel : ObservableRecipient
    {
        [ObservableProperty]
        private string _data = "Data View";
    }
}
