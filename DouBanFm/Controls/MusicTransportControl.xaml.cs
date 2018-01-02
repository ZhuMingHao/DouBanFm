using DouBanFm.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Playback;
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
    public sealed partial class MusicTransportControl : UserControl, INotifyPropertyChanged
    {
        MediaPlayer Player => PlaybackService.Instance.Player;
        private MediaList PlayerList => PlaybackService.Instance.CurrentPlaylist;
        private MediaPlaybackState State => Player.PlaybackSession.PlaybackState;

        #region binding  property

        private string artist = "NicoZhu";

        public string Artist
        {
            get { return artist; }
            set
            {
                artist = value;
                OnPropertyChanged();
            }
        }

        private string title = "Hello world";

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        private string albumArtUri;

        public string AlbumArtUri
        {
            get { return albumArtUri; }
            set
            {
                albumArtUri = value;
                OnPropertyChanged();
            }
        }

        private string musicTime = "00:00";

        public string MusicTime { get { return musicTime; } set { musicTime = value; OnPropertyChanged(); } }

        private int tcurrrentTime = 0;
        public int TCurentTime { get { return tcurrrentTime; } set { tcurrrentTime = value; OnPropertyChanged(); } }

        private string zcurrentTime;
        public string ZCurentTime { get { return zcurrentTime; } set { zcurrentTime = value; OnPropertyChanged(); } }

        #endregion binding  property

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public MusicTransportControl()
        {
            this.InitializeComponent();
            this.DataContext = this;
            PlayerList.CollectionChanged += PlayerList_CollectionChanged;
            this.Loaded += MusicTransportControl_Loaded;
            Player.MediaEnded += Player_MediaEnded;
            Player.MediaOpened += Player_MediaOpened;
            Player.PlaybackSession.PositionChanged += PlaybackSession_PositionChanged;
            Player.PlaybackSession.PlaybackStateChanged += PlaybackSession_PlaybackStateChanged;
            mediaPlayerElement.SetMediaPlayer(Player);
        }

        private async void PlaybackSession_PlaybackStateChanged(MediaPlaybackSession sender, object args)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
             {
                 switch (State)
                 {
                     case MediaPlaybackState.Playing:
                         EllStoryboard.Resume();
                         break;

                     case MediaPlaybackState.Paused:
                         EllStoryboard.Pause();
                         break;

                     case MediaPlaybackState.None:
                         EllStoryboard.Stop();
                         break;
                 }
             });
        }

        private async void PlaybackSession_PositionChanged(MediaPlaybackSession sender, object args)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                TCurentTime = (int)sender.Position.TotalSeconds;
                ZCurentTime = sender.Position.ToString(@"mm\:ss");
            });
        }

        private void PlayerList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (PlayerList.Count != 0)
            {
                var item = PlayerList.First() as MusicItem;
                this.Title = item.Title;
                this.AlbumArtUri = item.AlbumArtUri.ToString();
                this.Artist = item.Artist;
            }
        }

        private async void Player_MediaOpened(MediaPlayer sender, object args)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                MusicTime = sender.PlaybackSession.NaturalDuration.ToString(@"mm\:ss");
                EllStoryboard.Begin();
            });
        }

        private async void MusicTransportControl_Loaded(object sender, RoutedEventArgs e)
        {
            await PlaybackService.Instance.CurrentPlaylist.LoadFromDouBanAPIAsync();
        }

        private async void Player_MediaEnded(MediaPlayer sender, object args)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
            {
                await PlaybackService.Instance.NextOne();
            });
        }

        private void PlayOrPause_Click(object sender, RoutedEventArgs e)
        {
            if (State == MediaPlaybackState.Playing)
            {
                Player.Pause();
            }
            else
            {
                Player.Play();
            }

            PlayOrPause.Content = (PlayOrPause.Content.ToString() == "\uEDB5") ? "\uEDB4" : "\uEDB5";
        }

        private async void Next_Click(object sender, RoutedEventArgs e)
        {
            await PlaybackService.Instance.NextOne();
        }

        private void MusicSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
        }
    }
}