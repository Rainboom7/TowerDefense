using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardTower : Tower
{
    private float _passedtime;
    public GameObject light;
    [SerializeField]
    private Animator _animator;

    public override string GetName()
    {
        return "Wizard Tower";
    }
    private void Start()
    { 
        _passedtime = _shotDelay;
        _animator.SetBool(0, false);
    }

    private void FixedUpdate()
    {
        if (_passedtime <= 0.0f)
        {
            Shoot();
            _passedtime = _shotDelay;
        }
        _passedtime -= Time.deltaTime;

    }
    private void Shoot()
    {
        _animator.SetTrigger("Fire");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag.Equals("Enemy"))
            {
                Monster monsterInRange = hit.collider.gameObject.GetComponent<Monster>();
                monsterInRange.ChangeHealth(_damage);
                Debug.Log(hit.collider.gameObject);

            }
        }
       
    }
}

