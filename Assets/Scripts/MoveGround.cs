using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    public Transform[] points;
    public float speed=2;
    public int index=1;
    Rigidbody rigid;
    Vector3 direction;
    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        rigid=GetComponent<Rigidbody>();
        direction = (points[index].position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, points[index].position) < 0.1f)
        {
            index++;
            if (index >= points.Length)
            {
                index = 0;
            }

            direction = (points[index].position - transform.position).normalized;
            if (playerMovement != null)
            {
                playerMovement.MoveGround = direction*speed;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position,points[index].position,speed*Time.deltaTime);
        

    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("실행");
            playerMovement = other.gameObject.GetComponent<PlayerMovement>();
            playerMovement.MoveGround = direction*speed;
            playerMovement.isOn = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            playerMovement.isOn = false;
            playerMovement=null;
        }
    }
}
