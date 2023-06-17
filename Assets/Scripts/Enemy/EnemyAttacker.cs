using System;
using System.Collections;
using Common;
using MoreMountains.Feedbacks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyAttacker : MonoBehaviour
    {
        [SerializeField] private float attackDelayMin = 2;
        [SerializeField] private float attackDelayMax = 3;
        [SerializeField] private float attackDamage = 5;
        [SerializeField] private float bulletSpeed = 10;
        [SerializeField] private Transform spawnLocation;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private MMFeedbacks attackFb;

        private void Start()
        {
            StartCoroutine(Attack());
        }

        private IEnumerator Attack()
        {
            while (true)
            {
                var clone = Instantiate(bulletPrefab, spawnLocation.position, Quaternion.identity);
                clone.GetComponent<DamageDealer>().damageAmount *= attackDamage;
                clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-bulletSpeed * 10));
                Destroy(clone,3f);
                attackFb.PlayFeedbacks();
                yield return new WaitForSeconds(Random.Range(attackDelayMin, attackDelayMax));
            }
        }
    }
}
