using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace AutoNavi
{
    /// <summary>
    /// 创建者:   Harling
    /// 创建时间: 2020-09-28 15:59:16
    /// 备注:     网络标注
    /// </summary>
    public class WebMarker : MapMarker
    {
        /// <summary>
        /// 图标的网络地址(png)
        /// </summary>
        public string icourl;

        public WebMarker(string icourl, params Location[] positions) : base(positions)
        {
            this.icourl = icourl;
        }

        private WebMarker() { }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder("-1");
            builder.Append("," + icourl);
            builder.Append("," + 0);
            AppendPositions(builder);
            return builder.ToString();
        }

    }
}
