using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 5f;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            _rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * (100 * moveSpeed * Time.deltaTime);
        }

        public void ChangeMoveSpeed(int amount, float t)
        {
            moveSpeed += amount;
            StartCoroutine(ResetBuff(amount, t));
        }

        IEnumerator ResetBuff(int amount, float t)
        {
            yield return new WaitForSeconds(t);
            moveSpeed -= amount;
        }
    }
}
