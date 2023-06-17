using System;
using Common;
using Enums;
using MoreMountains.Feedbacks;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Other
{
    public class Buff : MonoBehaviour
    {
        [SerializeField] private int dropSpeed;
        [SerializeField] private int randomHealthMax;
        [SerializeField] private int randomMoveSpeedMax;
        [SerializeField] private int randomAttackSpeedMax;
        [SerializeField] private int randomAttackDamageMax;
        [SerializeField] private float randomBuffTime;
        [SerializeField] private bool randomPierce;

        [SerializeField] private MMFeedbacks tookFb;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _rb.velocity = new Vector2(0, -dropSpeed);
            Destroy(gameObject, 5f);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            col.GetComponent<Health>().ChangeHealth(Random.Range(0, randomHealthMax));
            col.GetComponent<PlayerAttacker>().ChangeStats(PowerUpType.AttackSpeed, Random.Range(0, randomAttackSpeedMax), Random.Range(0, randomBuffTime));
            col.GetComponent<PlayerAttacker>().ChangeStats(PowerUpType.AttackDamage, Random.Range(0, randomAttackDamageMax), Random.Range(0, randomBuffTime));
            col.GetComponent<PlayerAttacker>().ChangeStats(PowerUpType.Pierce, Random.Range(0, 2 * Convert.ToInt32(randomPierce)), Random.Range(0, randomBuffTime));
            col.GetComponent<PlayerController>().ChangeMoveSpeed(Random.Range(0, randomMoveSpeedMax), Random.Range(0, randomBuffTime));
            tookFb.PlayFeedbacks();
        }
    }
}
