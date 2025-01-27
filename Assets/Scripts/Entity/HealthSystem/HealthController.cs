using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour, IHealth
{
    [SerializeField] private float maxHealth = 100f;

    public bool IsDead { get { return _isEntityDead; } }

    public float CurrentHealth { get; private set; }
    public float MaxHealth { get { return maxHealth; } }

    public event Action<float> OnHealthChanged;
    public event Action OnDeath;

    private bool _isEntityDead = false;

    public void Initialize(float _maxHealth)
    {
        maxHealth = _maxHealth;

        CurrentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        OnHealthChanged?.Invoke(CurrentHealth);

        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0f, maxHealth);
        OnHealthChanged?.Invoke(CurrentHealth);
    }

    private void Die()
    {
        _isEntityDead = true;
        OnDeath?.Invoke();
    }
}
