using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Data.Json;
using Windows.Media.Playback;
using Windows.Media.Core;
using Windows.Media;
using Windows.Storage.Streams;
using System.Collections.ObjectModel;

namespace DouBanFm.Core
{
    public class MediaList : ObservableCollection<MediaItem>
    {
        public string Title { get; set; }

        public MediaList()
        {
        }

        public async Task LoadFromDouBanAPIAsync()
        {
            this.Clear();
            var songs = await DouBanFm.Core.Https.APIService.Instance.GetSong();
            songs?.ForEach((s) =>
            {
                Add(LoadItem(s));
            });
        }

        public async Task NextOne()
        {
            var songs = await DouBanFm.Core.Https.APIService.Instance.GetSong();
            songs?.ForEach((s) =>
            {
                this.Clear();
                this.Add(LoadItem(s));
            });
        }

        private MediaItem LoadItem(Models.Song song)
        {
            return new MusicItem(song);
        }

        public MediaPlaybackList ToPlaybackList()
        {
            var playbackList = new MediaPlaybackList();
            playbackList.AutoRepeatEnabled = false;

            foreach (var mediaItem in this)
            {
                playbackList.Items.Add(mediaItem.ToPlaybackItem());
            }
            return playbackList;
        }
    }
}