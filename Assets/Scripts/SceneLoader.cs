using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Animator transition;

    private void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName.ToUpper() == "WINGAME" || sceneName.ToUpper() == "GAMEOVER")
        {
            if (FindObjectOfType<GameSession>() != null)
            Destroy(FindObjectOfType<GameSession>().gameObject);
        }
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadSceneTransition(currentSceneIndex + 1));
    }

    IEnumerator LoadSceneTransition(int sceneIndex)
    {
        if (transition != null)
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
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
