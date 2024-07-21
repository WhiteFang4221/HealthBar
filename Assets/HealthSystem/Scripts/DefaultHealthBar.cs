using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class DefaultHealthBar : HealthBar
{
    [SerializeField] private Image _healthBarFill;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    protected override void  ShowNewValue(float health)
    {
        _slider.value = health;
    }
}
