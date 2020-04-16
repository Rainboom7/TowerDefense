using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PoisonTower : Tower
    {

        private float _passedtime;
        private List<Monster> _monstersInRange = new List<Monster>();
        private void Start()
        {
            _passedtime = _shotDelay;
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
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals("Enemy"))
            {
                _monstersInRange.Add(collision.gameObject.GetComponent<Monster>());
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            _monstersInRange.Remove(collision.gameObject.GetComponent<Monster>());
        }
        private void Shoot()
        {

            foreach (Monster monster in _monstersInRange)
            {
                monster.ChangeHealth(_damage);
            }
        }

        public override string GetName()
        {
            return "Poison tower";
        }
    }

