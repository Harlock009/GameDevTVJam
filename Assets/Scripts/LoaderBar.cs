using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoaderBar : MonoBehaviour
{
    [SerializeField] GameObject loadingPanel;
    [SerializeField] Slider slider;
    [SerializeField] Text loadText;
    public void LoadNextSceneAsync()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(AsyncLoadNextScene(currentSceneIndex + 1));
    }

    IEnumerator AsyncLoadNextScene(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingPanel.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;

            loadText.text = progress * 100 + "%";

            yield return null;
        }
    }
}
