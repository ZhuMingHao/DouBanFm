using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Newtonsoft;
using Newtonsoft.Json;

namespace DouBanFm.Core.Https
{
    public sealed class APIService : APIBaseService
    {
        #region Singleton definition
        private APIService()
        {
        }
        public static APIService Instance
        {
            get
            { return Nested.instance; }
        }

        private class Nested
        {
            static Nested()
            {

            }
            internal static readonly APIService instance = new APIService();
        }
        #endregion

        #region API Usage Get Grous.
        public async Task<List<Models.Group>> GetGroups()
        {
            try
            {
                if (Tools.NetworkManager.Current.Network == 4)
                {
                    return null;
                }
                else
                {
                    var json = await GetJsonString(ServiceUrl.Groups);
                    return JsonConvert.DeserializeObject<List<Models.Group>>(json.GetNamedArray("groups").ToString());
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion
        #region API Usage Get SongList.
        public async Task<List< Models.Song>> GetSong()
        {
            try
            {
                if (Tools.NetworkManager.Current.Network == 4)
                {
                    return null;
                }
                else
                {
                    var json = await GetJsonString(ServiceUrl.Song);     
                    return JsonConvert.DeserializeObject<List<Models.Song>>(json.GetNamedValue("song").ToString());
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion
    }
}
