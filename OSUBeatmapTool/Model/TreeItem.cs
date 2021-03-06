﻿using System.Collections.ObjectModel;

namespace OSUBeatmapTool.Model
{
    internal class TreeItem
    {
        // 构造函数
        public TreeItem()
        {
            children = new ObservableCollection<TreeItem>();
        }

        //////////////////////////////////////////////////////////////////////////
        // 节点文字信息
        public string text
        {
            get;
            set;
        }

        // 节点图标路径
        public string itemIcon
        {
            get;
            set;
        }

        // 节点名称
        public ItemNameEnum itemName
        {
            get;
            set;
        }

        // 父节点
        public TreeItem parent
        {
            get;
            set;
        }

        // 子节点
        public ObservableCollection<TreeItem> children
        {
            get;
            set;
        }
        //////////////////////////////////////////////////////////////////////////
    }

    public enum ItemNameEnum
    {
        Root,
        Library,
        LocalBM,
        MirrorBM,
        PlayedBM,
        Manager,
        Downloading,
        Downloaded
    }
}