using UnityEngine;
using UnityEngine.UI;

public class SetupButtons : MonoBehaviour
{
    public Button[] buttons; // Array untuk menyimpan daftar tombol
    public ButtonAnimasi buttonAnimasi; // Referensi ke skrip ButtonAnimasi
    public AudioManager audioManager; // Referensi ke skrip AudioManager

    void Start()
    {
        if (buttonAnimasi == null)
        {
            Debug.LogError("ButtonAnimasi reference is not set in " + gameObject.name);
            return;
        }

        if (audioManager == null)
        {
            Debug.LogError("AudioManager reference is not set in " + gameObject.name);
            return;
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i] == null)
            {
                Debug.LogError("Button at index " + i + " is null");
                continue;
            }

            int buttonIndex = i; // Perlu variabel lokal untuk menghindari masalah closure
            buttons[i].onClick.AddListener(() => 
            {
                Debug.Log("Button clicked: " + buttonIndex);
                buttonAnimasi.PlayAnimation(buttonIndex);
                audioManager.PlayAudio(buttonIndex);
            });
        }
    }
}