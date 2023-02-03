using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private float time;
    // Start is called before the first frame update

    private void Awake()
    {
        Audio.pause = true;
    }
    void Start()
    {
        time = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            if (time <= 0) SceneManager.LoadScene(0);
        }
    }
}
