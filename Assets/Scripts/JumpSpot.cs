using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSpot : MonoBehaviour
{
    public float JumpPower = 50;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<PlayerMovement>().OnJumpSpot(50);
        }
    }
}
