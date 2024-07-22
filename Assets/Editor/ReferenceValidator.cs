using UnityEditor;
using UnityEngine;

public class ReferenceValidator : EditorWindow
{
    [MenuItem("Tools/Validate References")]
    public static void ShowWindow()
    {
        GetWindow<ReferenceValidator>("Validate References");
    }

    void OnGUI()
    {
        if (GUILayout.Button("Validate References"))
        {
            Debug.Log("Validate References button clicked");
            ValidateReferences();
        }
    }

    void ValidateReferences()
    {
        Debug.Log("Starting reference validation");
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            ValidateDropdownValue(obj);
            ValidateButtonAnimasi(obj);
            ValidateAudioManager(obj);
            ValidateSetupButtons(obj);
            ValidateStepNavigation(obj);
            ValidateHighlightManager(obj);
            ValidateButtonManager(obj);
        }
        Debug.Log("Reference validation completed");
    }

    void ValidateDropdownValue(GameObject obj)
    {
        DropdownValue dropdownValue = obj.GetComponent<DropdownValue>();
        if (dropdownValue != null)
        {
            if (dropdownValue.dropdown == null)
            {
                Debug.LogError("Dropdown is not assigned in the Inspector on " + obj.name);
            }

            if (dropdownValue.gameObjectsPerIndex == null || dropdownValue.gameObjectsPerIndex.Count == 0)
            {
                Debug.LogError("gameObjectsPerIndex is not assigned or empty in the Inspector on " + obj.name);
            }

            if (dropdownValue.audioManagers == null || dropdownValue.audioManagers.Count == 0)
            {
                Debug.LogError("audioManagers list is not assigned or empty in the Inspector on " + obj.name);
            }
        }
    }

    void ValidateButtonAnimasi(GameObject obj)
    {
        ButtonAnimasi buttonAnimasi = obj.GetComponent<ButtonAnimasi>();
        if (buttonAnimasi != null)
        {
            if (buttonAnimasi.animationClips == null || buttonAnimasi.animationClips.Length == 0)
            {
                Debug.LogError("AnimationClips array is not assigned or empty in the Inspector on " + obj.name);
            }

            if (buttonAnimasi.highlightObjects == null || buttonAnimasi.highlightObjects.Length == 0)
            {
                Debug.LogError("HighlightObjects array is not assigned or empty in the Inspector on " + obj.name);
            }

            if (buttonAnimasi.GetComponent<Animator>() == null)
            {
                Debug.LogError("Animator component not found on " + obj.name);
            }

            foreach (var group in buttonAnimasi.highlightObjects)
            {
                if (group != null)
                {
                    foreach (var gameObject in group.gameObjects)
                    {
                        if (gameObject == null)
                        {
                            Debug.LogWarning("GameObject is null in HighlightObjectGroup on " + obj.name);
                        }
                        else
                        {
                            if (gameObject.GetComponent<HighlightManager>() == null)
                            {
                                Debug.LogError("HighlightManager component not found on " + gameObject.name);
                            }
                        }
                    }
                }
                else
                {
                    Debug.LogWarning("HighlightObjectGroup is null in the array on " + obj.name);
                }
            }
        }
    }

    void ValidateAudioManager(GameObject obj)
    {
        AudioManager audioManager = obj.GetComponent<AudioManager>();
        if (audioManager != null)
        {
            if (audioManager.audioClips == null || audioManager.audioClips.Length == 0)
            {
                Debug.LogError("AudioClips array is not assigned or empty in the Inspector on " + obj.name);
            }

            if (audioManager.GetComponent<AudioSource>() == null)
            {
                Debug.LogError("AudioSource component not found on " + obj.name);
            }
        }
    }

    void ValidateSetupButtons(GameObject obj)
    {
        SetupButtons setupButtons = obj.GetComponent<SetupButtons>();
        if (setupButtons != null)
        {
            if (setupButtons.buttons == null || setupButtons.buttons.Length == 0)
            {
                Debug.LogError("Buttons array is not assigned or empty in the Inspector on " + obj.name);
            }

            if (setupButtons.buttonAnimasi == null)
            {
                Debug.LogError("ButtonAnimasi reference is not set in " + obj.name);
            }

            if (setupButtons.audioManager == null)
            {
                Debug.LogError("AudioManager reference is not set in " + obj.name);
            }
        }
    }

    void ValidateStepNavigation(GameObject obj)
    {
        StepNavigation stepNavigation = obj.GetComponent<StepNavigation>();
        if (stepNavigation != null)
        {
            if (stepNavigation.forwardButtonPrefab == null)
            {
                Debug.LogError("ForwardButtonPrefab is not assigned in the Inspector on " + obj.name);
            }

            if (stepNavigation.backwardButtonPrefab == null)
            {
                Debug.LogError("BackwardButtonPrefab is not assigned in the Inspector on " + obj.name);
            }

            if (stepNavigation.buttonAnimasi == null)
            {
                Debug.LogError("ButtonAnimasi reference is not set in " + obj.name);
            }
        }
    }

    void ValidateHighlightManager(GameObject obj)
    {
        HighlightManager highlightManager = obj.GetComponent<HighlightManager>();
        if (highlightManager != null)
        {
            if (highlightManager.highlightMaterial == null)
            {
                Debug.LogError("HighlightMaterial is not assigned in the Inspector on " + obj.name);
            }

            if (highlightManager.GetComponent<Renderer>() == null)
            {
                Debug.LogError("Renderer component not found on " + obj.name);
            }
        }
    }

    void ValidateButtonManager(GameObject obj)
    {
        ButtonManager buttonManager = obj.GetComponent<ButtonManager>();
        if (buttonManager != null)
        {
            // Tidak ada referensi publik yang perlu divalidasi di ButtonManager
            // Tambahkan validasi lain jika diperlukan
        }
    }
}