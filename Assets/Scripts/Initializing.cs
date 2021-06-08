using EasyMobile;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Initializing : MonoBehaviour
{
    private void Awake()
    {
        RuntimeManager.Initialized +=
            OnEMRuntimeInitialized; // get notified when Easy Mobile runtime has been initialized
    }

// Unsubscribe
    private void OnDisable()
    {
        RuntimeManager.Initialized -= OnEMRuntimeInitialized;
    }

// Event handler
    private void OnEMRuntimeInitialized()
    {
        SceneManager.LoadScene("Menu");
    }
}