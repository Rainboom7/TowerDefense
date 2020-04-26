using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using System.Collections.Concurrent;
using UnityEngine;

    public class PoisonTower : Tower
    {

        private float _passedtime;
        private ConcurrentBag<Monster> _monstersInRange = new ConcurrentBag< Monster>();
   
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
             Monster monster= collision.gameObject.GetComponent<Monster>();
        while (_monstersInRange.TryTake(out monster)) { }
        }
        private  void Shoot()
        {
             Parallel.ForEach(_monstersInRange, (monster) => { monster.ChangeHealth(_damage); });

        }

        public override string GetName()
        {
            return "Poison tower";
        }
    }

