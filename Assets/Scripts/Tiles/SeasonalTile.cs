using Dev.NucleaTNT.Vigilante.Utilities;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Dev.NucleaTNT.Vigilante.Tiles 
{
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
        [SerializeField] Sprite _springSprite, _summerSprite, _fallSprite, _winterSprite;
        private Dev.NucleaTNT.Vigilante.Utilities.GameManager _gameManager = null;
    
        public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject gameObj)
        {
            _gameManager = Dev.NucleaTNT.Vigilante.Utilities.GameManager.Instance;
            return base.StartUp(position, tilemap, gameObj);
        }
    
        public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData) 
        {
            base.GetTileData(location, tilemap, ref tileData);
    
            if (_gameManager != null)
            {
                switch (_gameManager.CurrentSeason)
                {
                    case Season.SPRING: tileData.sprite = _springSprite; break;
                    case Season.SUMMER: tileData.sprite = _summerSprite; break;
                    case Season.FALL: tileData.sprite = _fallSprite; break;
                    case Season.WINTER: tileData.sprite = _winterSprite; break;
                    default: Dev.NucleaTNT.Vigilante.Utilities.GameManager.PrintToConsole("SeasonalTile", "GetTileData", "Uhhhhh this really shouldn't be happening. The GameManager's CurrentSeason isn't valid. Maybe check that out.", LogType.Error); break;
                }
            } 
            else
            {
                tileData.sprite = _springSprite; // Default to spring
                _gameManager = GameManager.Instance;
            }
        }
    }
}
