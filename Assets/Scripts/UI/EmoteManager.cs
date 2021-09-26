using UnityEngine;

namespace Dev.NucleaTNT.Vigilante.UI
{
    public enum Emote
    {
        BLANK,
        EXCLAMATION,
        QUESTION,
        DIALOGUE,
        PAUSE,
    }
    
    [RequireComponent(typeof(Animator))]
    public class EmoteManager : MonoBehaviour
    {
        private Animator animator;
        private string[] animStates = {"Blank", "Exclamation", "Question", "Dialogue", "Pause"};
    
        private void Awake()
        {
            animator = GetComponent<Animator>();
            if (animator.runtimeAnimatorController == null) animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animator/Emote");
        }
    
        private void Start () { HideEmote(); }    
        
        public void ShowEmote(Emote emote)
        {
            gameObject.SetActive(true);
            animator.Play(animStates[((int)emote)]);
        }
    
        public void HideEmote()
        {
            animator.Play("Blank");
            gameObject.SetActive(false);
        }
    }
}
