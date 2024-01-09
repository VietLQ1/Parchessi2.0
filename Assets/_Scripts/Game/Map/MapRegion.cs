using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Scripts.Map;

public class MapRegion : MonoBehaviour
{
    [SerializeField] private Transform _mapParent;
    [SerializeField] private List<MapPath> _mapPaths = new ();
    [SerializeField] private List<Transform> _mapHomeRegionTransforms = new ();

    [SerializeField] private MapHomeRegion _defaultMapHomeRegionPrefab;
    
    private class CharacterMap
    {
        public CharacterMap(ulong characterId, MapHomeRegion mapHomeRegion)
        {
            CharacterId = characterId;
            MapHomeRegion = mapHomeRegion;
        }

        public ulong CharacterId { get;}
        
        public MapHomeRegion MapHomeRegion { get;}
        
    }
    private readonly Dictionary<ulong, CharacterMap> _mapHomeRegions = new ();
    
    // Start is called before the first frame update

    public MapPath GetMapPath(int pathIndex)
    {
        if (pathIndex < _mapPaths.Count)
        {
            return _mapPaths[pathIndex];
        }
        else
        {
            Debug.LogError("MapPath index out of range");
        }
        return null;
    }
    
    public MapHomeRegion GetMapHomeRegion(ulong characterId)
    {
        if (_mapHomeRegions.TryGetValue(characterId, out var region))
        {
            return region.MapHomeRegion;
        }
        else
        {
            Debug.LogError("CharacterId not found");
        }
        return null;
    }
    
    
    public void CreateCharacterMap(ulong id, MapHomeRegion mapHomeRegionPrefab)
    {
        MapHomeRegion mapHomeRegion = Instantiate(mapHomeRegionPrefab, _mapHomeRegionTransforms[(int)id]);
        
        CharacterMap characterMap = new CharacterMap(id, mapHomeRegion);
        
        _mapHomeRegions[id] = characterMap;
        
    }

    public void CreateLeftoverDefaultCharacterMap()
    {
        for (ulong i = 0; i < (ulong)_mapHomeRegionTransforms.Count; i++)
        {
            if (_mapHomeRegions.ContainsKey(i))
            {
                continue;
            }
            
            
            MapHomeRegion mapHomeRegion = Instantiate(_defaultMapHomeRegionPrefab, _mapHomeRegionTransforms[(int)i]);
            _mapHomeRegions[i] = new CharacterMap(i, _defaultMapHomeRegionPrefab);
        }
        
    }
}
