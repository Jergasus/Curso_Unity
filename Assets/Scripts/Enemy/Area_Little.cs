using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_Little : MonoBehaviour
{

    public bool inside_little;
    // Start is called before the first frame update
    void Start()
    {
        inside_little = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") inside_little = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") inside_little = false;
    }
    

}
