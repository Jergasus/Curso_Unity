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
    public float vida = 5;
    private float time;
    public PlayerLife hp;
    public Rigidbody2D rb;

    private void Awake()
    {
        if (GameManager.Instance.vidaExisted)
        {
            this.vida = GameManager.Instance.curr_hp;
            this.max_hp = GameManager.Instance.max_hp;
            this.hp.coleccionable.heart = GameManager.Instance.hearts;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        max_hp = 5;
        vida = max_hp;
        time = 1.05f;
    }
    // Update is called once per frame
    void Update()
    {
        barra.ActualizaVida(vida, max_hp);
        heart.ActualizaVida(hp.coleccionable.heart, 3);
        if (time > 0 && vida <= 0)
        {
            time -= Time.deltaTime;
            if (time <= 0) SceneManager.LoadScene(5);
        }
    }

    public void FixedUpdate()
    {
        if (vida <= 0)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<Collider2D>().enabled = false;
            anim.SetBool("Death", true);
            Destroy(gameObject, time);
        }
        if (hp.coleccionable.heart == 3)
        {
            ++vida;
            hp.coleccionable.heart = 0;
        }
        if (rb.position.y < -15) vida = 0;
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "slash_enemy")
        {
            --vida;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "slash_missile")
        {
            vida -= 2;
        }
        if (collision.gameObject.tag == "limit")
        {
            vida = 0;
        }
    }
}
