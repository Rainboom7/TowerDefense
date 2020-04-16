using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavoiur : MonoBehaviour
{
    public float Speed;
    [HideInInspector]
    public int Damage;
    [HideInInspector]
    public Monster Target;
    private void FixedUpdate()
    {
        if (Target != null)
        {
            Vector3 destination = Target.transform.position;
            Vector3 direction = (destination - transform.position).normalized;
            if (Vector3.Distance(transform.position, destination) >= 0.2)
            {
                gameObject.transform.position += direction * Speed * Time.deltaTime;

            }
            else
            {
                Target.ChangeHealth(Damage);
                Destroy(gameObject);
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }

    


}
