using System.Collections.ObjectModel;

namespace OSUBeatmapTool.Model
{
    internal class BeatmapListItem
    {
        public ObservableCollection<Beatmap> LVDatas;

        public BeatmapListItem()
        {
            LVDatas = new ObservableCollection<Beatmap>();
        }
    }
}