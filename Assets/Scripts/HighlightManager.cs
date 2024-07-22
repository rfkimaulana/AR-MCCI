using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightManager : MonoBehaviour
{
    public Material highlightMaterial; 
    private Material originalMaterial; 
    private Renderer objectRenderer; 

    void Start()
    {
        try
        {
            objectRenderer = GetComponent<Renderer>(); 
            if (objectRenderer == null)
            {
                throw new System.Exception("Renderer component not found on " + gameObject.name);
            }
            else
            {
                originalMaterial = objectRenderer.material; 
                Debug.Log("Original material set for " + gameObject.name);
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }

    public void HighlightObject()
    {
        try
        {
            Debug.Log("HighlightObject called on " + gameObject.name);
            if (objectRenderer != null && highlightMaterial != null)
            {
                objectRenderer.material = highlightMaterial; 
                Debug.Log("Highlight material applied to " + gameObject.name);
            }
            else
            {
                if (objectRenderer == null)
                {
                    throw new System.Exception("Renderer component is null on " + gameObject.name);
                }
                if (highlightMaterial == null)
                {
                    throw new System.Exception("Highlight material is not set on " + gameObject.name);
                }
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }

    public void ResetHighlight()
    {
        try
        {
            Debug.Log("ResetHighlight called on " + gameObject.name);
            if (objectRenderer != null && originalMaterial != null)
            {
                objectRenderer.material = originalMaterial; 
                Debug.Log("Original material restored to " + gameObject.name);
            }
            else
            {
                if (objectRenderer == null)
                {
                    throw new System.Exception("Renderer component is null on " + gameObject.name);
                }
                if (originalMaterial == null)
                {
                    throw new System.Exception("Original material is not set on " + gameObject.name);
                }
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }
}
}