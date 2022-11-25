using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Creature _creature;
    [SerializeField] private float _healthChangeSpeed;

    private Coroutine _smoothHealthChange;
    private Slider _healthBar;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _creature.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _creature.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged()
    {
        if (_smoothHealthChange != null)
            StopCoroutine(_smoothHealthChange);

        _smoothHealthChange = StartCoroutine(SmoothHealthChange());
    }

    private IEnumerator SmoothHealthChange()
    {
        while (_healthBar.value != _creature.CurrentHealth)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _creature.CurrentHealth, _healthChangeSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
