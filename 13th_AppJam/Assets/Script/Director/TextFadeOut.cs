using UnityEngine;
using System.Collections;

public class TextFadeOut : MonoBehaviour
{
    [SerializeField]
    private TextMesh text;

    [SerializeField]
    private float time;

    [SerializeField]
    private AnimationCurve curve;

    private void Awake()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
    }

    public void FadeOut()
    {
        StartCoroutine(_FadeOut());   
    }

    private IEnumerator _FadeOut()
    {
        float t = 0f;

        Color startColor = text.color;
        Color endColor = new Color(text.color.r, text.color.g, text.color.b, 255);

        while (t < 1f)
        {
            t += Time.deltaTime / time;

            text.color = Color.Lerp(startColor, endColor, curve.Evaluate(t));

            yield return null;
        }
    }
}