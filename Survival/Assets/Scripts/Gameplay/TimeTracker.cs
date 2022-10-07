using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeTracker : MonoBehaviour
{
    [SerializeField]
    private Text timer;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        TimeSpan time = TimeSpan.FromSeconds(currentTime);

        if (time.Hours > 0)
        {
            timer.text = time.ToString(@"hh\:mm\:ss");
        }
        else if (time.Minutes > 0)
        {
            timer.text = time.ToString(@"mm\:ss");
        }
        else
        {
            timer.text = time.ToString(@"ss");
        }
    }
}
