using System.Collections.ObjectModel;

namespace OSUTool.Model
{
    internal class ListBoxItem
    {
        public string id { get; set; }
        public string bmpic { get; set; }
        public string artist { get; set; }
        public string title { get; set; }
        public string mapper { get; set; }
        public string from { get; set; }
        public bool isRanked { get; set; }
        public string date { get; set; }

        public ObservableCollection<ListBoxItem> LVDatas;

        public ListBoxItem()
        {
            LVDatas = new ObservableCollection<ListBoxItem>();
        }
    }
}