using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject titleCanvas;
    [SerializeField] GameObject creditsCanvas;
    [SerializeField] GameObject howToPlayCanvas;
    [SerializeField] GameObject loaderCanvas;
    [SerializeField] AudioSource selectSFX;

    public void OnCreditsButton()
    {
        titleCanvas.SetActive(false);
        loaderCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }

    public void OnHowToPlayButton()
    {
        titleCanvas.SetActive(false);
        loaderCanvas.SetActive(false);
        creditsCanvas.SetActive(false);
        howToPlayCanvas.SetActive(true);
    }

    public void OnBackButton()
    {
        titleCanvas.SetActive(true);
        loaderCanvas.SetActive(false);
        creditsCanvas.SetActive(false);
        howToPlayCanvas.SetActive(false);
    }

    public void OnBeginButton()
    {
        titleCanvas.SetActive(false);
        loaderCanvas.SetActive(true);
    }
}
