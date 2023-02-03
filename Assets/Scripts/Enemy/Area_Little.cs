using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_Little : MonoBehaviour
{

    public bool inside_little;
    private float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        inside_little = false;
        cooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0f)
        {
            if (cooldown <= 1f) inside_little = false;
            cooldown -= Time.deltaTime;
            if (cooldown <= 0f) cooldown = 0f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (cooldown == 0f)
        {
            if (collision.gameObject.tag == "Player")
            {
                inside_little = true;
                cooldown = 2f;
            }
        }
    }
}
