using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightManager : MonoBehaviour
{
    public Material highlightMaterial; // Material untuk highlight
    private Material originalMaterial; // Material asli
    private Renderer objectRenderer; // Renderer dari GameObject

    void Start()
    {
        objectRenderer = GetComponent<Renderer>(); // Mendapatkan komponen Renderer
        if (objectRenderer == null)
        {
            Debug.LogError("Renderer component not found on " + gameObject.name);
        }
        else
        {
            originalMaterial = objectRenderer.material; // Simpan material asli
        }
    }

    public void HighlightObject()
    {
        Debug.Log("HighlightObject called on " + gameObject.name);
        if (objectRenderer != null && highlightMaterial != null)
        {
            objectRenderer.material = highlightMaterial; // Ganti material dengan highlight
        }
    }

    public void ResetHighlight()
    {
        Debug.Log("ResetHighlight called on " + gameObject.name);
        if (objectRenderer != null && originalMaterial != null)
        {
            objectRenderer.material = originalMaterial; // Kembalikan material asli
        }
    }
}