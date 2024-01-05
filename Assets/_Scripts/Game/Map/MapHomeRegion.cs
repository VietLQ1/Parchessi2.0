using System;
using UnityEngine;

namespace _Scripts.Map
{
    public class MapHomeRegion : MonoBehaviour
    {
        
        public void Spin(float spinDegree)
        {
            transform.Rotate(0.0f, 0.0f, spinDegree);
        }
    }
}