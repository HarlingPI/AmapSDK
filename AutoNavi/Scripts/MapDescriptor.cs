using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace AutoNavi
{
    /// <summary>
    /// 创建者:   Harling
    /// 创建时间: 2020-09-28 14:06:34
    /// 备注:     地图参数
    /// </summary>
    public class MapDescriptor : IDisposable
    {
        private const string UrlPrefix = "https://restapi.amap.com/v3/staticmap?";
        /// <summary>
        /// 请求的用户key值
        /// </summary>
        public string Key;
        /// <summary>
        /// 地图的中心点(经纬度)
        /// </summary>
        public Location Center = new Location(116.481485, 39.990464);
        /// <summary>
        /// 是否显示实时路况
        /// </summary>
        public bool ShowTraffic = false;
        /// <summary>
        /// 缩放级别(1~17)
        /// </summary>
        public int Zoom
        {
            get { return zoom; }
            set
            {
                value = Mathf.Clamp(value, 1, 17);
                if (value != zoom) zoom = value;
            }
        }
        /// <summary>
        /// 地图大小(最大1024x1024)
        /// </summary>
        public Vector2Int MapSize
        {
            get { return mapSize; }
            set
            {
                value = Vector2Int.Min(value, Vector2Int.one * 1024);
                if (value != mapSize) mapSize = value;
            }
        }
        /// <summary>
        /// 地图规格
        /// </summary>
        public Scale Scale = Scale.Normal;
        /// <summary>
        /// 地图上的标签(10个以内)
        /// </summary>
        public List<MapLable> Lables = new List<MapLable>();
        /// <summary>
        /// 地图上的标注
        /// </summary>
        public List<MapMarker> Markers = new List<MapMarker>();
        /// <summary>
        /// 地图上的路径
        /// </summary>
        public List<MapPath> Paths = new List<MapPath>();

        private int zoom = 10;
        private Vector2Int mapSize = new Vector2Int(512, 512);
        private MapDescriptor() { }
        public MapDescriptor(string key, Location center)
        {
            Key = key;
            Center = center;
        }
        public MapDescriptor(string key, Location center, Vector2Int mapSize, bool showTraffic = false, int zoom = 10, Scale scale = Scale.Normal)
            : this(key, center)
        {
            ShowTraffic = showTraffic;
            Zoom = zoom;
            MapSize = mapSize;
            Scale = scale;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(UrlPrefix);
            if (ShowTraffic) builder.Append("traffic=1" + "&");
            builder.AppendFormat("location={0},{1}&", Center.Longitude, Center.Latitude);
            builder.AppendFormat("zoom={0}&", Zoom);
            builder.AppendFormat("size={0}*{1}&", MapSize.x, MapSize.y);
            if (Lables != null && Lables.Count > 0)
            {
                int count = 0;
                Lables.ForEach(item => count += item.Positions.Count);
                if (count > 10) throw new Exception( "地图标签不能超过10个");
                else
                {
                    builder.Append("labels=");
                    builder.Append(string.Join("|", Lables));
                    builder.Append("&");
                }
            }
            if (Markers != null && Markers.Count > 0)
            {
                int count = 0;
                Markers.ForEach(item => count += item.Positions.Count);
                if (count > 10) throw new Exception( "地图标注不能超过10个");
                else
                {
                    builder.Append("markers=");
                    builder.Append(string.Join("|", Markers));
                    builder.Append("&");
                }
            }
            if (Paths != null && Paths.Count > 0)
            {
                if (Paths.Count > 4) throw new Exception( "地图路径不能超过4个");
                else
                {
                    builder.Append("paths=");
                    builder.Append(string.Join("|", Paths));
                    builder.Append("&");
                }
            }
            builder.AppendFormat("key={0}", Key);
            return builder.ToString();
        }
        public void Dispose()
        {
            Lables.Clear();
            Lables = null;
            Markers.Clear();
            Markers = null;
            Paths.Clear();
            Paths = null;
        }
    }
}