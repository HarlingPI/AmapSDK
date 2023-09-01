using PIToolKit.Unity.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace AutoNavi
{
    /// <summary>
    /// 创建者:   Harling
    /// 创建时间: 2020-09-28 15:59:16
    /// 备注:     系统默认标注
    /// </summary>
    public class SysMarker : MapMarker
    {
        /// <summary>
        /// 单个字符
        /// </summary>
        public char Content;
        /// <summary>
        /// 标注尺寸
        /// </summary>
        public MarkerSize Size = MarkerSize.Mid;
        /// <summary>
        /// 背景色
        /// </summary>
        public Color BackGround = new Color(136 / 255f, 216 / 255f, 1.0f);
        public SysMarker(char content, params Location[] positions) : base(positions)
        {
            Content = content;
        }

        public SysMarker(char content, MarkerSize size, Color background, params Location[] positions) : this(content, positions)
        {
            Size = size;
            BackGround = background;
        }

        private SysMarker() { }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(Size.ToString().ToLower());
            builder.Append("," + "0x" + BackGround.RGBToHex());
            builder.Append("," + (Content == char.MinValue ? "" : Content.ToString()));
            AppendPositions(builder);
            return builder.ToString();
        }
    }
}
