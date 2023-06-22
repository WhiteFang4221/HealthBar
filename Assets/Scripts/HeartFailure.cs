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

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetInteger(AnimatorHeartController.Params.PlayerHealth, _maxPercentHealth);
    }

    private void Update()
    {
        ChangeState();
    }

    private void ChangeState()
    {
        int currentPercentHealth = (_player.CurrentHealth * _maxPercentHealth) / _player.MaxHealth;
        _animator.SetInteger(AnimatorHeartController.Params.PlayerHealth, currentPercentHealth);
    }
}
