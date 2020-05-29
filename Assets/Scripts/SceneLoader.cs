using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Animator transition;
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadSceneTransition(currentSceneIndex + 1));
    }

    IEnumerator LoadSceneTransition(int sceneIndex)
    {
        transition.SetTrigger("Close");

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(sceneIndex);
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void QuitScene()
    {
        Application.Quit();
    }
}
