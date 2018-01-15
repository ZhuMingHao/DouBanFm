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
    public sealed partial class MusicItemControl : UserControl
    {
        public MusicItemControl()
        {
            this.InitializeComponent();
        }

        public string Url
        {
            get { return (string)GetValue(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Url.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UrlProperty =
            DependencyProperty.Register("Url", typeof(string), typeof(MusicItemControl), new PropertyMetadata(0));


        public string MusicInfo
        {
            get { return (string)GetValue(MusicInfoProperty); }
            set { SetValue(MusicInfoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MusicInfo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MusicInfoProperty =
            DependencyProperty.Register("MusicInfo", typeof(string), typeof(MusicItemControl), new PropertyMetadata(0));

    }

}
