using System.Collections.Generic;

public class TileComparer : Comparer<TileData>
{
    public override int Compare(TileData x, TileData y)
    {
        if (x.PositionRounded.x.CompareTo(y.PositionRounded.x) != 0)
        {
            return x.PositionRounded.x.CompareTo(y.PositionRounded.x);
        }
        else if (x.PositionRounded.y.CompareTo(y.PositionRounded.y) != 0)
        {
            return x.PositionRounded.y.CompareTo(y.PositionRounded.y);
        }
        else
        {
            return 0;
        }
    }
}
