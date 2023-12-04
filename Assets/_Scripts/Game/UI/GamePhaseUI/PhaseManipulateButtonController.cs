
using System;
using _Scripts.UI.GameUI;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class PhaseManipulateButtonController : PlayerControllerCompositionDependency
{
    protected Button Button;
    
    protected PhaseManipulateButtonContent PhaseManipulateButtonContent;
    protected PhaseTimer PhaseTimer;
    
    protected void Awake()
    {
        Button = GetComponent<Button>();
        
        GameManager.Instance.OnGameStart += ButtonSetUp;
        //Invoke(nameof(DelaySetUp), 0.5f);
    }

    protected void Start()
    {
        DelaySetUp();
    }

    public void SetContent(PhaseManipulateButtonContent phaseManipulateButtonContent, PhaseTimer phaseTimer)
    {
        PhaseManipulateButtonContent = phaseManipulateButtonContent;
        PhaseTimer = phaseTimer;
    }
    
    private void DelaySetUp()
    {
        GameManager.Instance.OnGameStart += ButtonSetUp;
    }

    protected virtual void ButtonSetUp()
    {
        
    }

    public virtual void TriggerEndPhase()
    {
        
    }
}
