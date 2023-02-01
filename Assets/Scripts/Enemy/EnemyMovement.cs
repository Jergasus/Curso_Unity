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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameManager.Instance.Player.transform;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        if (area.inside) rb.position = Vector2.MoveTowards(rb.position, target.position, deltaToTarget);
        anim.SetBool("Detection", area_hit.inside_little);

    }
}
