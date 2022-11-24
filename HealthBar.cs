using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Creature _creature;
    [SerializeField] private float _healthChangeSpeed;

    private Slider _healthBar;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
    }

    private void Update()
    {
        Coroutine smoothHealthChanger;

        if (_healthBar.value != _creature.CurrentHealth)
        {
            smoothHealthChanger = StartCoroutine(SmoothHealthChanger());
            StopCoroutine(smoothHealthChanger);
        }
    }

    private IEnumerator SmoothHealthChanger()
    {
        while (_healthBar.value != _creature.CurrentHealth)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _creature.CurrentHealth, _healthChangeSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
