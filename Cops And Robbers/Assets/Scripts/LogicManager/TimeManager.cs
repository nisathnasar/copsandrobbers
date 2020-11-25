using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    private float currentTime = 0f;
    private float startingTime = 300f; //5 minutes

    [SerializeField] Text countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        string minutes = Mathf.Floor(currentTime / 60).ToString("00");
        string seconds = Mathf.RoundToInt(currentTime % 60).ToString("00");
        
        countdownText.text = minutes + ":" + seconds;
        if (currentTime <= 0) 
        {
            ResetTimer();
            //load roundbreak scene
        }
    }

    /// <summary>
    /// Call this method to force-end the timer + move to next scene. 
    /// </summary>
    public void EndTimer() 
    {
        currentTime = startingTime;
    }

    /// <summary>
    /// Reset the timer back to start time.
    /// </summary>
    public void ResetTimer() {
        currentTime = startingTime;
    }
}
