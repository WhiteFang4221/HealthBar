using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    public event Action<int> OnHealthChanged;
    public event Action<int> OnHealthMaxSet;
    public event Action <int, int> OnHeartStateChanged;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        OnHealthMaxSet?.Invoke(_currentHealth);
    }

    public void TakeDamage(int damagePoint)
    {
        _currentHealth -= damagePoint;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        OnHealthChanged?.Invoke(_currentHealth);
        OnHeartStateChanged?.Invoke(_maxHealth,_currentHealth);
    }

    public void Heal(int healPoint)
    {
        _currentHealth += healPoint;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        OnHealthChanged?.Invoke(_currentHealth);
        OnHeartStateChanged?.Invoke(_maxHealth, _currentHealth);
    }
}
