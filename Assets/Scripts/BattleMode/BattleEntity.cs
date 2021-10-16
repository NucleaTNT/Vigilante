using UnityEngine;
using Dev.NucleaTNT.Vigilante.Interfaces;

namespace Dev.NucleaTNT.Vigilante.BattleMode 
{   
    public class BattleEntity : MonoBehaviour, IHealth
    {
        private int _currentHealth, _maxHealth;
        private bool _isInitialized;

        private bool _isAlive;
        public bool IsAlive => _isAlive;

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
        
        public string EntityName {get; private set;}
    
        // This way, each entity that inherits can define their own unique behaviour
        public virtual void EvaluateTurn(BattleEntity target) => throw new System.NotImplementedException("EvaluateTurn method is yet to be defined by Entity.");

        public virtual void Heal(int amount) => _currentHealth += Mathf.Abs(amount);
        public virtual void TakeDamage(int amount) => _currentHealth -= Mathf.Abs(amount);

        public virtual void InitializeEntity(EntityInfo entityInfo) 
        {
            this.EntityName = entityInfo.EntityName;
            this.CurrentHealth = entityInfo.CurrentHealth;
            this.MaxHealth = entityInfo.MaxHealth;
        }
    }
}