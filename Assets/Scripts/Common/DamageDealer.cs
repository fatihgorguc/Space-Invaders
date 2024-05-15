using MoreMountains.Feedbacks;
using UnityEngine;

namespace Common
{
    public class DamageDealer : MonoBehaviour
    {
        public float damageAmount;
        public bool pierce = false;

        [SerializeField] private MMFeedbacks hitFb;
        [SerializeField] private MMFeedbacks destroyFb;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent<Health>(out var health)) health.ChangeHealth(-damageAmount);
            hitFb.PlayFeedbacks();
            if (!pierce) destroyFb.PlayFeedbacks();
        }
    }
}
