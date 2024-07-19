using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothHealthBar : HealthBar
{
    [SerializeField] private Slider _slider;

    public event Action<float, float> HealthSliderChanged;
    private Coroutine _healthBarChangerRoutine;
    private float _healthSpeedChange = 30f;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    protected override void SetHealth(float health)
    {
        if (_healthBarChangerRoutine != null)
        {
            StopCoroutine(_healthBarChangerRoutine);
        }

        _healthBarChangerRoutine = StartCoroutine(ChangeHealthBarState(health));
        HealthSliderChanged?.Invoke(_slider.maxValue, health);
    }

    protected override void SetMaxHealth(float maxHealth)
    {
        _slider.maxValue = maxHealth;
        _slider.value = maxHealth;
    }

    private IEnumerator ChangeHealthBarState(float targetHealth)
    {
        while (_slider.value != targetHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetHealth, Time.deltaTime * _healthSpeedChange);
            yield return null;
        }
    }
}