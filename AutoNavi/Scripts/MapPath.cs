using PIToolKit.Unity.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace AutoNavi
{
    /// <summary>
    /// 创建者:   Harling
    /// 创建时间: 2020-09-28 16:25:21
    /// 备注:     高德地图路径标识
    /// </summary>
    public class MapPath : MapNotes
    {
        /// <summary>
        /// 路径宽度(2~15)
        /// </summary>
        public int Weight = 5;
        /// <summary>
        /// 路径颜色
        /// </summary>
        public Color Color = Color.blue;
        /// <summary>
        /// 是否填充封闭多边形
        /// </summary>
        public bool fill = false;
        /// <summary>
        /// 路径透明度(0~1)
        /// </summary>
        public float Transparency = 1;
        /// <summary>
        /// 封闭多边形填充色
        /// </summary>
        public Color Fillcolor;
        /// <summary>
        /// 封闭多边形填充透明度(0~1)
        /// </summary>
        public float FillTransparency = 0.5f;
        public MapPath(params Location[] positions) : base(positions) { }
        public MapPath(int weight, Color color, bool fill, float transparency, Color fillcolor, float fillTransparency, params Location[] positions) : base(positions)
        {
            Weight = Mathf.Clamp(weight, 2, 15);
            Color = color;
            this.fill = fill;
            Transparency = Mathf.Clamp01(transparency);
            Fillcolor = fillcolor;
            FillTransparency = Mathf.Clamp01(fillTransparency);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(Weight.ToString());
            builder.Append("," + "0x" + Color.RGBToHex());
            builder.Append("," + Transparency);
            builder.Append("," + (fill ? "0x" + Fillcolor.RGBToHex() : ""));
            builder.Append("," + (fill ? FillTransparency.ToString() : ""));
            AppendPositions(builder);
            return builder.ToString();
        }
    }
}
