using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("Stats")]
    public float speed;
    public float jumpPower;
    private void Awake(){
        GameManager.Instance.PlayerData = this;
    }
}
