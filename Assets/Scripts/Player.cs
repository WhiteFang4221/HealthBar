using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    [SerializeField] private HealthBar HealthBar;
    [SerializeField] private int _maxHealth;

    public int MaxHealth
    {
        get { return _maxHealth; }
        private set { _maxHealth = value; }
    }

    public int CurrentHealth { get; private set; }

    private void Start()
    {
        CurrentHealth = _maxHealth;
        HealthBar.SetMaxHealth(_maxHealth);
    }

    public void TakeDamage(int damagePoint)
    {
        if (CurrentHealth > 0) 
        {
            CurrentHealth -= damagePoint;
            HealthBar.SetHealth(CurrentHealth);
        }
    }

    public void Heal(int healPoint)
    {
        if (CurrentHealth < _maxHealth)
        {
            CurrentHealth += healPoint;
            HealthBar.SetHealth(CurrentHealth);
        }
    }
}
