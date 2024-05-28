using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerController playerController;
    private Vector2 direction;
    public LayerMask groundLayerMask;
    Rigidbody rigidbody;
    void Start()
    {
        
        playerController = GetComponent<PlayerController>();
        rigidbody = GetComponent<Rigidbody>();
        playerController.OnMoveEvent += OnMove;
        playerController.OnJumpEvent += OnJump;
        playerController.OnLookEvent += OnLook;
    }

    private void FixedUpdate() {
        Move();
    }
    private void OnMove(Vector2 vector)
    {
        direction = vector;
        
    }
    private void Move(){
        Vector3 dir = new Vector3(direction.x, 0,direction.y);
        dir *= GameManager.Instance.PlayerData.speed;
        rigidbody.AddForce(dir,ForceMode.VelocityChange);
    }
    private void OnLook(Vector2 vector)
    {
        throw new NotImplementedException();
    }

    private void OnJump()
    {
        Debug.Log(IsGrounded());
        if(IsGrounded()){
            rigidbody.AddForce(Vector3.up * GameManager.Instance.PlayerData.jumpPower, ForceMode.Impulse);
        }
        
    }

    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]{
            new Ray(transform.position + (transform.forward *0.2f)+ (transform.up*0.01f),Vector3.down),
            new Ray(transform.position + (-transform.forward *0.2f)+ (transform.up*0.01f),Vector3.down),
            new Ray(transform.position + (transform.forward *0.2f)+ (transform.up*0.01f),Vector3.down),
            new Ray(transform.position + (-transform.forward *0.2f)+ (transform.up*0.01f),Vector3.down),
        };
        for (int i = 0; i < rays.Length; i++)
        {  
            RaycastHit hit;
            if (Physics.Raycast(rays[i], out hit, 0.7f,  groundLayerMask))
            {
                return true;
            }
        }
        return false;
    }
}
