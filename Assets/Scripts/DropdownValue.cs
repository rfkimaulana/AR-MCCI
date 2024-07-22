using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropdownValue : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public List<GameObjectList> gameObjectsPerIndex; // List of GameObjectList to activate per index
    public List<AudioManager> audioManagers; // Added list of AudioManagers

    [System.Serializable]
    public class GameObjectList
    {
        public List<GameObject> gameObjects;
    }

    void Start()
    {
        if (dropdown == null)
        {
            Debug.LogError("Dropdown is not assigned in the Inspector");
            return;
        }

        if (gameObjectsPerIndex == null || gameObjectsPerIndex.Count == 0)
        {
            Debug.LogError("gameObjectsPerIndex is not assigned or empty in the Inspector");
            return;
        }

        if (audioManagers == null || audioManagers.Count == 0)
        {
            Debug.LogError("audioManagers list is not assigned or empty in the Inspector");
            return;
        }

        // Deactivate all GameObjects at the start
        DeactivateAllGameObjects();

        // Add listener for dropdown value change
        dropdown.onValueChanged.AddListener(DropdownItemSelected);
    }

    void DropdownItemSelected(int index)
    {
        // Reset all audio when dropdown value changes
        foreach (var audioManager in audioManagers)
        {
            if (audioManager != null)
            {
                audioManager.ResetAllAudio();
            }
        }

        // Deactivate all GameObjects first
        DeactivateAllGameObjects();

        // Activate the selected GameObjects if index is valid
        if (index >= 0 && index < gameObjectsPerIndex.Count)
        {
            foreach (GameObject obj in gameObjectsPerIndex[index].gameObjects)
            {
                if (obj != null)
                {
                    obj.SetActive(true);
                    Debug.Log("Activated GameObject: " + obj.name);
                }
            }
        }

        // Additional logic for when a dropdown option is selected
        OnDropdownOptionClicked(index);
    }

    void DeactivateAllGameObjects()
    {
        foreach (GameObjectList gameObjectList in gameObjectsPerIndex)
        {
            foreach (GameObject obj in gameObjectList.gameObjects)
            {
                if (obj != null)
                {
                    obj.SetActive(false);
                }
            }
        }
    }

    void OnDropdownOptionClicked(int index)
    {
        Debug.Log("Dropdown option " + index + " clicked");
        // Add any additional logic you want to execute when a dropdown option is clicked

        // Ensure all GameObjects are activated for the selected dropdown option
        if (index >= 0 && index < gameObjectsPerIndex.Count)
        {
            foreach (GameObject obj in gameObjectsPerIndex[index].gameObjects)
            {
                if (obj != null)
                {
                    obj.SetActive(true);
                    Debug.Log("Activated GameObject: " + obj.name);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}