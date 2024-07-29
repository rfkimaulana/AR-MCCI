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
        objectRenderer.material = highlightMaterial; // Simpan material asli
        Debug.Log("Highlight material applied to " + gameObject.name);
    }

    public void ResetHighlight()
    {
        Debug.Log("ResetHighlight called on " + gameObject.name);
        objectRenderer.material = originalMaterial; // Simpan material asli
        Debug.Log("Original material restored to " + gameObject.name);
    }
}