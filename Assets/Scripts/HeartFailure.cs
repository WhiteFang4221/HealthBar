using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]

public static class AnimatorHeartController
{
    public static class Params
    {
        public const string PlayerHealth = "PlayerHealth";
    }
}

public class HeartFailure : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;


    private Animator _animator;
    private float _maxPercentHealth = 100;

    private void Awake()
    {
        _healthBar.HeartStateChanged += ChangeState;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetFloat(AnimatorHeartController.Params.PlayerHealth, _maxPercentHealth);
    }

    private void ChangeState(float maxHealth, float currentHealth)
    {
        float currentPercentHealth = (currentHealth * _maxPercentHealth) / maxHealth;
        _animator.SetFloat(AnimatorHeartController.Params.PlayerHealth, currentPercentHealth);
    }
}
