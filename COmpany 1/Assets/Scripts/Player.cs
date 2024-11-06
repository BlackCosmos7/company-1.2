using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private float input;

    private Animator anim;
    private Rigidbody2D rb;
    public  boolturning = true;

    [Header("Оружие")]
    public Transform attackPos;
    public LayerMask enemy;
    public float radius;
    public int damage;

    //перезарядка
    private float recharge;
    public float startRecharge;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        input = input.GetAxis("Horizontal");
        rb.velocity = new Vector2(input * speed, rb.velocity.y);

        if (recharge <= 0)
        {
            if (input.GetMouseButton(0))
            {
                anim.SetBool("Attack", true);
            }
            recharge = startRecharge;
        }
        else
        {
            recharge -= Time.deltaTime;
        }

        if (turning == false && input > 0)
        {
            Flip();
        }
        else if (turning == true && input < 0)
        {
            Flip();
        }
        if (input == 0)
        {
            anim.SetBool("Run", false);
        }
        else
        {
            anim.SetBool("Run", true);
        }
    }
}
