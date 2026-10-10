using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlDissolve : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    [SerializeField] private float cutoff = 1.0f;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float cutoffDecreaseSpeed = 0.1f;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float EdgeSize = 0.2f;
    [SerializeField] Color MainColor;
    [SerializeField] Color EdgeColor;
    [SerializeField] private Renderer rend;
    [SerializeField] private GameObject particleEffect;
    private Material material;
    private bool isDissolving = false;
    void Start()
    {
        material = rend.material;
        material.SetColor("_MainColor", MainColor);
        material.SetColor("_EdgeColor", EdgeColor);
        material.SetFloat("_EdgeSize", EdgeSize);
        material.SetFloat("_Cutoff", cutoff);
    }

    // Update is called once per frame
    void Update()
    {
        if(InputSystem.GetDevice<Keyboard>()?.dKey.wasPressedThisFrame == true)
        {
            isDissolving = !isDissolving;
            particleEffect.SetActive(true);
        }
        if(isDissolving && cutoff > 0)
            cutoff -= cutoffDecreaseSpeed * Time.deltaTime;
        else if (!isDissolving && cutoff < 1)
            cutoff += cutoffDecreaseSpeed * Time.deltaTime;
        cutoff = Mathf.Clamp(cutoff, 0.0f, 1.0f);
        material.SetFloat("_Cutoff", cutoff);
        if(cutoff<= 0.5f)
        {
            rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        }
        else
        {
            rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        }
        if(cutoff <= 0.0f || cutoff >= 1.0f)
        {
            particleEffect.SetActive(false);
        }
    }
}
