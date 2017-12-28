using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace DouBanFm.Controls
{
    public sealed partial class MusicTransportControl : UserControl
    {
        public MusicTransportControl()
        {
            this.InitializeComponent();
        }

        private void PlayOrPause_Click(object sender, RoutedEventArgs e)
        {
            PlayOrPause.Content = (PlayOrPause.Content.ToString() == "\uEDB5") ? "\uEDB4" : "\uEDB5";
        }
    }
}
