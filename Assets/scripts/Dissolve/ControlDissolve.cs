using System.Collections;
using UnityEngine;

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
    [SerializeField] private Renderer renderer;
    private Material material;
    void Start()
    {
        material = renderer.material;
        material.SetColor("_MainColor", MainColor);
        material.SetColor("_EdgeColor", EdgeColor);
        material.SetFloat("_EdgeSize", EdgeSize);
        material.SetFloat("_Cutoff", cutoff);
    }

    // Update is called once per frame
    void Update()
    {
        material.SetColor("_MainColor", MainColor);
        material.SetColor("_EdgeColor", EdgeColor);
        material.SetFloat("_EdgeSize", EdgeSize);
        cutoff -= cutoffDecreaseSpeed * Time.deltaTime;
        material.SetFloat("_Cutoff", cutoff);
        if (cutoff <= 0.0f)
            cutoff = 1.0f;
    }
}
