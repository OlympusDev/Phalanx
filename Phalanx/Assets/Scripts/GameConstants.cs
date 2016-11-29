using UnityEngine;
using System.Collections;

public static class GameConstants{
    public enum effectType : int
    {
        Damage = 0,
        ByPass = 1
    }

    public enum terrainType : int
    {
        River = 0,
        Tile = 1,
        Obstacle = 2
    }
}
