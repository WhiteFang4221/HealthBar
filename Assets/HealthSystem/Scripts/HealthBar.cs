using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HealthMaxSet += SetMaxHealth;
        _player.HealthChanged += SetHealth;
    }

    private void OnDisable()
    {
        _player.HealthMaxSet -= SetMaxHealth;
        _player.HealthChanged -= SetHealth;
    }

    protected abstract void SetHealth(float health);

    protected abstract void SetMaxHealth(float maxHealth);
}
