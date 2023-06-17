using UnityEngine;

namespace Essentials
{
    public class Singleton : MonoBehaviour
    {
        #region Singleton
        
        public static Singleton Instance;
        
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
        
            Instance = this;
        }
        
        #endregion
    }
}
