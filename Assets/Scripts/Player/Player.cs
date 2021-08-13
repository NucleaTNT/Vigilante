using UnityEngine;

public enum PlayerState 
{
    IDLE,
    WALK,
    SWIM,
    ATTACK,
    INTERACT,
    STAGGER
}

public class Player : MonoBehaviour
{
    #region Private Properties

    private EmoteManager _EmoteManager;
    private PlayerAnimation _PlayerAnimation;
    private PlayerMovement _PlayerMovement;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maxHealth;

    private GameManager _GameManager;

    #endregion

    #region Public Properties
    
    public EmoteManager EmoteManager 
    { 
        get
        {
            if (_EmoteManager != null) return _EmoteManager;
            else 
            {
                GameManager.PrintToConsole("Player", "EmoteManager{GET}", "Player Object/Child is Missing Requested EmoteManager Component!", LogType.Error);
                return null;
            }
        }
        
        private set
        {
            _EmoteManager = value;
        }
    }

    public PlayerAnimation PlayerAnimation 
    { 
        get
        {
            if (_PlayerAnimation != null) return _PlayerAnimation;
            else 
            {
                GameManager.PrintToConsole("Player", "PlayerAnimation{GET}", "Player Object is Missing Requested PlayerAnimation Component!", LogType.Error);
                return null;
            }
        }
        
        private set
        {
            _PlayerAnimation = value;
        }
    }

    public PlayerMovement PlayerMovement 
    { 
        get
        {
            if (_PlayerMovement != null) return _PlayerMovement;
            else 
            {
                GameManager.PrintToConsole("Player", "PlayerMovement{GET}", "Player Object is Missing Requested PlayerMovement Component!", LogType.Error);
                return null;
            }
        }
        
        private set
        {
            _PlayerMovement = value;
        }
    }
  
    public GameManager GameManager 
    { 
        get
        {
            if (_GameManager != null) return _GameManager;
            else 
            {
                GameManager.PrintToConsole("Player", "GameManager{GET}", "There is no active GameManager in current scene!", LogType.Error);
                return null;
            }
        }
        
        private set
        {
            _GameManager = value;
        }
    }
  
    public float CurrentHealth 
    {
        get { return _currentHealth; }
        private set { _currentHealth = value; }
    } 
    
    public float MaxHealth 
    {
        get {return _maxHealth;}
        private set {_maxHealth = value;}
    } 

    // Base
    public Animator Animator {get; private set;}
    public Rigidbody2D Rigidbody {get; private set;}

    // PlayerMovement
    private bool _isSwimming = false;
    public bool IsSwimming 
    {
        get { return _isSwimming; }
        set 
        {
            if (_isSwimming == value) return;   // Prevent duplicate calls from altering vars
            
            _isSwimming = value;
            this.PlayerAnimation.UpdateSwimming();
            this.PlayerMovement.UpdateSwimming();
        }
    }

    public float MovementSpeed;
    public PlayerState CurrentState = PlayerState.IDLE;

    #endregion 

    #region Private Methods

    private void InitializeComponents() 
    {
        this.GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        this.EmoteManager = gameObject.GetComponentInChildren<EmoteManager>();
        this.PlayerAnimation = gameObject.GetComponent<PlayerAnimation>();
        this.PlayerMovement = gameObject.GetComponent<PlayerMovement>();
        this.Animator = gameObject.GetComponent<Animator>();
        this.Rigidbody = gameObject.GetComponent<Rigidbody2D>();
        this.CurrentHealth = this.MaxHealth;
    }

    #endregion

    #region Public Methods

    public void GainHealth(float health) 
    {
        CurrentHealth += health;
        // TODO Update Health UI
        if (CurrentHealth <= 0) gameObject.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        // TODO Update Health UI
        if (CurrentHealth <= 0) gameObject.SetActive(false);
    }

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        InitializeComponents();
    }

    private void Update()
    {
        switch (CurrentState)
        {
            case PlayerState.ATTACK:
            case PlayerState.STAGGER: break; 

            case PlayerState.IDLE:
            case PlayerState.WALK:
            case PlayerState.SWIM:
            {
                PlayerMovement.MovePlayer();
                break;
            }
        }
    }

    #endregion
}