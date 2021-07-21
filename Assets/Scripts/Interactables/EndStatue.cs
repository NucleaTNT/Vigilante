using UnityEngine;

public class EndStatue : Interactable
{   
    public string levelName;
    public bool isFadeEntry, isSpinExit;

    public void LoadLevel() { GameManager.LoadSceneWithTransition(levelName, isFadeEntry, isSpinExit); }
}
