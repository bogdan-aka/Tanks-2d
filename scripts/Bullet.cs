using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float damage;
    Rigidbody2D rb;
    Animator anim;
    public void SetDirection(Vector3 direction)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.velocity = direction.normalized*speed;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        anim = gameObject.GetComponentInChildren<Animator>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.StartsWith("Brick") || collision.name.StartsWith("Tank") || collision.name.StartsWith("penguin"))
        {
            HPObject HP = collision.GetComponent<HPObject>();
            if (HP != null)
        {
        HP.ChangeHP(damage);
        }
        anim.SetTrigger("explosion");
        float shotTime = Mathf.Infinity;
        rb.velocity = new Vector3(0, 0, 0);
        shotTime += Time.deltaTime;
        //if (shotTime>2f)
        //{
            Destroy(gameObject, 1f);
        //}
        
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
