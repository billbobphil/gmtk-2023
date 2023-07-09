using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Minigame
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _healthBarSprite;
        [SerializeField] private float reduceSpeed;
        [SerializeField] private bool _animateHealthBar;
        private float _target;

        public void UpdateHealthBar(float maxHealth, float currentHealth)
        {
            if (_animateHealthBar)
            {
                _target = currentHealth / maxHealth;
            }
            else
            {
                _healthBarSprite.fillAmount = currentHealth / maxHealth;
            }
        }

        private void FixedUpdate()
        {
            if(!_animateHealthBar) return;

            _healthBarSprite.fillAmount = Mathf.MoveTowards(_healthBarSprite.fillAmount, _target, reduceSpeed);
        }
        
    }
}

