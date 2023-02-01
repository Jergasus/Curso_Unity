using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer_death : MonoBehaviour
{
    private Animator anim;
    public GameObject heart;
    private float time;
    private bool death;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.7f;
        death = false;
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (time > 0f && death)
        {
            time -= Time.deltaTime;
            if (time <= 0f)
            {
                Instantiate(heart, transform.GetChild(4).gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "slash" && gameObject.tag == "Enemy")
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<Collider2D>().enabled = false;
            anim.SetBool("Hit_Received", true);
            death = true;
        }
            
    }
}
