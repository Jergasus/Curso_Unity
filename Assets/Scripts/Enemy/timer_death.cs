using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer_death : MonoBehaviour
{
    private Animator anim;
    public GameObject heart;
    public float life;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        time = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        if (time > 0f && life <= 0)
        {
            time -= Time.deltaTime;
            if (time <= 0f)
            {
                Instantiate(heart, transform.GetChild(4).gameObject.transform.position, Quaternion.identity);
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
