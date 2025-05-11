using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisolveTest : MonoBehaviour
{
    public float dissolveDuration = 2;
    public float dissolveStrength;

    public Color startColor;
    public Color endColor;

    public void StartDissolver()
    {
        StartCoroutine(DissolveIn());
    }

    public IEnumerator DissolveIn()
    {
        float elapsedTime = 0;
        Material dissolveMaterial = GetComponent<Renderer>().material;
        Color lerpedColor;

        while (elapsedTime < dissolveDuration)
        {
            elapsedTime += Time.deltaTime;
            dissolveStrength = Mathf.Lerp(1, 0, elapsedTime / dissolveDuration);
            dissolveMaterial.SetFloat("_DissolveStrength", dissolveStrength);

            lerpedColor = Color.Lerp(startColor, endColor, dissolveStrength);
            dissolveMaterial.SetColor("BaseColor", lerpedColor);

            yield return null;
        }
    }
}

