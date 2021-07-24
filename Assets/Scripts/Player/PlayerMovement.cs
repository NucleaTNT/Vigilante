using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : PlayerMonoBehaviour
{   
    private MainInputMap mainInputMap;
    private InputAction movement;

    #region Public Methods

    public void MovePlayer()
    {
        if (ThisPlayer.CurrentState != PlayerState.STAGGER)
        {
            Vector2 moveDirection = movement.ReadValue<Vector2>();

            if (moveDirection != Vector2.zero)
            {
                ThisPlayer.Rigidbody.MovePosition((Vector2)transform.position + moveDirection.normalized * ThisPlayer.MovementSpeed * Time.fixedDeltaTime);  // FixedDeltaTime due to RB.MovePosition being physics-related
                ThisPlayer.PlayerAnimation.UpdateMovementVars(moveDirection.x, moveDirection.y, true);
                ThisPlayer.CurrentState = ThisPlayer.IsSwimming ? PlayerState.SWIM : PlayerState.WALK;
            } else 
            {
                ThisPlayer.Animator.SetBool("isMoving", false);
                ThisPlayer.CurrentState = PlayerState.IDLE;
            }
        }
    } 
    
    public void UpdateSwimming() { ThisPlayer.MovementSpeed = ThisPlayer.IsSwimming ? ThisPlayer.MovementSpeed / 2 : ThisPlayer.MovementSpeed * 2; }

    #endregion

    #region MonoBehaviour Callbacks

    protected override void Awake()
    {
        base.Awake();
        mainInputMap = ThisPlayer.GameManager.MainInputMap;
    }

    private void OnEnable()
    {
        movement = mainInputMap.Player.Movement;
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    private void Start()
    {
        if (ThisPlayer.MovementSpeed <= 0) GameManager.PrintToConsole("PlayerMovement", "Start", $"{name}'s MovementSpeed is less than or equal to zero!", LogType.Warning);
        ThisPlayer.CurrentState = PlayerState.IDLE;
    }

    #endregion
}