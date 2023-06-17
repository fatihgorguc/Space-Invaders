using UnityEngine;

namespace Essentials
{
    public class ChangeScore : MonoBehaviour
    {
        private void OnEnable()
        {
            FindObjectOfType<GameSession>().OnSceneChange();
        }
    }
}
