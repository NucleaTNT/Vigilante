using System;
using Dev.NucleaTNT.Vigilante.BattleMode.UI;
using Dev.NucleaTNT.Vigilante.Utilities;
using UnityEngine;

namespace Dev.NucleaTNT.Vigilante.BattleMode 
{
    public class BattleManager : MonoBehaviour
    {
        private bool _battleAlreadyInProgress = false; 

        [SerializeField] private BattleEntityHUD _playerBattleHUD;
        [SerializeField] private Transform playerBattlePos;
        [Space(10)]
        [SerializeField] private BattleEntityHUD _enemyBattleHUD;
        [SerializeField] private Transform enemyBattlePos;
        private BattleEntity _playerBattleEntity, _enemyBattleEntity;

        [SerializeField] private EntityInfo _pEI, _eEI;

        private static BattleManager s_instance;
        public static BattleManager Instance => s_instance;
    
        private void BattleLoop(bool isPlayerFirstMove) 
        {
            if (isPlayerFirstMove) _playerBattleEntity.EvaluateTurn(_playerBattleEntity);
            
            do
            {
                _enemyBattleEntity.EvaluateTurn(_playerBattleEntity);
                if (_playerBattleEntity.IsAlive) _playerBattleEntity.EvaluateTurn(_enemyBattleEntity);
            } while (_playerBattleEntity.IsAlive && _enemyBattleEntity.IsAlive);
            
            EndBattle(_playerBattleEntity.IsAlive);
        }

        private void EndBattle(bool hasPlayerWon)
        {
            ShowBattleMessage((hasPlayerWon) ? "Player Wins" : "Player Loses");
            _battleAlreadyInProgress = false;
        }

        private void InitBattleUI(EntityInfo playerEI, EntityInfo enemyEI) 
        {
            _playerBattleHUD.InitHUD(playerEI);
            _enemyBattleHUD.InitHUD(enemyEI);
            ShowBattleMessage(enemyEI.BattleEntryMessage);
        }
    
        private void InitBattleEntities(EntityInfo playerEI, EntityInfo enemyEI)
        {
            _playerBattleEntity = Instantiate(playerEI.BattlePrefab, playerBattlePos).GetComponent<BattleEntity>();
            _enemyBattleEntity = Instantiate(enemyEI.BattlePrefab, enemyBattlePos).GetComponent<BattleEntity>();
        }
    
        private void ShowBattleMessage(string message) => Debug.Log(message);
        
        public void InitBattle(EntityInfo playerEI, EntityInfo enemyEI, bool isPlayerFirstMove)
        {
            if (_battleAlreadyInProgress) { GameManager.PrintToConsole("BattleManager", "InitBattle", "There is already a battle in progress!", LogType.Warning); return; }
            _battleAlreadyInProgress = true;

            InitBattleUI(playerEI, enemyEI);
            InitBattleEntities(playerEI, enemyEI);
            BattleLoop(isPlayerFirstMove);
        }
    
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L)) InitBattle(_pEI, _eEI, true);
        }
    }
}