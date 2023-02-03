using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DarkHeart : MonoBehaviour
{
    public GameObject Enemy, darkheartprefab;
    public Transform position;
    private bool spaw;

    private void Awake()
    {
        spaw = true;
    }

    private void FixedUpdate()
    {
        if (Enemy == null)
        {
            if (spaw)
            {
                Instantiate(darkheartprefab, position.position, Quaternion.identity);
                spaw = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
