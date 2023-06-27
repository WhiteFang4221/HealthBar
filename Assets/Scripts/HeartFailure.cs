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
    [SerializeField] private Player _player;
    private Animator _animator;
    private int _maxPercentHealth = 100;

    private void Awake()
    {
        _player.OnHeartStateChanged += ChangeState;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetInteger(AnimatorHeartController.Params.PlayerHealth, _maxPercentHealth);
    }

    private void ChangeState(int maxHealth, int currentHealth)
    {
        int currentPercentHealth = (currentHealth * _maxPercentHealth) / maxHealth;
        _animator.SetInteger(AnimatorHeartController.Params.PlayerHealth, currentPercentHealth);
    }
}
