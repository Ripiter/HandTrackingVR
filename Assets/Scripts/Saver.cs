using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Saver : MonoBehaviour
{
    float timeCount;
    float startTimeCounter = 35.0f;
    public TextMeshProUGUI text;
    public TextMeshProUGUI textMessage;
    public TextMeshProUGUI timeForMove;
    public GestureDetector gestureDetector;

    public static Saver instance = null;
    private void Awake()
    {
        if (instance == null)

            //if not, set QuestManager to this
            instance = this;

        //If QuestManager already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern
            //meaning there can only ever be one instance of a QuestManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        timeCount = startTimeCounter;
    }

    // Update is called once per frame
    void Update()
    {
        timeCount -= Time.deltaTime;
        text.text = "Time til save: " + timeCount;
        if (timeCount < 0)
        {
            timeCount = startTimeCounter;
            //gestureDetector.Save();
        }
    }
}
