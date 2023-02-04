using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer_death_enemy_air : MonoBehaviour
{
    public GameObject heart;
    public Transform heart_position;
    public GameObject explosion;
    public GameObject audio_clip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "slash")
        {
            Instantiate(audio_clip, heart_position.position, Quaternion.identity);
            Instantiate(heart, heart_position.position, Quaternion.identity);
            Instantiate(explosion, heart_position.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(audio_clip, heart_position.position, Quaternion.identity);
            Instantiate(explosion, heart_position.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
