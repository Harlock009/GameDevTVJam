using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] float timeInMinutes = 1f;
    [SerializeField] TextMeshProUGUI timerText = null;

    SceneLoader sceneLoader;

    private float minutes;
    private float seconds;
    private float milliseconds;

    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timeInMinutes *= 60f;
        CalculateTime();
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void CalculateTime()
    {
        minutes = Mathf.Floor(timeInMinutes / 60);
        seconds = Mathf.FloorToInt(timeInMinutes % 60);
        milliseconds = Mathf.FloorToInt((timeInMinutes * 100) % 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && Debug.isDebugBuild)
        {
            timeInMinutes -= 30.0f;
        }

        Timer();
    }

    private void Timer()
    {
        timeInMinutes -= Time.deltaTime;

        CalculateTime();

        if(minutes <= 0 && seconds <= 0)
        {
            LoadGameOverScene();
        }
        else if(minutes < 0 && seconds < 0)
        {
            Destroy(gameObject);
        }
        if (seconds == 60)
        {
            seconds = 0;
        }

        timerText.text = minutes.ToString("0") + ":" + seconds.ToString("00");// + ":" + milliseconds.ToString("00");
    }

    public void LoadNextScenes()
    {
        
        sceneLoader.LoadNextScene();
        
    }

    public void LoadGameOverScene()
    {
        sceneLoader.LoadGameOverScene();
    }
}
