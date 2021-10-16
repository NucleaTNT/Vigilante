using Dev.NucleaTNT.Vigilante.Utilities;
using UnityEngine;

namespace Dev.NucleaTNT.Vigilante.Interactables
{
    public class EndStatue : Interactable
    {   
        [SerializeField] private string _levelName;
    
        public void LoadLevel() { GameManager.LoadScene(_levelName); }
    }
}
