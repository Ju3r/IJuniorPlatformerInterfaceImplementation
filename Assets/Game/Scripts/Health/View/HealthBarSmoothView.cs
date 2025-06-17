using System.Collections;
using UnityEngine;

public class HealthBarSmoothView : HealthBarView
{
    [SerializeField] private float _transitionSpeed = 2f;

    private Coroutine _smoothTransitionCoroutine;

    public override void UpdateUserInterface(float currentValue, float maxValue)
    {
        if (_smoothTransitionCoroutine != null)
        {
            StopCoroutine(_smoothTransitionCoroutine);
        }

        float targetValue = currentValue / maxValue;
        _smoothTransitionCoroutine = StartCoroutine(SmoothTransition(Slider.value, targetValue));
    }

    private IEnumerator SmoothTransition(float startValue, float endValue)
    {
        float duration = 0.1f;
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            Slider.value = Mathf.Lerp(startValue, endValue, timeElapsed / duration);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        Slider.value = endValue;
        _smoothTransitionCoroutine = null;
    }
}
