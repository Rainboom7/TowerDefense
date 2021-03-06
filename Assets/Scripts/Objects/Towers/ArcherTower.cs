﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class ArcherTower : Tower
    {
        private bool _monsterLeft = false;
        private Monster _monsterInRange;
        [SerializeField]
        private BulletBehavoiur _bullet;
        private void OnEnable()
    {
        if (_bullet != null)
        {
            _bullet.Damage = _damage;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
        {
            _monsterLeft = false;
            if (collision.gameObject.GetComponent<Monster>()!=null && _monsterInRange == null)
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
                     if (_monsterLeft || _bullet == null)
                        yield break;
                    _bullet.Target = _monsterInRange;
                    Instantiate(_bullet, transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(_shotDelay);
                }
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Monster>() != null)
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

