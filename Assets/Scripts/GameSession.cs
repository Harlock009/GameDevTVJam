using TMPro;
using UnityEngine;
public class GameSession : MonoBehaviour
{
    [SerializeField] float timeInMinutes = 1f;
    [SerializeField] TextMeshProUGUI timerText = null;
    // Start is called before the first frame update
    void Start()
    {
        timeInMinutes *= 60f;
        timerText.text = timeInMinutes.ToString();   
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    private void Timer()
    {
        timeInMinutes -= Time.deltaTime;

        float minutes = Mathf.Floor(timeInMinutes / 60);
        float seconds = Mathf.FloorToInt(timeInMinutes % 60);
        float milliseconds = Mathf.FloorToInt((timeInMinutes * 100) % 100);

        if(minutes == 0 && seconds == 0 && milliseconds == 0)
        {
            Destroy(gameObject); //Example task..
        }
        if(seconds == 60)
        {
            seconds = 0;
        }

        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
    }
}
