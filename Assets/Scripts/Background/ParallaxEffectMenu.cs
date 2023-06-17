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
                layers[i].transform.position = new Vector3
                    (_cursorPos.x * ((1 - parallaxMultiplierOffset) * i/layers.Count-1),
                        _cursorPos.y * ((1 - parallaxMultiplierOffset) * i/layers.Count-1));
            }
        }
    }
}
