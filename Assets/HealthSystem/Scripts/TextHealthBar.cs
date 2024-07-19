using TMPro;
using UnityEngine;

public class TextHealthBar : HealthBar
{
    [SerializeField] private TextMeshProUGUI _healthText;
    private float _maxHealth;

    protected override void SetHealth(float health)
    {
        _healthText.text = health + "/" + _maxHealth;
    }

    protected override void SetMaxHealth(float maxHealth)
    {
        _maxHealth = maxHealth;
        _healthText.text = _maxHealth + "/" + _maxHealth;
    }
}
