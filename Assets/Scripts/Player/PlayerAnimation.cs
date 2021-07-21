using UnityEngine;

public class PlayerAnimation : PlayerMonoBehaviour
{
    public void UpdateSwimming() { ThisPlayer.Animator.SetBool("isSwimming", ThisPlayer.IsSwimming); }

    public void UpdateMovementVars(float moveDirectionX, float moveDirectionY, bool isMoving)
    {
        ThisPlayer.Animator.SetFloat("moveX", moveDirectionX);
        ThisPlayer.Animator.SetFloat("moveY", moveDirectionY);
        ThisPlayer.Animator.SetBool("isMoving", isMoving);
    }

    private void Start()
    {
        ThisPlayer.Animator.SetFloat("moveX", 0);
        ThisPlayer.Animator.SetFloat("moveY", -1);
    }
}
