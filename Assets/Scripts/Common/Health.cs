using Essentials;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

namespace Common
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        [SerializeField] private int profit;
        private float _currentHealth;
        [SerializeField] private MMHealthBar healthBar;
        [SerializeField] private MMFeedbacks getHitFb;
        [SerializeField] private MMFeedbacks dieFb;
        private Rigidbody _rigidbody;
        private bool _isDead = false;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _currentHealth = maxHealth;
        }

        public void ChangeHealth(float amount)
        {
            if (_isDead) return;
            if (amount < 0) getHitFb.PlayFeedbacks();
            _currentHealth += amount;
            healthBar.UpdateBar(_currentHealth,0f,maxHealth,true);
            CheckIfMaxHealthReached();
            CheckIfDead();
        }
        
        private void CheckIfMaxHealthReached()
        {
            if (_currentHealth > maxHealth) _currentHealth = maxHealth;
        }
        
        private void CheckIfDead()
        {
            if (_currentHealth <= 0) Die();
        }

        private void Die()
        {
            if (_isDead) return;
            _isDead = true;
            dieFb.PlayFeedbacks();
            GameSession.Instance.AddScore(profit);
        }
    }
}
