using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarView : HealthView
{
    protected Slider Slider;

    private void Awake()
    {
        Slider = GetComponent<Slider>();
    }

    public override void UpdateUserInterface(float currentValue, float maxValue)
    {
        Slider.value = currentValue / maxValue;
    }
}
