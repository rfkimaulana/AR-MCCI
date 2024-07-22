using UnityEngine;
using UnityEngine.UI;

public class SetupButtons : MonoBehaviour
{
    public Button[] buttons; 
    public ButtonAnimasi buttonAnimasi; 
    public AudioManager audioManager; 

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

            int buttonIndex = i; 
            buttons[i].onClick.AddListener(() => 
            {
                Debug.Log("Button clicked: " + buttonIndex);

            });
        }
    }

}