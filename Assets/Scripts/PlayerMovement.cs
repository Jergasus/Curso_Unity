using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private bool tecnica;
    private bool dash;
    private float cooldown = 0f;
    public bool paused;
    public GameObject menu;
    public GameObject interfaz;
    private bool onGround = true;
    private bool run = false;
    public float speed_x;
    public float speed_y;
    private float new_speed_x;
    public Rigidbody2D rb;
    private Animator anim;


    private void Awake()
    {
        paused = false;
        menu.SetActive(false);
        interfaz.SetActive(true);
    }

    private void Start() {
        GameManager.Instance.Player = this;
        anim = GetComponent<Animator>();
        anim.SetFloat("Horizontal", 1f);
        new_speed_x = speed_x + 10;
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0f)
        {
            if (cooldown >= 0.5f) rb.velocity = new Vector2(horizontal * new_speed_x, rb.velocity.y);
            else 
            {
                anim.SetBool("UsingDash", false);   
            }
            cooldown -= Time.deltaTime;
            if (cooldown < 0f) cooldown = 0f;
        }


    }

    private void FixedUpdate() {
        if (cooldown < 0.5f) 
        {
            rb.velocity = new Vector2(horizontal * speed_x, rb.velocity.y);
            Jump();
            Run();
        }
        if (horizontal != 0) anim.SetFloat("Horizontal", horizontal);
        anim.SetBool("Running", run);
        anim.SetBool("UsingTecnica", tecnica);

        if (tecnica) transform.GetChild(4).gameObject.GetComponent<ParticleSystem>().Play();

        if (Time.timeScale == 1) paused = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            onGround = false;
        }
    }

    private void Jump() {
        if (onGround && vertical != 0) {
            rb.velocity += Vector2.up * speed_y * vertical;
        }
    }

    private void Run() {
        if (onGround && horizontal != 0) {
            run = true;
        }
        else run = false;
    }

    public void Horizontal(InputAction.CallbackContext ctx) {
        horizontal = ctx.ReadValue<float>();
    }

    public void Vertical(InputAction.CallbackContext ctx) {
        vertical = ctx.ReadValue<float>();
    }
    public void Tecnica(InputAction.CallbackContext ctx) 
    {
        tecnica = ctx.ReadValue<float>() == 1f;
    }

    public void Dash(InputAction.CallbackContext ctx) 
    {
        if (cooldown == 0f)
        {
            dash = ctx.ReadValue<float>() == 1f;
            anim.SetBool("UsingDash", dash);
            if (dash) cooldown = 1f;

        }
    }

    public void Pausa()
    {
        paused = !paused;
        if (paused)
        {
            menu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            menu.SetActive(false);
            Time.timeScale = 1;
        } 
    }

    public void OnPause(InputAction.CallbackContext ctx)
    {
        if (ctx.performed) Pausa();
    }
        
}
