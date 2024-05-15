using System;
using System.Collections;
using Common;
using Enums;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace Player
{
    public class PlayerAttacker : MonoBehaviour
    {
        [SerializeField] private float attackSpeed = 2;
        [SerializeField] private float attackDamage = 5;
        [SerializeField] private float bulletSpeed = 10;
        [SerializeField] private bool bulletPierce = false;
        [SerializeField] private Transform spawnLocation;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private MMFeedbacks attackFb;
        private Animator _anim;
        private static readonly int İsAttacking = Animator.StringToHash("isAttacking");

        private Coroutine _attackRoutine;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
        }

        private void Start()
        {
            _attackRoutine = StartCoroutine(InstantiateBullet());
        }

        private IEnumerator InstantiateBullet()
        {
            while (true)
            {
                while (Input.GetButton("Fire1"))
                {
                    var clone = Instantiate(bulletPrefab, spawnLocation.position, Quaternion.identity);
                    clone.GetComponent<DamageDealer>().damageAmount *= attackDamage;
                    clone.GetComponent<DamageDealer>().pierce = bulletPierce;
                    clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,bulletSpeed * 10));
                    Destroy(clone,3f);
                    attackFb.PlayFeedbacks();
                    _anim.SetBool(İsAttacking, true);
                    yield return new WaitForSeconds(1/attackSpeed);
                }
                _anim.SetBool(İsAttacking, false);
                
                yield return new WaitForSeconds(0.01f);
            }
        }

        public void ChangeStats(PowerUpType buffType, int amount, float t)
        {
            switch (buffType)
            {
                case PowerUpType.AttackSpeed:
                    attackSpeed += amount;
                    StartCoroutine(ResetSpeedBuff(amount, t));
                    break;
                case PowerUpType.AttackDamage:
                    attackDamage += amount;
                    StartCoroutine(ResetDamageBuff(amount, t));
                    break;
                case PowerUpType.Pierce:
                    if (amount == 0) return;
                    if (!bulletPierce) bulletPierce = true;
                    else StopCoroutine(ResetPierceBuff(t));
                    StartCoroutine(ResetPierceBuff(t));
                    break;
            }
        }

        IEnumerator ResetSpeedBuff(int amount, float t)
        {
            yield return new WaitForSeconds(t);
            attackSpeed -= amount;
        }
        IEnumerator ResetDamageBuff(int amount, float t)
        {
            yield return new WaitForSeconds(t);
            attackDamage -= amount;
        }

        IEnumerator ResetPierceBuff(float t)
        {
            yield return new WaitForSeconds(t);
            bulletPierce = false;
        }
        
        public void StopAttacking()
        {
            StopCoroutine(_attackRoutine);
        }
    }
}
