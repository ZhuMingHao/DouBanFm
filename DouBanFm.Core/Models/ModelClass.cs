using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouBanFm.Core.Models
{
    public class Style
    {
        public string display_text { get; set; }
        public string bg_color { get; set; }
        public int layout_type { get; set; }
        public string bg_image { get; set; }
    }

    public class Artist
    {
        public string id { get; set; }
    }

    public class ChannelRelation
    {
        public Artist artist { get; set; }
        public Song song { get; set; }
    }

    public class Chl
    {
        public Style style { get; set; }
        public string intro { get; set; }
        public string name { get; set; }
        public int song_num { get; set; }
        public string collected { get; set; }
        public string cover { get; set; }
        public int id { get; set; }
        public ChannelRelation channel_relation { get; set; }
        public int? channel_type { get; set; }
        public string artist { get; set; }
        public string start { get; set; }
        public string pro_desc { get; set; }
        public string brand_icon { get; set; }
    }

    public class Group
    {
        public List<Chl> chls { get; set; }
        public int group_id { get; set; }
        public string group_name { get; set; }
    }


    public class Singer
    {
        public List<object> style { get; set; }
        public string name { get; set; }
        public List<string> region { get; set; }
        public string name_usual { get; set; }
        public List<string> genre { get; set; }
        public string avatar { get; set; }
        public int related_site_id { get; set; }
        public bool is_site_artist { get; set; }
        public string id { get; set; }
    }

    public class Release
    {
        public string link { get; set; }
        public string id { get; set; }
        public string ssid { get; set; }
    }


    public class Song
    {
        public List<object> all_play_sources { get; set; }
        public string albumtitle { get; set; }
        public string url { get; set; }
        public string file_ext { get; set; }
        public string album { get; set; }
        public string ssid { get; set; }
        public string title { get; set; }
        public string sid { get; set; }
        public string sha256 { get; set; }
        public int status { get; set; }
        public string picture { get; set; }
        public int update_time { get; set; }
        public string alert_msg { get; set; }
        public bool is_douban_playable { get; set; }
        public string public_time { get; set; }
        public List<object> partner_sources { get; set; }
        public List<Singer> singers { get; set; }
        public int like { get; set; }
        public string artist { get; set; }
        public bool is_royal { get; set; }
        public string subtype { get; set; }
        public int length { get; set; }
        public Release release { get; set; }
        public string aid { get; set; }
        public string kbps { get; set; }

    }

}
