using UnityEngine;
using UnityEngine.Tilemaps;

public enum Season
{
    SPRING,
    SUMMER,
    FALL,
    WINTER
}

[CreateAssetMenu(fileName = "SeasonalTile", menuName = "Scriptable Objects/Tiles/Seasonal Tile")]
public class SeasonalTile : Tile
{
    [SerializeField] Sprite springSprite, summerSprite, fallSprite, winterSprite;
    private GameManager gameManager = null;

    private void GetGameManager()
    {
        GameObject gameManObj = GameObject.FindGameObjectWithTag("GameManager");
        if (gameManObj != null) gameManager = gameManObj.GetComponent<GameManager>();
    }

    public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject gameObj)
    {
        GetGameManager();
        return base.StartUp(position, tilemap, gameObj);
    }

    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData) 
    {
        base.GetTileData(location, tilemap, ref tileData);

        if (gameManager != null)
        {
            switch (gameManager.CurrentSeason)
            {
                case Season.SPRING: tileData.sprite = springSprite; break;
                case Season.SUMMER: tileData.sprite = summerSprite; break;
                case Season.FALL: tileData.sprite = fallSprite; break;
                case Season.WINTER: tileData.sprite = winterSprite; break;
                default: GameManager.PrintToConsole("SeasonalTile", "GetTileData", "Uhhhhh this really shouldn't be happening. The GameManager's CurrentSeason isn't valid. Maybe check that out.", LogType.Error); break;
            }
        } 
        else
        {
            tileData.sprite = springSprite; // Default to spring
            GetGameManager();
        }
    }
}
