using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : PlayerBaseState
{
    public override void enterState(PlayerController_FSM player)
    {
        player.SetExpression(player.jumpingSprite);

    }

    public override void OnCollisionEnter(PlayerController_FSM player)
    {
        player.transitionToState(player.idleState);
    }

    public override void Update(PlayerController_FSM player)
    {
        if (Input.GetButtonDown("Duck"))
        {
            player.transitionToState(new PlayerSpinningState());
        }
    }
}
