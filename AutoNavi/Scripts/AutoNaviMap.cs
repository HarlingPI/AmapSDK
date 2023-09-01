using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace AutoNavi
{
    /// <summary>
    /// 创建者:   Harling
    /// 创建时间: 2020-09-29 09:40:50
    /// 备注:     高德地图
    /// </summary>
    public static class AutoNaviMap
    {
        /// <summary>
        /// 请求地图
        /// </summary>
        /// <param name="descriptor"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static IEnumerator RequestMap(MapDescriptor descriptor, Action<DownloadHandlerTexture> callback)
        {
            UnityWebRequest request = UnityWebRequest.Get(descriptor.ToString());
            DownloadHandlerTexture texDL = new DownloadHandlerTexture(true);
            request.downloadHandler = texDL;
            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
            {
                throw new Exception( request.error);
            }
            else callback?.Invoke(texDL);
        }
    }
}
