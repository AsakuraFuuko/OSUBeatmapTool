using OSUBeatmapTool.Lib;
using OSUBeatmapTool.Model;
using System.Windows;
using System.Windows.Controls;

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
            Log.WriteLog(LogFile.SQL, "二手");
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
            root.itemName = ItemNameEnum.Root;
            // 把根节点加进来
            tree.children.Add(root);

            TreeItem lib = new TreeItem();
            lib.text = "Beatmap库";
            lib.itemIcon = "../Images/lib.png";
            lib.itemName = ItemNameEnum.Library;
            root.children.Add(lib);

            TreeItem loca = new TreeItem();
            loca.text = "本地Beatmap";
            loca.itemIcon = "../Images/local.png";
            loca.itemName = ItemNameEnum.LocalBM;
            TreeItem mirr = new TreeItem();
            mirr.text = "Beatmap镜像";
            mirr.itemIcon = "../Images/mirror.png";
            mirr.itemName = ItemNameEnum.MirrorBM;
            TreeItem played = new TreeItem();
            played.text = "已玩过的Beatmap";
            played.itemIcon = "../Images/played.png";
            played.itemName = ItemNameEnum.PlayedBM;

            lib.children.Add(loca);
            lib.children.Add(mirr);
            lib.children.Add(played);

            // 给根节点加一些子节点
            TreeItem manage = new TreeItem();
            manage.text = "下载管理";
            manage.itemIcon = "../Images/manager.png";
            manage.itemName = ItemNameEnum.Manager;
            root.children.Add(manage);

            // 给湖北下加几个城市
            TreeItem downing = new TreeItem();
            downing.text = "正在下载";
            downing.itemIcon = "../Images/downing.png";
            downing.itemName = ItemNameEnum.Downloading;
            TreeItem downed = new TreeItem();
            downed.text = "已下载";
            downed.itemIcon = "../Images/downed.png";
            downed.itemName = ItemNameEnum.Downloaded;

            manage.children.Add(downing);
            manage.children.Add(downed);

            // 把数据绑定到控件
            treeViewMenu.ItemsSource = tree.children;
        }

        public void InitBMPList()
        {
            BeatmapListItem lbi = new BeatmapListItem();
            lbi.LVDatas.Add(new Beatmap
            {
                id = "82258",
                title = "Xhroria",
                thumbnail = "../Images/82258.png",
                artist = "An",
                source = "BMS",
                status = 0,
                creator = "Cherry Blossom",
                date = "2013.08.16"
            });
            
            beatmapList.ItemsSource = lbi.LVDatas;
        }

        public void InitBMPList1()
        {
            BeatmapListItem lbi = new BeatmapListItem();
            lbi.LVDatas.Add(new Beatmap
            {
                id = "82258",
                title = "测试",
                thumbnail = "../Images/none.jpg",
                artist = "An",
                source = "BMS",
                status = 7,
                creator = "Cherry Blossom",
                date = "2013.08.16"
            });

            beatmapList.ItemsSource = lbi.LVDatas;
        }

        private void treeView1_Selected(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(((sender as TreeView).SelectedItem as TreeItem).text);
            TreeItem ti = (sender as TreeView).SelectedItem as TreeItem;
            switch (ti.itemName)
            {
                case ItemNameEnum.LocalBM: InitBMPList();
            	break;
                case ItemNameEnum.MirrorBM: InitBMPList1();
                break;
            }
                //InitBMPList1()
        }
    }
}