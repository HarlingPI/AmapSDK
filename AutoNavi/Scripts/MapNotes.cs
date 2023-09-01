using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace AutoNavi
{
    /// <summary>
    /// 创建者:   Harling
    /// 创建时间: 2020-09-28 16:08:57
    /// 备注:     地图标注物基类
    /// </summary>
    public abstract class MapNotes : IDisposable
    {
        /// <summary>
        /// 位置
        /// </summary>
        public List<Location> Positions = new List<Location>();

        private MapNotes() { }
        protected MapNotes(params Location[] positions)
        {
            Positions.AddRange(positions);
        }
        protected void AppendPositions(StringBuilder builder)
        {
            builder.Append(":");
            foreach (var item in Positions)
            {
                builder.Append(item.Longitude + "," + item.Latitude + ";");
            }
            builder.Remove(builder.Length - 1, 1);
        }
        public void Dispose()
        {
            Positions.Clear();
            Positions = null;
        }
    }
    /// <summary>
    /// 创建者:   Harling
    /// 创建时间: 2020-09-28 14:08:05
    /// 备注:     高德地图标注实体类
    /// </summary>
    public abstract class MapMarker : MapNotes
    {
        protected MapMarker(params Location[] positions) : base(positions)
        {
        }
    }
    /// <summary>
    /// 经纬度结构体
    /// </summary>
    [Serializable]
    public struct Location
    {
        /// <summary>
        /// 经度
        /// </summary>
        public double Longitude;
        /// <summary>
        /// 纬度
        /// </summary>
        public double Latitude;
        public Location(double longitude, double latitude) : this()
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        public static Location operator +(Location a, Location b)
        {
            return new Location(a.Longitude + b.Longitude, a.Latitude + b.Latitude);
        }
        public static Location operator -(Location a, Location b)
        {
            return new Location(a.Longitude - b.Longitude, a.Latitude - b.Latitude);
        }
        public static Location operator *(Location a, Location b)
        {
            return new Location(a.Longitude * b.Longitude, a.Latitude * b.Latitude);
        }
        public static Location operator /(Location a, Location b)
        {
            return new Location(a.Longitude / b.Longitude, a.Latitude / b.Latitude);
        }
        public static bool operator ==(Location a, Location b)
        {
            return a.Longitude == b.Longitude && a.Latitude == b.Latitude;
        }
        public static bool operator !=(Location a, Location b)
        {
            return a.Longitude != b.Longitude || a.Latitude != b.Latitude;
        }
        public static implicit operator Location(Vector2 v)
        {
            return new Location(v.x, v.y);
        }
    }
}
