using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Scriptable_Objects;
using UnityEngine;

public class DebugCardGallary : MonoBehaviour
{
    [SerializeField] private Vector2 _cardSpaceOffset;
    [SerializeField] private Vector2 _cardSpaceSize;
    [SerializeField] private int _widthCount;
    [SerializeField] private int _heightCount;
    
    // Start is called before the first frame update
    void Start()
    {
        SetCardVisual();
        SetCardPosition();
    }

    private void OnValidate()
    {
        SetCardPosition();
        
    }

    private void SetCardVisual()
    {
        var cards = GetComponentsInChildren<StylizedHandCard>();
        cards = cards.OrderBy(card => card.gameObject.name).ToArray();

        var cardDescriptions = GameResourceManager.Instance.GetAllCardDescriptions();
        
        Debug.Log(cardDescriptions.Length + " cardDescriptions.Length == " + cards.Length + " cards.Length");
        
        for (var index = 0; index < cards.Length; index++)
        {
            var card = cards[index];
            card.Initialize(null, cardDescriptions[index], 0, 0, true);
        }
    }


    private void SetCardPosition()
    {
        var cards = GetComponentsInChildren<HandCard>();
        

        int currentWidth = 0;
        
        int currentHeight = 0;
        
        foreach (var card in cards)
        {
            
            card.transform.localPosition = new Vector3(
                _cardSpaceOffset.x + _cardSpaceSize.x * currentWidth,
                _cardSpaceOffset.y + _cardSpaceSize.y * currentHeight,
                0f);
            
            currentWidth++;
            
            if (currentWidth >= _widthCount)
            {
                currentWidth = 0;
                currentHeight++;
            }
            
        }
        
    }
}
