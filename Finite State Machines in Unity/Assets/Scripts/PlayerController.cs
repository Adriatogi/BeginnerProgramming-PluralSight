using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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

    private bool isJumping = false;
    private bool isDucking = false;
    private float rotation;
    private bool isSpinning;

    #endregion

    private void Awake()
    {
        face = GetComponentInChildren<SpriteRenderer>();
        rbody = GetComponent<Rigidbody>();
        SetExpression(idleSprite);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isJumping == false && isDucking == false)
            {
                isJumping = true;
                SetExpression(jumpingSprite);
                rbody.AddForce(Vector3.up * jumpForce);
            }
        }
        else if (Input.GetButtonDown("Duck"))
        {
            if (isJumping == false)
            {
                isDucking = true;
                head.localPosition = new Vector3(head.localPosition.x, 0.5f, head.localPosition.z);
                SetExpression(duckingSprite);
            }
            else
            {
                isSpinning = true;
            }

        }
        else if (Input.GetButtonUp("Duck") && isJumping == false)
        {
            isDucking = false;
            head.localPosition = new Vector3(head.localPosition.x, 0.8f, head.localPosition.z);
            SetExpression(idleSprite);
        }
        else if (Input.GetButtonDown("SwapWeapon"))
        {
            if(isJumping == false && isDucking == false && isSpinning == false)
            {
                bool usingWeopon01 = weapon01.gameObject.activeInHierarchy;

                weapon01.gameObject.SetActive(usingWeopon01 == false);
                weapon02.gameObject.SetActive(usingWeopon01);
            }
        }

        if (isSpinning == true)
        {
            spin();
            SetExpression(spinningSprite);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
        SetExpression(idleSprite);
    }

    private void spin()
    {
        float amountToRotate = 900 * Time.deltaTime;
        rotation += amountToRotate;

        if (rotation < 360)
        {
            transform.Rotate(Vector3.up, amountToRotate);
        }
        else
        {
            transform.rotation = Quaternion.identity;
            isSpinning = false;
            rotation = 0;
            SetExpression(jumpingSprite);
        }
    }

    public void SetExpression(Sprite newExpression)
    {
        face.sprite = newExpression;
    }
}
