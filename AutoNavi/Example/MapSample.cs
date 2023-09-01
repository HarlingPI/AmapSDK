using PIToolKit.Foundation;
using PIToolKit.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace AutoNavi
{
    /// <summary>
    /// 创建者:   Harling
    /// 创建时间: 2020-09-28 13:19:28
    /// 备注:     高德地图展示类
    /// </summary>
    public class MapSample : MonoBehaviour
    {
        [SerializeField]
        private Location location = new Location(116.481485f, 39.990464f);
        IEnumerator Start()
        {
            MapDescriptor descriptor = new MapDescriptor("cfa9fe91c71c433a0c71fbf259a983c1", location);
            descriptor.Zoom = 17;
            descriptor.Markers.Add(new SysMarker(char.MinValue, location));

            yield return AutoNaviMap.RequestMap(descriptor, SetTexture);
        }

        private void SetTexture(DownloadHandlerTexture obj)
        {
            gameObject.GetComponent<MeshRenderer>().material.mainTexture = obj.texture;
        }
    }

}