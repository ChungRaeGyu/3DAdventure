using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance{
        get{
            if(_instance==null){
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
            } 
            return _instance;
        }
    }
    private void Awake() {
        if(_instance==null){
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    public PlayerData _playerData;
    public PlayerData PlayerData{
        get{return _playerData;}
        set{_playerData = value;}
    }
}
