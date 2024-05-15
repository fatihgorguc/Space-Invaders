using System;
using System.Collections.Generic;
using UnityEngine;

namespace Background
{
    public class ParallaxEffect : MonoBehaviour
    {
        [SerializeField] [Range(0,1)] private float parallaxMultiplierOffset;
        [SerializeField] [Range(-1f,1f)]private float yMoveSpeed;
        private List<GameObject> _layers = new List<GameObject>();
        private Camera _cam;

        private void Awake()
        {
            _cam = FindObjectOfType<Camera>();
        }

        private void Start()
        {
            AddLayersToList();
        }
        
        void Update()
        {
            MoveLayers();
            CheckIfOut();
        }

        private void AddLayersToList()
        {
            foreach (Transform bgLayer in transform)
                _layers.Add(bgLayer.gameObject);
        }
        
        private void MoveLayers()
        {
            for (byte i = 0; i < _layers.Count; i++)
            {
                _layers[i].transform.position = Vector2.up * (_layers[i].transform.position.y +
                                                               yMoveSpeed / 10 * ((1 - parallaxMultiplierOffset) * i /
                                                                   _layers.Count - 1) * -1);
            }
        }

        private void CheckIfOut()
        {
            for (byte i = 0; i < _layers.Count; i++)
            {
                if (Vector2.Distance(_layers[i].transform.position, _cam.transform.position) >
                    _layers[i].GetComponent<SpriteRenderer>().sprite.bounds.size.y)
                {
                    _layers[i].transform.position = _cam.transform.position;
                }
            }
        }
    }
}
