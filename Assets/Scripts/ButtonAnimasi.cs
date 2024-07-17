using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimasi : MonoBehaviour
{
    public AnimationClip[] animationClips; // Array untuk menyimpan daftar file animasi
    public GameObject[] highlightObjects; // Array untuk menyimpan referensi ke objek yang akan di-highlight
    private Animator animator; // Komponen Animator

    void Start()
    {
        animator = GetComponent<Animator>(); // Mendapatkan komponen Animator
        if (animator == null)
        {
            Debug.LogError("Animator component not found on " + gameObject.name);
        }
    }

    public void PlayAnimation(int index)
    {
        if (index < 0 || index >= animationClips.Length) 
        {
            Debug.LogWarning("Animation index out of range: " + index);
            return; // Validasi indeks
        }
        if (animationClips[index] == null)
        {
            Debug.LogError("Animation clip at index " + index + " is null");
            return;
        }
        Debug.Log("Playing animation: " + animationClips[index].name);
        animator.Play(animationClips[index].name, -1, 0f); // Memainkan animasi dari awal

        if (index < highlightObjects.Length && highlightObjects[index] != null)
        {
            HighlightManager highlightManager = highlightObjects[index].GetComponent<HighlightManager>();
            if (highlightManager != null)
            {
                Debug.Log("Starting highlight for " + highlightObjects[index].name);
                highlightManager.HighlightObject(); // Mulai highlight
                StartCoroutine(ResetHighlightAfterAnimation(highlightManager, animationClips[index].length));
            }
            else
            {
                Debug.LogError("HighlightManager component not found on " + highlightObjects[index].name);
            }
        }
    }

    private IEnumerator ResetHighlightAfterAnimation(HighlightManager highlightManager, float duration)
    {
        yield return new WaitForSeconds(duration);
        if (highlightManager != null)
        {
            highlightManager.ResetHighlight(); // Hentikan highlight setelah animasi selesai
        }
    }
}