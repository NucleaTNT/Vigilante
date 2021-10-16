using Dev.NucleaTNT.Vigilante.UI;
using Dev.NucleaTNT.Vigilante.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace Dev.NucleaTNT.Vigilante.BattleMode.UI
{
    public class BattleEntityHUD : MonoBehaviour
    {
        private bool _isAlreadyInitialized;
        [SerializeField] private Text _entityNameText;
        [SerializeField] private HealthBarHandler _healthBarHandler;
    
        public void InitHUD(EntityInfo entityInfo) 
        {
            if (_isAlreadyInitialized) { GameManager.PrintToConsole("BattleEntityHUD", "InitHUD", "This HUD has already been initialized!", LogType.Warning); return; }
            _isAlreadyInitialized = true;

            _entityNameText.text = entityInfo.EntityName;
            _healthBarHandler.InitializeHealthBar(entityInfo.CurrentHealth, entityInfo.MaxHealth);
        }
    }
}
