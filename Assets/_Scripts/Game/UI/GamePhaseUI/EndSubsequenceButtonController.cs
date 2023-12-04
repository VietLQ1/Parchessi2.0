using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSubsequenceButtonController : PhaseManipulateButtonController
{
    
    protected override void ButtonSetUp()
    {
        Button.onClick.AddListener(TriggerEndPhase);
    }

    public override void TriggerEndPhase()
    {
        GameManager.Instance.ClientOwnerPlayerController.PlayerTurnController.EndSubsequencePhaseServerRPC();
    }
}
