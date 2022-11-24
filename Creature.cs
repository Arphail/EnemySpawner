using UnityEngine;
using UnityEngine.Events;

public class Creature : MonoBehaviour
{
    [SerializeField] private UnityEvent _healthChanged;

    private float _maxHealth = 50;

    public float CurrentHealth { get; private set; }

    private void OnEnable()
    {
        CurrentHealth = _maxHealth;
    }

    public void ChangeHealth(float value)
    {
        CurrentHealth += value;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, _maxHealth);
        _healthChanged?.Invoke();
    }
}
