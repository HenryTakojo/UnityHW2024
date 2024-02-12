using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Map_Original : MonoBehaviour
{
    public string apiKey;
    public float lat = 37.7749f;  // 默认的纬度
    public float lon = -122.4194f;  // 默认的经度
    public int zoom = 14;
    public enum resolution { low = 1, high = 2 };
    public resolution mapResolution = resolution.low;
    public enum type { roadmap, satellite, gybrid, terrain };
    public type mapType = type.roadmap;
    private string url = "";
    private int mapWidth = 640;
    private int mapHeight = 640;
    private bool mapIsLoading = false; //To Know whether the map is loading
    private Rect rect;
    private string apiKeyLast;

    private float latLast = 37.7749f;  // 默认的纬度
    private float lonLat = -122.4194f;  // 默认的经度
    private int zoomLast = 14;
    private resolution mapResolutionLast = resolution.low;
    private type mapTypeLast = type.roadmap;
    private bool updateMap = true;

    void Start()
    {
        rect = gameObject.GetComponent<RawImage>().rectTransform.rect;
        mapWidth = Mathf.RoundToInt(rect.width);
        mapHeight = Mathf.RoundToInt(rect.height);

        // 启动协程以下载地图图像
        StartCoroutine(DownloadMapImage());
    }

    private void Update()
    {
        if(updateMap &&(apiKeyLast != apiKey || !Mathf.Approximately(latLast,lat) || !Mathf.Approximately(lonLat, lon) || zoomLast != zoom || mapResolutionLast != mapResolution || mapTypeLast != mapType))
        {
            rect = gameObject.GetComponent<RawImage>().rectTransform.rect;
            mapWidth = Mathf.RoundToInt(rect.width);
            mapHeight = Mathf.RoundToInt(rect.height);
            StartCoroutine(DownloadMapImage());
            updateMap = false;
        }
    }

    IEnumerator DownloadMapImage()
    {
        // 构建 Google Maps API 请求 URL
        url = $"https://maps.googleapis.com/maps/api/staticmap?center={lat},{lon}&zoom={zoom}&size={mapWidth}x{mapHeight}&scale={mapResolution}&maptype={mapType}&key={apiKey}";

        mapIsLoading = true ;
        // 使用 UnityWebRequest 发送 GET 请求
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
        {
            // 发送请求并等待返回
            yield return www.SendWebRequest();

            // 检查是否有错误
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error downloading map image: " + www.error);
            }
            else
            {
                // 获取下载的纹理
                Texture2D mapTexture = DownloadHandlerTexture.GetContent(www);

                // 在这里，你可以将 mapTexture 显示在 Unity 的 RawImage 或其他 UI 元素中
                // 例如，如果你有一个 RawImage 组件
                // rawImage.texture = mapTexture;
                gameObject.GetComponent<RawImage>().texture = mapTexture;

                apiKeyLast = apiKey;
                latLast = lat;
                lonLat = lon;
                zoomLast = zoom;
                mapResolutionLast = mapResolution;
                mapTypeLast = mapType;
                updateMap = true;
            }
        }
    }
}
