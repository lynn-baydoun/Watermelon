using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text time;
    public float remaining = 60;
    public bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        time = GameObject.Find("Timerr").GetComponent<Text>();
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (remaining > 0)
            {
                Display(remaining);
                remaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                remaining = 0;
                Display(-1f);
                active = false;
            }
        }
        
    }
    void Display(float timeToDisplay){
        timeToDisplay += 1;
        float seconds = Mathf.FloorToInt(timeToDisplay);
        time.text = string.Format("{0:00}", seconds);
    }
}
