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
            Debug.Log("Original material set for " + gameObject.name);
        }
    }

    public void HighlightObject()
    {
        Debug.Log("HighlightObject called on " + gameObject.name);
        if (objectRenderer != null && highlightMaterial != null)
        {
            objectRenderer.material = highlightMaterial; // Ganti material dengan highlight
            Debug.Log("Highlight material applied to " + gameObject.name);
        }
        else
        {
            if (objectRenderer == null)
            {
                Debug.LogError("Renderer component is null on " + gameObject.name);
            }
            if (highlightMaterial == null)
            {
                Debug.LogError("Highlight material is not set on " + gameObject.name);
            }
        }
    }

    public void ResetHighlight()
    {
        Debug.Log("ResetHighlight called on " + gameObject.name);
        if (objectRenderer != null && originalMaterial != null)
        {
            objectRenderer.material = originalMaterial; // Kembalikan material asli
            Debug.Log("Original material restored to " + gameObject.name);
        }
        else
        {
            if (objectRenderer == null)
            {
                Debug.LogError("Renderer component is null on " + gameObject.name);
            }
            if (originalMaterial == null)
            {
                Debug.LogError("Original material is not set on " + gameObject.name);
            }
        }
    }
}