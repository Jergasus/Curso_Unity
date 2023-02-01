using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement_Air : MonoBehaviour
{
    public float deltaToTarget;
    public Transform target;
    private Rigidbody2D rb;
    public GameObject reference;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameManager.Instance.Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = target.position - reference.transform.position;
        dir.Normalize();
        reference.transform.up = dir;
        this.gameObject.transform.rotation = reference.transform.rotation;
    }

    public void FixedUpdate()
    {
        rb.position = Vector2.MoveTowards(rb.position, target.position, deltaToTarget);
    }

}
