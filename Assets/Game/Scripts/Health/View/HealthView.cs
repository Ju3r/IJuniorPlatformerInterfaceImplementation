using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void OnEnable()
    {
        Health.Changed += UpdateUserInterface;
    }

    private void OnDisable()
    {
        Health.Changed -= UpdateUserInterface;
    }

    public abstract void UpdateUserInterface(float currentValue, float maxValue);
}