using UnityEngine;

[CreateAssetMenu(fileName = "EntityInfo", menuName = "Scriptable Objects/BattleSystem/EntityInfo")]
public class EntityInfo : ScriptableObject
{
    public string EntityName, BattleEntryMessage;
    public int CurrentHealth, MaxHealth;
    public GameObject BattlePrefab;
}
