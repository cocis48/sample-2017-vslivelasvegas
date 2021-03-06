﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class YoutubeService
    {
        public async Task<string> Refresh()
        {
            var client = new HttpClient();

            try
            {
                var html = await client.GetStringAsync("https://www.youtube.com/watch?v=_ntWKJoqsLQ");

                var div = "<div class=\"watch-view-count\">";

                var index = html.IndexOf(div) + div.Length;
                html = html.Substring(index);
                var index2 = html.IndexOf("<");
                html = html.Substring(0, index2);
                return html;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
