using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentipedeBody : MonoBehaviour
{
    public Rigidbody _rb;

    private int attackSpeed = -8;
    private int moveSpeedX = -8, moveSpeedY = -8;
    public GameObject legs, body;
    private bool hitSide = true, hitTop = true;
    private bool bodyHurt = false, entireBodyBroke = false;
    private Vector3 headPosition;
    private bool brokenMoveOver = true;
    private float time;
    private bool isHeadPiece = false;

    private int topBorder = 13, bottomBorder = -8, leftBorder = -8, rightBorder = 8;

    void Start()
    {
        //legs = this.gameObject.transform.Find("CentipedeLegs").gameObject;
        //_rb = this.gameObject.GetComponent<Rigidbody>();
        //_rb.velocity = new Vector3(attackSpeedX, attackSpeedY, 0);
    }

    void Update()
    {
        time += Time.deltaTime;
        if(!entireBodyBroke)
        {
            Move();
        }
        else if(!brokenMoveOver)
        {
            BrokenMove();
        }
        else if(brokenMoveOver && entireBodyBroke)
        {
            AttackMove();
        }

    }
    private void OnMouseDown()
    {
        Tapped();
    }
    public void SetHeadPiece(bool yes)
    {
        isHeadPiece = yes;
    }
    private void Tapped()
    {
        legs.GetComponent<CentipedeLegs>().SetBodyHurt(true);
        bodyHurt = true;
    }
    public void SetEntireBodyBroke(bool broken, Vector3 headPos)
    {
        entireBodyBroke = broken;
        brokenMoveOver = false;
        headPosition = headPos;
    }
    public bool GetBodyHurt()
    {
        return bodyHurt;
    }
    public void SetMoveSpeed(int speed)
    {
        if(moveSpeedX < 0)
        {
            moveSpeedX = -speed;
        }
        else
        {
            moveSpeedX = speed;
        }
        if (moveSpeedY < 0)
        {
            moveSpeedY= -speed;
        }
        else
        {
            moveSpeedY = speed;
        }
    }
    private void AttackMove()
    {
        _rb.velocity = new Vector3(Mathf.Sin(time * 2) * 8, -3, 0);
    }
    private void BrokenMove()
    {
        if(!isHeadPiece)
        {
            Move();
            if (_rb.transform.position.x > headPosition.x - 0.1f && _rb.transform.position.x < headPosition.x + 0.1f && _rb.transform.position.y > headPosition.y - 0.1f && _rb.transform.position.y < headPosition.y + 0.1f)
            {
                Debug.Log("rb x " + _rb.transform.position.x);
                Debug.Log("head x " + headPosition.x);
                Debug.Log("rb y " + _rb.transform.position.y);
                Debug.Log("head y " + headPosition.y);
                transform.position = new Vector3(0, 11, 0);
                brokenMoveOver = true;
            }
        }
        else
        {
            transform.position = new Vector3(0, 11, 0);
            brokenMoveOver = true;
        }

    }
    private void Move()
    {
        if(_rb.transform.position.x <= leftBorder && hitSide)
        {
            moveSpeedX *= -1;
            hitSide = false;
        }
        if(_rb.transform.position.x >= rightBorder && !hitSide)
        {
            hitSide = true;
            moveSpeedX *= -1;
        }
        if(_rb.transform.position.y <= bottomBorder && hitTop)
        {
            hitTop = false;
            moveSpeedY *= -1;
        }
        if(_rb.transform.position.y >= topBorder && !hitTop)
        {
            hitTop = true;
            moveSpeedY *= -1;
        }
        _rb.velocity = new Vector3(moveSpeedX, moveSpeedY, 0);
        if(hitSide && hitTop)
        {
            // right and up 45
            body.GetComponent<Rigidbody>().transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 125));
        }
        if (!hitSide && !hitTop)
        {
            // left and down 225
            body.GetComponent<Rigidbody>().transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 315));
        }
        if (hitSide && !hitTop)
        {
            // right and down 135
            body.GetComponent<Rigidbody>().transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 45));
        }
        if (!hitSide && hitTop)
        {
            // left and up 315
            body.GetComponent<Rigidbody>().transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 225));
        }
    }
}
