using UnityEngine;
using UnityEngine.UI;

namespace Dev.NucleaTNT.Vigilante.UI 
{
    [RequireComponent(typeof(Slider))]
    public class HealthBarHandler : MonoBehaviour
    {
        [SerializeField] private Image fillImage;
        private Slider healthSlider;
        [SerializeField] private int _currentHealth, _maxHealth;
    
        public int CurrentHealth 
        {
            get { return _currentHealth; }
    
            set 
            {
                // If value < 0 -> set _currentHealth to 0
                // otherwise if value is greater than _maxHealth -> set it to _maxHealth
                // else set _currentHealth to value
                _currentHealth = (value >= 0) ? ((value > _maxHealth) ? _maxHealth : value) : 0; 
            }
        }
    
        public int MaxHealth 
        {
            get { return _maxHealth; }
    
            set 
            {
                if (value < 0) value = 0;
    
                healthSlider.maxValue = value;
                _maxHealth = value; 
    
                if (_currentHealth > _maxHealth) _currentHealth = _maxHealth;
            }
        }
    
        public void UpdateHealthColor()
        {
            float red, green;
    
            if (_currentHealth > (_maxHealth * 0.45))
            { 
                red = 0;
                green = 220;
            } else if (_currentHealth > (_maxHealth * 0.25)) 
            {
                red = 255;
                green = 220;
            } else
            {
                green = 0;
                red = 220;
            }
    
            fillImage.color = new Color(red, green, 0, 255);
        }
    
        public void InitializeHealthBar(int currentHealth, int maxHealth) 
        {
            healthSlider = gameObject.GetComponent<Slider>();
            CurrentHealth = currentHealth;
            MaxHealth = maxHealth;
        }
    
        private void Update()
        {
            if (healthSlider.value != _currentHealth) healthSlider.value = Mathf.Lerp(healthSlider.value, _currentHealth, 3f * Time.deltaTime);
        }
    }
}
