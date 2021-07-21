using UnityEngine;

public class PlayerMovement : PlayerMonoBehaviour
{
    private Vector3 moveDirection;
    
    private void Start()
    {
        if (ThisPlayer.MovementSpeed <= 0) Debug.LogWarning($"[WARN]: {name}'s MovementSpeed is less than or equal to zero!");
        ThisPlayer.CurrentState = PlayerState.IDLE;
    }

    public void MovePlayer()
    {
        if (ThisPlayer.CurrentState != PlayerState.STAGGER)
            moveDirection = Vector3.zero;
            moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

            if (moveDirection != Vector3.zero)
            {
                ThisPlayer.Rigidbody.MovePosition(transform.position + moveDirection.normalized * ThisPlayer.MovementSpeed * Time.fixedDeltaTime);  // FixedDeltaTime due to RB.MovePosition being physics-related
                ThisPlayer.PlayerAnimation.UpdateMovementVars(moveDirection.x, moveDirection.y, true);
                ThisPlayer.CurrentState = ThisPlayer.IsSwimming ? PlayerState.SWIM : PlayerState.WALK;
            } else 
            {
                ThisPlayer.Animator.SetBool("isMoving", false);
                ThisPlayer.CurrentState = PlayerState.IDLE;
            }
    } 

    public void UpdateSwimming() { ThisPlayer.MovementSpeed = ThisPlayer.IsSwimming ? ThisPlayer.MovementSpeed / 2 : ThisPlayer.MovementSpeed * 2; }
}
