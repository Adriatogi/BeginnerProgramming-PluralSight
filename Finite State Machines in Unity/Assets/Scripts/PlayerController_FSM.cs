using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_FSM : MonoBehaviour
{
    #region Player Variables

    public float jumpForce;
    public Transform head;
    public Transform weapon01;
    public Transform weapon02;

    public Sprite idleSprite;
    public Sprite duckingSprite;
    public Sprite jumpingSprite;
    public Sprite spinningSprite;

    private SpriteRenderer face;
    private Rigidbody rbody;

    #endregion

    private PlayerBaseState currentState;

    public readonly PlayerIdleState idleState = new PlayerIdleState();
    public readonly PlayerDuckingState duckingState = new PlayerDuckingState();
    public readonly PlayerJumpingState jumpingState = new PlayerJumpingState();

    public PlayerBaseState CurrentState
    {
        get { return currentState; }
    }

    public Rigidbody Rigidbody
    {
        get { return rbody; }
    }
    private void Awake()
    {
        face = GetComponentInChildren<SpriteRenderer>();
        rbody = GetComponent<Rigidbody>();
        SetExpression(idleSprite);
    }

    private void Start()
    {
        transitionToState(idleState);  
    }
    // Update is called once per frame
    void Update()
    {
        currentState.Update(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this);
    }

    public void transitionToState(PlayerBaseState state)
    {
        currentState = state;
        currentState.enterState(this);
    }
    public void SetExpression(Sprite newExpression)
    {
        face.sprite = newExpression;
    }
}
