using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float HP { get; private set; }
    public float Speed { get; private set; }
    public event Action<GameObject> destroyUnit;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DestroyUnit()
    {
        
    }

    public void DamageUnit(float value)
    {
        HP -= value;
        if (HP <= 0)
        {
            destroyUnit.Invoke(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
