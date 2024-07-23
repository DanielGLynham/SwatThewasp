using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastWasp : BasicBug
{
    int rand;
    float time;
    protected override void Start()
    {
        base.Start();
        _health = 1;
        _speed = 4;
        time = 0;
        if(transform.position.x == 0)
        {
            rand = Random.Range(0, 8); // maybe if pos.x == 0 do this, then an if on left, do different movement
        }
        else if(transform.position.x == -4)
        {
            rand = 8;
        }
        else if(transform.position.x == 4)
        {
            rand = 9;
        }
    }
    protected override void Tapped()
    {
        base.Tapped();
        gameManager.GetComponent<LevelManager>().IncFastWaspKilled();
        _health--;
    }
    protected override void Update()
    {
        time += Time.deltaTime;
        if (!atBottom)
        {
            Move();
        }
        base.Update();
    }
    protected override void Move()
    {
        switch(rand)
        {
            case 0:
                _rb.velocity = new Vector3(-Mathf.Cos(time) * 4.5f, (Mathf.Sin(time) * 4.5f) - (_speed / 2), 0); //y values cool effect:  2 and 2, 1 and 2, 2 and 3
                break;
            case 1:
                _rb.velocity = new Vector3(-Mathf.Cos(time) * 4.5f, (Mathf.Sin(time) * 2) - (_speed / 2), 0); //y values cool effect:  2 and 2, 1 and 2, 2 and 3
                break;
            case 2:
                _rb.velocity = new Vector3(-Mathf.Cos(time) * 4.5f, (Mathf.Sin(time) * 1) - (_speed / 2), 0); //y values cool effect:  2 and 2, 1 and 2, 2 and 3
                break;
            case 3:
                _rb.velocity = new Vector3(-Mathf.Cos(time) * 4.5f, (Mathf.Sin(time) * 2) - (_speed / 3), 0); //y values cool effect:  2 and 2, 1 and 2, 2 and 3
                break;
            case 4:
                _rb.velocity = new Vector3(Mathf.Cos(time) * 4.5f, (Mathf.Sin(time) * 4.5f) - (_speed / 2), 0); //y values cool effect:  2 and 2, 1 and 2, 2 and 3
                break;
            case 5:
                _rb.velocity = new Vector3(Mathf.Cos(time) * 4.5f, (Mathf.Sin(time) * 2) - (_speed / 2), 0); //y values cool effect:  2 and 2, 1 and 2, 2 and 3
                break;
            case 6:
                _rb.velocity = new Vector3(Mathf.Cos(time) * 4.5f, (Mathf.Sin(time) * 1) - (_speed / 2), 0); //y values cool effect:  2 and 2, 1 and 2, 2 and 3
                break;
            case 7:
                _rb.velocity = new Vector3(Mathf.Cos(time) * 4.5f, (Mathf.Sin(time) * 2) - (_speed / 3), 0); //y values cool effect:  2 and 2, 1 and 2, 2 and 3
                break;
            case 8: // pos.x == -4
                _rb.velocity = new Vector3(Mathf.Sin(time * 2) * 8, -3, 0); //y values cool effect:  2 and 2, 1 and 2, 2 and 3
                break;
            case 9: // pos.x == 4
                _rb.velocity = new Vector3(-Mathf.Sin(time * 2) * 8, -3, 0); //y values cool effect:  2 and 2, 1 and 2, 2 and 3
                break;
        }
    }
    private void OnMouseDown()
    {
        Tapped();
    }
}
