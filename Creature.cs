using UnityEngine;
using UnityEngine.Events;

public class Creature : MonoBehaviour
{
    public UnityAction HealthChanged;

    private float _healAmount = 10;
    private float _damageAmount = -10;
    private float _maxHealth = 50;

    public float CurrentHealth { get; private set; }

    private void OnEnable()
    {
        CurrentHealth = _maxHealth;
    }

    public void Heal() => ChangeHealth(_healAmount);

    public void TakeDamage() => ChangeHealth(_damageAmount);

    private void ChangeHealth(float value)
    {
        CurrentHealth += value;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, _maxHealth);
        HealthChanged?.Invoke();
    }
}
