using TMPro;
using UnityEngine;

public class TextHealthBar : HealthBar
{
    [SerializeField] private TextMeshProUGUI _healthText;
    private float _maxHealth;

    private void Start()
    {
        _maxHealth = player.CurrentHealth;
        _healthText.text = _maxHealth + "/" + _maxHealth;
    }
    protected override void ShowNewValue(float health)
    {
        _healthText.text = health + "/" + _maxHealth;
    }
}
