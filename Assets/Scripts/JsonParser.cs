using UnityEngine;

public class JsonParser : BaseParser, IParser
{
    [SerializeField] private TextAsset mapConfig;

    protected override MapInfo InternalParse()
    {
        return JsonUtility.FromJson<MapInfo>(mapConfig.text);
    }


}
