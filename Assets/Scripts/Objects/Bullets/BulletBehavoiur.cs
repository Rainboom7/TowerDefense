using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavoiur : MonoBehaviour
{
    public float Speed;
    public int Damage;
    public Monster Target;
    private Coroutine _move;
    private void FixedUpdate()
    {
        if (Target != null)
        {
            Vector3 destination = Target.transform.position;
            Vector3 direction = (destination - transform.position).normalized;
            if (Vector3.Distance(transform.position, destination) > 0.1)
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
