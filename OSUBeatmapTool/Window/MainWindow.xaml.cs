using OSUBeatmapTool.Lib;
using OSUBeatmapTool.Model;
using System.Windows;

namespace OSUBeatmapTool
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitTree();
            InitBMPList();
            Log.WriteLog(LogFile.SQL,"二手");
        }

        public void InitTree()
        {
            //<TreeViewItem Header="库" IsExpanded="True">
            //    <TreeViewItem Header="本地Beatmap" />
            //    <TreeViewItem Header="Beatmap镜像" />
            //    <TreeViewItem Header="已玩过的Beatmap" HorizontalAlignment="Left" Width="127" />
            //</TreeViewItem>
            //<TreeViewItem Header="管理" IsExpanded="True">
            //    <TreeViewItem Header="正在下载" />
            //    <TreeViewItem Header="已下载" />
            //</TreeViewItem>

            TreeItem tree = new TreeItem();

            // 添加一级顶层子节点
            TreeItem root = new TreeItem();
            root.text = "Osu Beatmap Tool";
            root.itemIcon = "../Images/download.png";
            // 把根节点加进来
            tree.children.Add(root);

            TreeItem lib = new TreeItem();
            lib.text = "库";
            lib.itemIcon = "../Images/download.png";
            root.children.Add(lib);

            TreeItem loca = new TreeItem();
            loca.text = "本地Beatmap";
            loca.itemIcon = "../Images/local.png";
            TreeItem mirr = new TreeItem();
            mirr.text = "Beatmap镜像";
            mirr.itemIcon = "../Images/download.png";
            TreeItem played = new TreeItem();
            played.text = "已玩过的Beatmap";
            played.itemIcon = "../Images/download.png";

            lib.children.Add(loca);
            lib.children.Add(mirr);
            lib.children.Add(played);

            // 给根节点加一些子节点
            TreeItem manage = new TreeItem();
            manage.text = "管理";
            manage.itemIcon = "../Images/download.png";
            root.children.Add(manage);

            // 给湖北下加几个城市
            TreeItem downing = new TreeItem();
            downing.text = "正在下载";
            downing.itemIcon = "../Images/download.png";
            TreeItem downed = new TreeItem();
            downed.text = "已下载";
            downed.itemIcon = "../Images/download.png";

            manage.children.Add(downing);
            manage.children.Add(downed);

            // 把数据绑定到控件
            treeViewMenu.ItemsSource = tree.children;
        }

        public void InitBMPList()
        {
            ListBoxItem lbi = new ListBoxItem();
            lbi.LVDatas.Add(new ListBoxItem
            {
                id = "82258",
                title = "Xhroria",
                bmpic = "../Images/82258.png",
                artist = "An",
                from = "BMS",
                isRanked = false,
                mapper = "Cherry Blossom",
                date = "2013.08.16"
            });
            lbi.LVDatas.Add(new ListBoxItem
            {
                id = "82258",
                title = "Xhroria",
                bmpic = "../Images/82258.png",
                artist = "An",
                from = "BMS",
                isRanked = false,
                mapper = "Cherry Blossom",
                date = "2013.08.16"
            });
            lbi.LVDatas.Add(new ListBoxItem
            {
                id = "82258",
                title = "Xhroria",
                bmpic = "../Images/82258.png",
                artist = "An",
                from = "BMS",
                isRanked = false,
                mapper = "Cherry Blossom",
                date = "2013.08.16"
            });
            lbi.LVDatas.Add(new ListBoxItem
            {
                id = "82258",
                title = "Xhroria",
                bmpic = "../Images/82258.png",
                artist = "An",
                from = "BMS",
                isRanked = false,
                mapper = "Cherry Blossom",
                date = "2013.08.16"
            });
            lbi.LVDatas.Add(new ListBoxItem
            {
                id = "82258",
                title = "Xhroria",
                bmpic = "../Images/82258.png",
                artist = "An",
                from = "BMS",
                isRanked = false,
                mapper = "Cherry Blossom",
                date = "2013.08.16"
            });

            beatmapList.ItemsSource = lbi.LVDatas;
        }
    }
}