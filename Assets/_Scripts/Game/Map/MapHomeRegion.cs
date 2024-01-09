using System;
using UnityEngine;

namespace _Scripts.Map
{
    public class MapHomeRegion : MonoBehaviour
    {
        [SerializeField] private Transform [] _pawnSpawnPoints;
        private int _pawnSpawnPointIndex = 0;
        
        public void Spin(float spinDegree)
        {
            transform.Rotate(0.0f, 0.0f, spinDegree);
        }
        
        public void SpawnPawn(Transform pawnTransform)
        {
            pawnTransform.position = _pawnSpawnPoints[0].position;
            pawnTransform.rotation = _pawnSpawnPoints[0].rotation;
        }

        public Transform GetSpawnPoint()
        {
            _pawnSpawnPointIndex = (_pawnSpawnPointIndex + 1) % _pawnSpawnPoints.Length;
            return _pawnSpawnPoints[_pawnSpawnPointIndex];
        }
        
        
        
    }
}