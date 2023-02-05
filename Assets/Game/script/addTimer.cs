using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addTimer : MonoBehaviour
{
    public timer Timer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        Timer.remaining += 10;
        Destroy(gameObject);
    }
}
