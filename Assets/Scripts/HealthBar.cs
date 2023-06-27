using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;

    public event Action<float, float> HeartStateChanged;

    private float _healthSpeedChange = 30f;

    private void Awake()
    {
        _player.HealthMaxSet += SetMaxHealth;
        _player.HealthChanged += SetHealth;
    }
    private void Start()
    {
        _slider = GetComponent<Slider>();
    }
    private void OnDestroy()
    {
        _player.HealthMaxSet -= SetMaxHealth;
        _player.HealthChanged -= SetHealth;
    }

    private void SetHealth(float health)
    {
        StartCoroutine(ChangeHealthBarState(health));
    }

    private void SetMaxHealth(float maxHealth)
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
        HeartStateChanged?.Invoke(_slider.maxValue, _slider.value);
    }
}