using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue = 100;

    private float _minValue = 0;

    public event Action Die;
    public event Action<float, float> Changed;

    [field: SerializeField] public float Value { get; private set; } = 100;

    private void Awake()
    {
        Value = _maxValue;
    }

    private void Start()
    {
        Changed?.Invoke(Value, _maxValue);
    }

    public void Add(float value)
    {
        if (value <= 0)
            return;

        Value = Mathf.Clamp(Value + value, _minValue, _maxValue);
        Changed?.Invoke(Value, _maxValue);
    }

    public void TakeDamage(float damage)
    {
        if (damage <= 0)
            return;

        Value = Mathf.Clamp(Value - damage, _minValue, _maxValue);
        Changed?.Invoke(Value, _maxValue);

        if (Value == 0)
            Die?.Invoke();
    }
}