using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : Tower
{
    protected bool _monsterLeft = false;
    private  Monster _monsterInRange ;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _monsterLeft = false;
        if (collision.gameObject.tag.Equals("Enemy") && _monsterInRange==null )
        {
            _monsterInRange = collision.gameObject.GetComponent<Monster>();
            StartCoroutine(ShootRoutine);

        }
    }

    public IEnumerator ShootRoutine
    {
        get
        {
            while (true)
            {
                if (_monsterLeft)
                    yield break;
                _bullet.Damage = _damage;
                _bullet.Target = _monsterInRange;
                Instantiate(_bullet, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(_shotDelay);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            _monsterLeft = true;
            _monsterInRange = null;
        }
    }

    public override string GetName()
    {
        return "Archer tower";
    }
}
