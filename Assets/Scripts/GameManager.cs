using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerMovement Player;

    private void Awake()
    {
        if (Instance != null) Destroy(this);
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
}
