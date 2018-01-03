using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Playback;

namespace DouBanFm.Core
{
    public class PlaybackService
    {
        private PlaybackService()
        {
            Player = new MediaPlayer
            {
                AutoPlay = true
            };

            CurrentPlaylist = new MediaList();

            CurrentPlaylist.CollectionChanged += (s, e) =>
            {
                PlaybackList = CurrentPlaylist.ToPlaybackList();
            };
        }

        private MediaPlaybackList PlaybackList
        {
            get { return Player.Source as MediaPlaybackList; }
            set { Player.Source = value; }
        }

        public static PlaybackService Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        private class Nested
        {
            static Nested()
            {
            }

            internal static readonly PlaybackService instance = new PlaybackService();
        }

        public MediaPlayer Player { get; private set; }

        public MediaList CurrentPlaylist { get; set; }
    }
}