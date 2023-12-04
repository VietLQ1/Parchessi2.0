using System;

namespace _Scripts.UI.GameUI
{
    public class EndRollButtonController : PhaseManipulateButtonController
    {
        
        protected override void ButtonSetUp()
        {
            Button.onClick.AddListener(TriggerEndPhase);
        }

        public override void TriggerEndPhase()
        {
            GameManager.Instance.ClientOwnerPlayerController.PlayerTurnController.EndRollPhaseServerRPC();
        }
    }
}