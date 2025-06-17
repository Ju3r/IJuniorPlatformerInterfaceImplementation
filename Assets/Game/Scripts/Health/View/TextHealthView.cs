using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TextHealthView : HealthView
{
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    public override void UpdateUserInterface(float currentValue, float maxValue)
    {
        _text.text = $"{currentValue} / {maxValue}";
    }
}
