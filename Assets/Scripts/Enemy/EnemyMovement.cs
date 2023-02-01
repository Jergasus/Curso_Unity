using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float deltaToTarget;
    public Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    public Area area;
    public Area_Little area_hit;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameManager.Instance.Player.transform;
        anim = GetComponent<Animator>();
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0f)
        {
            if (time <= 0.5f) anim.SetBool("Detection", false);
            time -= Time.deltaTime;
            if (time <= 0f) time = 0f;
        }
    }

    public void FixedUpdate()
    {
        if (area.inside) rb.position = Vector2.MoveTowards(rb.position, target.position, deltaToTarget);
        if (time == 0f)
        {
            anim.SetBool("Detection", area_hit.inside_little);
            time = 1f;
        }
        if (rb.position.x < target.position.x) anim.SetFloat("Direction", -1);
        else if (rb.position.x > target.position.x) anim.SetFloat("Direction", 1);

    }
}
