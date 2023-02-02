using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public PlayerMovement Player;
    public timer_death_ninja vida;
    public float curr_hp;
    public float max_hp;
    public int hearts;
    public bool vidaExisted = false;

    private void Awake()
    {
        if (Instance != null) Destroy(this);
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BeforeLoad()
    {
        curr_hp = vida.vida;
        max_hp = vida.max_hp;
        hearts = vida.hp.coleccionable.heart;
        vidaExisted = true;
    }
}
