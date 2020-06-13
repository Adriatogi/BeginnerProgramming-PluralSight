using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void enterState(PlayerController_FSM player)
    {
        player.SetExpression(player.idleSprite);
    }

    public override void OnCollisionEnter(PlayerController_FSM player)
    {
    }

    public override void Update(PlayerController_FSM player)
    {
        if (Input.GetButtonDown("Jump"))
        {
            player.Rigidbody.AddForce(Vector3.up * player.jumpForce);
            player.transitionToState(player.jumpingState);
        }
        else if (Input.GetButtonDown("Duck"))
        {
            player.transitionToState(player.duckingState);
        }
        else if (Input.GetButtonDown("SwapWeapom"))
        {
            bool usingWeapon01 = player.weapon01.gameObject.activeInHierarchy;

            player.weapon01.gameObject.SetActive(usingWeapon01 == false);
            player.weapon02.gameObject.SetActive(usingWeapon01);
        }
    }
}
