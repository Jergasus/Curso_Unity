using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer_death : MonoBehaviour
{
    private Animator anim;
    public GameObject heart;
    public float life;
    private float time;
    public Transform heart_position;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        time = 0.7f;
    }
    // Update is called once per frame
    void Update()
    {
        if (time > 0f && life <= 0)
        {
            time -= Time.deltaTime;
            if (time <= 0f)
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                GetComponent<Collider2D>().enabled = false;
                Instantiate(heart, heart_position.position, Quaternion.identity);
                Instantiate(heart, heart_position.position, Quaternion.identity);
                Instantiate(heart, heart_position.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    public void GetDamage(float damage)
    {
        life -= damage;
        if (life <= 0) anim.SetBool("Hit_Received", true);
    }
}
