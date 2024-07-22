using System.Collections;
using System.Collections.Generic;

using UnityEngine;


[System.Serializable]
public class HighlightObjectGroup
{
    public GameObject[] gameObjects;

}

public class ButtonAnimasi : MonoBehaviour
{

    public AnimationClip[] animationClips; 

    public HighlightObjectGroup[] highlightObjects; 

    private Animator animator; 

    private Coroutine highlightCoroutine; 


    void Start()

    {

        animator = GetComponent<Animator>(); 

        if (animator == null)

        {

            Debug.LogError("Animator component not found on " + gameObject.name);

        }

    }


    public void PlayAnimation(int index, int subIndex)

    {

        Debug.LogWarning("PlayAnimation method is disabled.");

        return;

    }


    public void StopHighlight()

    {

        Debug.LogWarning("StopHighlight method is disabled.");

        return;
    }


    private IEnumerator ResetHighlightAfterAnimation(HighlightManager highlightManager, float duration)

    {

        Debug.LogWarning("ResetHighlightAfterAnimation method is disabled.");
        yield break;

    }


    public void ResetAllHighlights()

    {

        Debug.LogWarning("ResetAllHighlights method is disabled.");

        return;

    }


    public void ResetAllAnimations()

    {

        Debug.LogWarning("ResetAllAnimations method is disabled.");

        return;

    }


    public void OnForwardButtonClick()

    {
        Debug.LogWarning("OnForwardButtonClick method is disabled.");

        return;

    }

}