using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile_Spawner : MonoBehaviour
{
    public GameObject missile;
    private float time;
    public Transform missile_position;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0f)
        {
            time -= Time.deltaTime;
            if (time <= 0f) time = 0f;
        }
    }

    private void FixedUpdate()
    {
        if (time == 0)
        {
            Instantiate(missile, missile_position.position, Quaternion.identity);
            time = 2f;
        }
    }
}
