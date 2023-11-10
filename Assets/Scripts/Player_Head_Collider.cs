using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public class Player_Head_Collider :MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float delayAmount = 2.0f;
    private ParticleSystem _headParticleSystem;
    private bool _isSoundPlayed = false;
    
    void Start()
    {
        _headParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    private void OnTriggerEnter2D(Collider2D other)
    
    {
        if (other.CompareTag("Ground") && !_isSoundPlayed)
        {
            FindObjectOfType<PlayerController>().DisableControls();
            Debug.Log("Head Collided ---"+other.gameObject.ToString());
            _headParticleSystem.Play();
            _isSoundPlayed = true;
            Invoke("loadScene",delayAmount);
        }
    }

    private void loadScene()
    {
        SceneManager.LoadScene(0);
    }
}
