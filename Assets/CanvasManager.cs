using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject titleCanvas;
    [SerializeField] GameObject creditsCanvas;

    public void OnCreditsButton()
    {
        titleCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }

    public void OnBackButton()
    {
        titleCanvas.SetActive(true);
        creditsCanvas.SetActive(false);
    }
}
