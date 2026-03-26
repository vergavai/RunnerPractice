using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public event Action HasDied; 
    public event Action<int> HealthChanged;
    
    public int Health => _health;
    
    public void TakeDamage(int damage)
    {
        _health = Mathf.Max(0, _health - damage);
        
        HealthChanged?.Invoke(_health);
        
        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        HasDied?.Invoke();
    }
}
