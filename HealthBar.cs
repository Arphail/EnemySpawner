using System.Collections;
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

    public void OnHealthChanged()
    {
        StartCoroutine(SmoothHealthChange());
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
