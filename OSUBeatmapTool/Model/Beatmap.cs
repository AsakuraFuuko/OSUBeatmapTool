using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OSUBeatmapTool.Model
{
    class Beatmap
    {
        public string id { get; set; }
        public string artist { get; set; }
        public string source { get; set; }
        public string creatorId { get; set; }
        public string creator { get; set; }
        public string title { get; set; }
        public int status { get; set; }
        public int genre { get; set; }
        public string titleUnicode { get; set; }
        public string artistUnicode { get; set; }
        public string thumbnail { get; set; }
        public string date { get; set; }
    }
}
