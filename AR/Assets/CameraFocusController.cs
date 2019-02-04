using UnityEngine;
using System.Collections;
using Vuforia;

public class CameraFocusController : MonoBehaviour
{

    
    void Start()
    {
        var vuforia = VuforiaARController.Instance;
        vuforia.RegisterVuforiaStartedCallback(OnVuforiaStarted);
        vuforia.RegisterOnPauseCallback(OnPaused);
    }

    private void OnVuforiaStarted()
    {
       Vuforia.CameraDevice.Instance.SetFocusMode(
         Vuforia.CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }

    private void OnPaused(bool paused)
    {
        if (!paused) // resumed
        {
            // Set again autofocus mode when app is resumed
           Vuforia.CameraDevice.Instance.SetFocusMode(
              Vuforia.CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        }
    }
}