using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DouBanFm.Core.Models;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage.Streams;

namespace DouBanFm.Core
{
    public class MediaItem
    {
        public const string MediaItemIdKey = "mediaItemId";

        Uri previewImageUri;

        public string Title { get; set; }
        public Uri MediaUri { get; set; }
        public string ItemId { get; set; }

        public virtual Uri PreviewImageUri
        {
            get
            {
                return previewImageUri;
            }
            set
            {
                previewImageUri = value;
            }
        }
        public MediaItem()
        {
        }
        public MediaItem(Song song) : this()
        {
            ItemId = song.ssid;
            Title = song.title;
            if (song.url != null)
            {
                MediaUri = new Uri(song.url);
            }
        }

        public virtual MediaPlaybackItem ToPlaybackItem()
        {
            var source = MediaSource.CreateFromUri(MediaUri);
            var playbackItem = new MediaPlaybackItem(source);
            var displayProperties = playbackItem.GetDisplayProperties();
            if (PreviewImageUri != null)
                displayProperties.Thumbnail = RandomAccessStreamReference.CreateFromUri(PreviewImageUri);

            playbackItem.ApplyDisplayProperties(displayProperties);
            source.CustomProperties[MediaItem.MediaItemIdKey] = ItemId;

            return playbackItem;
        }
    }
}
