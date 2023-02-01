using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer_death_enemy_air : MonoBehaviour
{
    public GameObject heart;
    public Transform heart_position;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "slash")
        {
            Instantiate(heart, heart_position.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
