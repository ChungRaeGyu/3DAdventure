using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType{
    Equipable,
    Consumable,
    Resource
}
public enum ConsumableType{
    Health,
    Stamina,
    Speed
}
[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("기본정보")]
    public string name;
    public string description;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefab;

    [Header("Consum")]
    public float value;

    public bool isEquip=false;

}
