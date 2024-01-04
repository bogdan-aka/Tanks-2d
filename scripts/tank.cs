using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank : MonoBehaviour
{
    public bool WASD;
    [Header ("Танк:")]
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    [Header("Оружие:")]
    [SerializeField] float reloadTime;
    [SerializeField] Transform bulletPoint;
    [SerializeField] Bullet bullet;
    Rigidbody2D rb;
    float shotTime = Mathf.Infinity;
    bool canShot = false;
    void CanShot()
    {
        if (canShot)
        {
            return;
        }
        shotTime += Time.deltaTime;
        if (shotTime>reloadTime)
        {
            shotTime = 0;
            canShot = true;
        }
    }
    void Shot(KeyCode shot)
    {
        if (Input.GetKey(shot) && canShot) 
        {
            canShot = false;
            Bullet bul = Instantiate (bullet, bulletPoint.position, Quaternion.identity);
            bul.gameObject.transform.Rotate(transform.rotation.eulerAngles, Space.World);
            bul.SetDirection(bulletPoint.right);
        } 
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Move(KeyCode forward, KeyCode back, KeyCode left, KeyCode right)
    {
         float v = 0;
            if (Input. GetKey(forward) || Input.GetKey(back))
            {
                if(Input.GetKey(forward))
                {
                    v=1f;
                }
                else
                {
                    v=-1f;
                }
                rb.AddForce(transform.right * speed * v, ForceMode2D.Impulse);
            }
            float h = 0;
            if (Input.GetKey(left) || Input.GetKey(right))
            {
                if(Input.GetKey(left))
                {
                    h=1f;
                }
                else
                {
                    h=-1f;
                }
                rb.AddTorque(rotationSpeed * h, ForceMode2D.Impulse);
            }
    }
    void Update()
    {
        if (WASD)
        {
            CanShot();
            Shot(KeyCode.E);
            Move(KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D);
        }
        else{
            CanShot();
            Shot(KeyCode.RightShift);
           Move(KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow);
        }
    }
}
