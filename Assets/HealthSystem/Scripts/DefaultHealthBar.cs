using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class DefaultHealthBar : HealthBar
{
    [SerializeField] private Image _healthBarFill;

    private Slider _slider;
    private Color _colorFillDefault;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _colorFillDefault = _healthBarFill.color;
    }

    protected override void  SetHealth(float health)
    {
        _slider.value = health;
        
        if (health <= 0)
        {
            Color color = _healthBarFill.color;
            color.a = 0f;
            _healthBarFill.color = color;
        }
        else
        {
            _healthBarFill.color = _colorFillDefault;
        }
    }

    protected override void SetMaxHealth(float maxHealth)
    {
        _slider.maxValue = maxHealth;
        _slider.value = maxHealth;
    }
}
