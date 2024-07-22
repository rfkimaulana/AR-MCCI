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
    public AnimationClip[] animationClips; // Array untuk menyimpan daftar file animasi
    public HighlightObjectGroup[] highlightObjects; // Array untuk menyimpan grup objek yang akan di-highlight
    private Animator animator; // Komponen Animator
    private Coroutine highlightCoroutine; // Menyimpan referensi coroutine yang sedang berjalan

    void Start()
    {
        animator = GetComponent<Animator>(); // Mendapatkan komponen Animator
        if (animator == null)
        {
            Debug.LogError("Animator component not found on " + gameObject.name);
        }
    }

    public void PlayAnimation(int index, int subIndex)
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
            Debug.Log("HighlightObjectGroup found at index: " + index);
            foreach (var gameObject in highlightObjects[index].gameObjects)
            {
                if (gameObject != null)
                {
                    HighlightManager highlightManager = gameObject.GetComponent<HighlightManager>();
                    if (highlightManager != null)
                    {
                        Debug.Log("Starting highlight for " + gameObject.name);
                        highlightManager.HighlightObject(); // Mulai highlight
                        highlightCoroutine = StartCoroutine(ResetHighlightAfterAnimation(highlightManager, animationClips[index].length));
                    }
                    else
                    {
                        Debug.LogError("HighlightManager component not found on " + gameObject.name);
                    }
                }
                else
                {
                    Debug.LogWarning("GameObject is null in HighlightObjectGroup at index: " + index);
                }
            }
        }
        else
        {
            Debug.LogWarning("HighlightObjectGroup is null at index: " + index);
        }
    }

    public void StopHighlight()
    {
        if (highlightCoroutine != null)
        {
            StopCoroutine(highlightCoroutine);
            highlightCoroutine = null;
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

    // Tambahkan metode untuk mereset semua highlight
    public void ResetAllHighlights()
    {
        StopHighlight();
        foreach (var group in highlightObjects)
        {
            if (group != null)
            {
                foreach (var gameObject in group.gameObjects)
                {
                    if (gameObject != null)
                    {
                        HighlightManager highlightManager = gameObject.GetComponent<HighlightManager>();
                        if (highlightManager != null)
                        {
                            highlightManager.ResetHighlight(); // Reset highlight
                        }
                    }
                }
            }
        }
    }

    // Tambahkan metode untuk mereset semua animasi
    public void ResetAllAnimations()
    {
        foreach (var clip in animationClips)
        {
            if (clip != null)
            {
                animator.Play(clip.name, -1, 0f); // Memainkan animasi dari awal
                animator.StopPlayback(); // Menghentikan animasi
            }
        }
    }

    // Tambahkan metode untuk menangani klik tombol forward
    public void OnForwardButtonClick()
    {
        ResetAllHighlights();
        // Tambahkan logika untuk menangani klik tombol forward
    }
}