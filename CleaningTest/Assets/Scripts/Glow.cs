using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Glow : MonoBehaviour
{
    [SerializeField] private float glowSpeed;
    [SerializeField] private float maxGlow = 200;
    private Light2D glowSource;
    private Coroutine glowRoutine = null;

    private void Awake()
    {
        glowSource = GetComponentInChildren<Light2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (glowRoutine == null)
            {
                glowRoutine = StartCoroutine(GlowRoutine());
            }
            else
            {
                StopCoroutine(glowRoutine);
                glowRoutine = StartCoroutine(GlowRoutine());
            }
        }
    }

    private IEnumerator GlowRoutine()
    {
        while (glowSource.intensity < maxGlow)
        {
            glowSource.intensity += glowSpeed;
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(1f);

        while (glowSource.intensity > 0)
        {
            glowSource.intensity -= glowSpeed;
            yield return new WaitForFixedUpdate();
        }
    }
}
