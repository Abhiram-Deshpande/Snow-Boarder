using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.U2D;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2d;
    [FormerlySerializedAs("torque")] [SerializeField] private float torqueAmount = 1f;
    private SurfaceEffector2D _surfaceEffector2D;
    private readonly float _boostSpeed = 10f;
    private readonly float _baseSpeed = 5f;
    private bool canMove = true;
    void Start()
    {
         rb2d =GetComponent<Rigidbody2D>();
         _surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            SpeedUpPlayer();    
        }
        

    }

    private void RotatePlayer() { 
        if (Input.GetKey(KeyCode.LeftArrow)){ 
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) { 
            rb2d.AddTorque(-torqueAmount);
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }
    private void SpeedUpPlayer()
    {
        _surfaceEffector2D.speed = Input.GetKey(KeyCode.Space) ? _boostSpeed : _baseSpeed;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        
    }
}
