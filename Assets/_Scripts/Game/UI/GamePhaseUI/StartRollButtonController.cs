using System;
using UnityEngine;
using UnityEngine.Rendering;


public class StartRollButtonController : PhaseManipulateButtonController
{
    protected override void ButtonSetUp()
    {
        Button.onClick.AddListener(TriggerEndPhase);
    }

    public override void TriggerEndPhase()
    {
        GameManager.Instance.ClientOwnerPlayerController.PlayerTurnController.StartRollPhaseServerRPC();
    }
}
