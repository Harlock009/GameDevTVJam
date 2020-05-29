using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject titleCanvas;
    [SerializeField] GameObject creditsCanvas;
    [SerializeField] GameObject loaderCanvas;

    public void OnCreditsButton()
    {
        titleCanvas.SetActive(false);
        loaderCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }

    public void OnBackButton()
    {
        titleCanvas.SetActive(true);
        loaderCanvas.SetActive(false);
        creditsCanvas.SetActive(false);
    }

    public void OnBeginButton()
    {
        titleCanvas.SetActive(false);
        loaderCanvas.SetActive(true);
    }
}
