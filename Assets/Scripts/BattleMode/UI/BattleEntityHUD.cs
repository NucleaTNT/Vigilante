using Dev.NucleaTNT.Vigilante.UI;
using Dev.NucleaTNT.Vigilante.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace Dev.NucleaTNT.Vigilante.BattleMode.UI
{
    public class BattleEntityHUD : MonoBehaviour
    {
        [SerializeField] private HealthBarHandler _healthBarHandler;
        [SerializeField] private Text _entityNameText;
        private bool _alreadyInitialized;
    
        public void InitHUD(EntityInfo entityInfo) 
        {
            if (_alreadyInitialized) { GameManager.PrintToConsole("BattleEntityHUD", "InitHUD", "This HUD has already been initialized!", LogType.Warning); return; }
            _alreadyInitialized = true;

            _entityNameText.text = entityInfo.EntityName;
            _healthBarHandler.InitializeHealthBar(entityInfo.CurrentHealth, entityInfo.MaxHealth);
        }
    }
}
