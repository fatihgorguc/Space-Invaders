using System.Collections.Generic;
using UnityEngine;

namespace Background
{
    public class ParallaxEffectMenu : MonoBehaviour
    {
        [SerializeField] private List<GameObject> layers;
        [SerializeField] [Range(0,1)] private float parallaxMultiplierOffset = 0;

        private Vector2 _cursorPos;

        private void Start()
        {
            AddLayersToList();
        }
        
        void Update()
        {
            MoveLayers();
            SetCursorPos();
        }

        private void SetCursorPos()
        {
            _cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        private void AddLayersToList()
        {
            foreach (Transform bgLayer in transform)
                layers.Add(bgLayer.gameObject);
        }
        
        private void MoveLayers()
        {
            for (int i = 0; i < layers.Count; i++)
            {
                Vector2 pos = new Vector2
                (Mathf.Clamp(_cursorPos.x, -10, 10) * ((1 - parallaxMultiplierOffset) * i/layers.Count-1),
                    Mathf.Clamp(_cursorPos.y, -10, 10) * ((1 - parallaxMultiplierOffset) * i/layers.Count-1));
                layers[i].transform.position = pos;
            }
        }
    }
}
