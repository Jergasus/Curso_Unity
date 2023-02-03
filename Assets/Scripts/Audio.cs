using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio Instance;
    public static bool pause;

    private void Awake()
    {
        if (Instance != null) Destroy(this);
        Instance = this;
        DontDestroyOnLoad(gameObject);
        pause = false;
    }

    private void Update()
    {
        if (pause) Destroy(gameObject);
    }
}
