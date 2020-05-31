using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StairsExit : MonoBehaviour
{
    [SerializeField] BoxCollider2D stairsCollider;
    [SerializeField] AudioClip doorOpenSFX;
    [SerializeField] AudioClip levelExitSFX;

    private void Start()
    {
        Pedestal.OnPedestalCompleted += OnPuzzleCompleted;
        WiseMonkeys.OnWiseMonkeyCompleted += OnPuzzleCompleted;
    }

    private void OnPuzzleCompleted()
    {
        foreach (Transform child in transform)
        {
            if (child != null)
                Destroy(child.gameObject);
        }

        stairsCollider.enabled = true;
        AudioSource.PlayClipAtPoint(doorOpenSFX, Camera.main.transform.position, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LeaveLevel(collision.gameObject));
    }

    IEnumerator LeaveLevel(GameObject player)
    {
        AudioSource.PlayClipAtPoint(levelExitSFX, Camera.main.transform.position, 0.5f);
        Destroy(player);
        yield return new WaitForSeconds(1f);
        FindObjectOfType<SceneLoader>().LoadNextScene();
    }

    private void OnDestroy()
    {
        Pedestal.OnPedestalCompleted -= OnPuzzleCompleted;
        WiseMonkeys.OnWiseMonkeyCompleted -= OnPuzzleCompleted;
    }
}
