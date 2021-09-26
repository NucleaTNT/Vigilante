using Dev.NucleaTNT.Vigilante.UI;
using Dev.NucleaTNT.Vigilante.Utilities;
using UnityEngine;

namespace Dev.NucleaTNT.Vigilante.PlayerScripts
{
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
    
        private EmoteManager _emoteManager;
        private PlayerAnimation _playerAnimation;
        private PlayerMovement _playerMovement;
        [SerializeField] private int _currentHealth;
        [SerializeField] private int _maxHealth;
        [SerializeField] private bool _isAlive;
    
        private GameManager _GameManager;
    
        #endregion
    
        #region Public Properties
        
        public EmoteManager EmoteManager 
        { 
            get
            {
                if (_emoteManager != null) return _emoteManager;
                else 
                {
                    GameManager.PrintToConsole("Player", "EmoteManager{GET}", "Player Object/Child is Missing Requested EmoteManager Component!", LogType.Error);
                    return null;
                }
            }
            
            private set
            {
                _emoteManager = value;
            }
        }
    
        public PlayerAnimation PlayerAnimation 
        { 
            get
            {
                if (_playerAnimation != null) return _playerAnimation;
                else 
                {
                    GameManager.PrintToConsole("Player", "PlayerAnimation{GET}", "Player Object is Missing Requested PlayerAnimation Component!", LogType.Error);
                    return null;
                }
            }
            
            private set
            {
                _playerAnimation = value;
            }
        }
    
        public PlayerMovement PlayerMovement 
        { 
            get
            {
                if (_playerMovement != null) return _playerMovement;
                else 
                {
                    GameManager.PrintToConsole("Player", "PlayerMovement{GET}", "Player Object is Missing Requested PlayerMovement Component!", LogType.Error);
                    return null;
                }
            }
            
            private set
            {
                _playerMovement = value;
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
      
        public int CurrentHealth 
        {
            get { return _currentHealth; }
    
            private set 
            {
                _currentHealth = (value >= 0) ? ((value > _maxHealth) ? _maxHealth : value) : 0;
                _isAlive = (_currentHealth > 0);
            }
        }
        
        public int MaxHealth 
        {
            get { return _maxHealth; }
    
            private set 
            {
                if (value < 0) value = 0;
                _maxHealth = value;
                if (_currentHealth > _maxHealth) CurrentHealth = _maxHealth;
            }
        }
    
        public bool IsAlive => _isAlive;
    
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
            this.GameManager = GameManager.Instance;
            this.EmoteManager = gameObject.GetComponentInChildren<EmoteManager>();
            this.PlayerAnimation = gameObject.GetComponent<PlayerAnimation>();
            this.PlayerMovement = gameObject.GetComponent<PlayerMovement>();
            this.Animator = gameObject.GetComponent<Animator>();
            this.Rigidbody = gameObject.GetComponent<Rigidbody2D>();
            this.CurrentHealth = this.MaxHealth;
        }
    
        #endregion
    
        #region Public Methods
    
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
}