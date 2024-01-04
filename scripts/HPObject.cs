using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPObject : MonoBehaviour
{
    [SerializeField] float HP = 100;
    public void ChangeHP(float value)
    {
    HP -= value;
    Debug.Log(HP);
    if (HP <= 0)
    {
    Destroy(gameObject);
    }
}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
