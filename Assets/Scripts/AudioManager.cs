using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips; // Array untuk menyimpan daftar file audio
    private AudioSource audioSource; // Komponen AudioSource

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Mendapatkan komponen AudioSource
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on " + gameObject.name);
        }
    }

    public void PlayAudio(int index)
    {
        if (index < 0 || index >= audioClips.Length)
        {
            Debug.LogWarning("Audio index out of range: " + index);
            return; // Validasi indeks
        }
        if (audioClips[index] == null)
        {
            Debug.LogError("Audio clip at index " + index + " is null");
            return;
        }
        Debug.Log("Playing audio: " + audioClips[index].name);
        audioSource.clip = audioClips[index];
        audioSource.Play(); // Memainkan audio berdasarkan indeks
    }

    // Metode untuk mereset semua audio
    public void ResetAllAudio()
    {
        audioSource.Stop(); // Menghentikan audio yang sedang diputar
        audioSource.clip = null; // Menghapus referensi ke audio clip
        Debug.Log("All audio has been reset.");
    }
}