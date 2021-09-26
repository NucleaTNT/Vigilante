using Dev.NucleaTNT.Vigilante.Utilities;
using UnityEngine;

namespace Dev.NucleaTNT.Vigilante.Interactables
{
    public class EndStatue : Interactable
    {   
        [SerializeField] private string _levelName;
        [SerializeField] private bool _isFadeEntry, _isSpinExit;
    
        public void LoadLevel() { GameManager.LoadSceneWithTransition(_levelName, _isFadeEntry, _isSpinExit); }
    }
}
