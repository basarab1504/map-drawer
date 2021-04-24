using UnityEngine;

public class JsonParser : BaseParser, IParser
{
    [SerializeField] private TextAsset mapConfig;

    public override TileData[] Parse()
    {
        var info = JsonUtility.FromJson<MapInfo>(mapConfig.text);
        TileData[] data = new TileData[info.List.Length];

        for (int i = 0; i < data.Length; i++)
        {
            data[i] = Convert(info.List[i]);
        }

        return data;
    }


}
