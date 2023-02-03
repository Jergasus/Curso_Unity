using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timer_death_ninja : MonoBehaviour
{
    private Animator anim;
    public Vida barra;
    public Vida_Coleccionable heart;
    public float max_hp = 5;
    private float time;
    public Rigidbody2D rb;
    public AudioClip full_hearts;
    public GameObject death;
    public new AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        time = 1.05f;
    }
    // Update is called once per frame
    void Update()
    {
        barra.ActualizaVida(TotalLife.vida, max_hp);
        heart.ActualizaVida(TotalLife.hearts, 3);
        if (time > 0 && TotalLife.vida <= 0)
        {
            if (time == 1.05f) Instantiate(death, gameObject.transform.position, Quaternion.identity);
            time -= Time.deltaTime;
            if (time <= 0) SceneManager.LoadScene(7);
        }
    }

    public void FixedUpdate()
    {
        if (TotalLife.vida <= 0)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<Collider2D>().enabled = false;
            anim.SetBool("Death", true);
            Destroy(gameObject, time);
        }
        if (TotalLife.hearts == 3)
        {
            audio.PlayOneShot(full_hearts);
            ++TotalLife.vida;
            TotalLife.hearts = 0;
        }
        if (rb.position.y < -15) TotalLife.vida = 0;
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "slash_enemy")
        {
            --TotalLife.vida;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "slash_missile")
        {
            TotalLife.vida -= 2;
        }
        if (collision.gameObject.tag == "limit")
        {
            TotalLife.vida = 0;
        }
    }
}
