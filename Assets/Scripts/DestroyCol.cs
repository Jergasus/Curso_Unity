using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCol : MonoBehaviour
{
    public GameObject particle;
    public GameObject audio_clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(audio_clip, gameObject.transform.position, Quaternion.identity);
            Instantiate(particle, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
