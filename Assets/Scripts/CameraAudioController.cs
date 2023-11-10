using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAudioController : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinishLineReached()
    {
        GetComponent<AudioSource>().Stop();
    }
}
