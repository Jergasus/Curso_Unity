using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timer_death_ninja : MonoBehaviour
{
    private Animator anim;
    public Vida barra;
    public Vida_Coleccionable heart;
    public float max_hp;
    public float vida;
    private float time;
    public PlayerLife hp;
    public Rigidbody2D rb;

    private void Awake()
    {
        max_hp = 5;
        TotalLife.vida = max_hp;
    }

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
        heart.ActualizaVida(TotalLife.hp.coleccionable.heart, 3);
        if (time > 0 && TotalLife.vida <= 0)
        {
            time -= Time.deltaTime;
            if (time <= 0) SceneManager.LoadScene(6);
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
        if (TotalLife.hp.coleccionable.heart == 3)
        {
            ++TotalLife.vida;
            TotalLife.hp.coleccionable.heart = 0;
        }
        if (rb.position.y < -15) vida = 0;
        

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
