using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("Stats")]
    public float speed;
    public float jumpPower;

    [Header("Item")]
    public ItemData curItem;
    public Action addItem;

    public bool OnInventory=false;
    private void Awake(){
        GameManager.Instance.PlayerData = this;
    }
}
