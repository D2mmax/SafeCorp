using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController1 : MonoBehaviour
{
    private Animator animator;
    public Renderer[] highenemyAreas; 
    public GameObject Cursor;
    public AudioSource selct;
    private byte z = 1;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && z == 1)
        {
            z +=1 ;

            if (animator != null)
            {
                animator.SetTrigger("Click1");
                selct.Play();
            }

            foreach (Renderer area in highenemyAreas)
            {
                Material targetMaterial = area.material;
                StartCoroutine(LerpAlpha(targetMaterial, 0f, 0.95f, 5f)); // Alpha from 0 to 95% over 5 seconds
            }

            StartCoroutine(CursorOn(Cursor, 4f));
        }
    }

    IEnumerator LerpAlpha(Material targetMaterial, float startAlpha, float targetAlpha, float duration)
    {
        float elapsedTime = 0f;
        Color color = targetMaterial.color;

        while (elapsedTime < duration)
        {
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);
            targetMaterial.color = new Color(color.r, color.g, color.b, newAlpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensures final value is exactly targetAlpha
        targetMaterial.color = new Color(color.r, color.g, color.b, targetAlpha);
    }

    IEnumerator CursorOn(GameObject move, float duration)
    {
        yield return new WaitForSeconds(duration);
        move.SetActive(true);
    }
}

