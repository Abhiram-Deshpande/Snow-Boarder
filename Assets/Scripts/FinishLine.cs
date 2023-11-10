using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField]private ParticleSystem _psFinishLine;
    // Start is called before the first frame update
    private AudioSource _audioSource;
    public bool isFinished = false;
    [SerializeField] private GameObject _cameraControllerScript;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isFinished)
        {
            _psFinishLine.Play();
            _audioSource.Play();
            isFinished = true;
            Invoke("CallFinishedLineFunction",2.0f);
            Invoke("LoadScene",2.0f);
            
        }
    }
    private void LoadScene()
    {
        SceneManager.LoadScene(0);
    }

    private void CallFinishedLineFunction()
    {
        _cameraControllerScript.GetComponent<CameraAudioController>().FinishLineReached();
    }
}
