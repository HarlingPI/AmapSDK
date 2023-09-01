using PIToolKit.Unity.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace AutoNavi
{
    /// <summary>
    /// 创建者:   Harling
    /// 创建时间: 2020-09-28 14:08:05
    /// 备注:     高德地图标签实体类
    /// </summary>
    public class MapLable : MapNotes
    {
        /// <summary>
        /// 最长15个字符
        /// </summary>
        public string Content = "";
        /// <summary>
        /// 字体
        /// </summary>
        public Font Font = AutoNavi.Font.YaHei;
        /// <summary>
        /// 加粗
        /// </summary>
        public Bold Bold = Bold.Normal;
        /// <summary>
        /// 字号(1~72)
        /// </summary>
        public int FontSize = 10;
        /// <summary>
        /// 字色
        /// </summary>
        public Color FontColor = Color.white;
        /// <summary>
        /// 背景色
        /// </summary>
        public Color Background = new Color(136 / 255f, 216 / 255f, 255 / 255f);

        public MapLable(string content, params Location[] positions) : base(positions)
        {
            Content = content;
        }
        public MapLable(string content, Font font, Bold bold, int fontSize, Color fontColor, Color background, params Location[] positions) : this(content, positions)
        {
            Font = font;
            Bold = bold;
            FontSize = Mathf.Clamp(fontSize, 1, 72);
            FontColor = fontColor;
            Background = background;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(Content);
            builder.Append("," + ((int)Font));
            builder.Append("," + ((int)Bold));
            builder.Append("," + FontSize);
            builder.Append("," + "0x" + FontColor.RGBToHex());
            builder.Append("," + "0x" + Background.RGBToHex());
            AppendPositions(builder);
            return builder.ToString();
        }
    }
}
