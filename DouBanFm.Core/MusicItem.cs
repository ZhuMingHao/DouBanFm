using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media;
using Windows.Media.Playback;

namespace DouBanFm.Core
{
    public class MusicItem : MediaItem
    {
        public Uri AlbumArtUri { get; set; }
        public string Artist { get; set; }
        public override Uri PreviewImageUri
        {
            get
            {
                return AlbumArtUri;
            }

            set
            {
                AlbumArtUri = value;
            }
        }
        public MusicItem() : base()
        {
        }
        public MusicItem(Models.Song song) : base(song)
        {
            if (song.picture != null)
            {
                AlbumArtUri = new Uri(song.picture);
                Artist = song.artist;
            }
        }
        public override MediaPlaybackItem ToPlaybackItem()
        {
            var playbackItem = base.ToPlaybackItem();
            var displayProperties = playbackItem.GetDisplayProperties();
            displayProperties.Type = MediaPlaybackType.Music;
            displayProperties.MusicProperties.Title = Title;
            displayProperties.MusicProperties.Artist = Artist;
            playbackItem.ApplyDisplayProperties(displayProperties);

            return playbackItem;
        }
    }
}
