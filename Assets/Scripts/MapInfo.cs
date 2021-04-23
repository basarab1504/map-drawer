using System;

[Serializable]
public struct MapInfo
{
    public Chunk[] List;

    [Serializable]
    public struct Chunk
    {
        public string Id;
        public string Type;
        public float Width;
        public float Height;
        public float X;
        public float Y;
    }
}

