using System;
using UnityEngine;

public class DebugInEditorOnlyGameObject : MonoBehaviour
{
    
    
    private void Awake()
    {
        #if UNITY_EDITOR
        gameObject.SetActive(true);
        #else
        gameObject.SetActive(false);
        #endif
    }
    
    
}
