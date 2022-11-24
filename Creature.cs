using UnityEngine;

public class Creature : MonoBehaviour
{
    private float _maxHealth = 50;

    public float CurrentHealth { get; private set; }

    private void OnEnable()
    {
        CurrentHealth = _maxHealth;
    }

    private void Update()
    {
        if (CurrentHealth < 0)
            CurrentHealth = 0;
    }

    public void TakeDamage(float damage) => CurrentHealth -= damage;
    
    public void Heal(float healingValue) => CurrentHealth += healingValue;
}
