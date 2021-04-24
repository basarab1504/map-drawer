using UnityEngine;

public class JsonParser : MonoBehaviour, IParser
{
    [SerializeField] private TextAsset mapConfig;

    public MapInfo Parse()
    {
        return JsonUtility.FromJson<MapInfo>(mapConfig.text);
    }
}
