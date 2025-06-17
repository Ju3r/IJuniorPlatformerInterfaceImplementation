using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void OnEnable()
    {
        Health.Changed += UpdateUI;
    }

    private void OnDisable()
    {
        Health.Changed -= UpdateUI;
    }

    public abstract void UpdateUI(float currentValue, float maxValue);
}