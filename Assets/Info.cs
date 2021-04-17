using System;

[Serializable]
public struct Infos
{
    public Info[] List;
}

[Serializable]
public struct Info
{
    public string Id;
    public string Type;
    public float Width;
    public float Height;
    public float X;
    public float Y;
}
