using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Player player;

    private void OnEnable()
    {
        player.HealthChanged += ShowNewValue;
    }

    private void OnDisable()
    {
        player.HealthChanged -= ShowNewValue;
    }

    protected abstract void ShowNewValue(float health);
}
