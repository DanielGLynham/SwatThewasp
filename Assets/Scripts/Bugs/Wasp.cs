using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasp : BasicBug
{
    protected override void Start()
    {
        base.Start();
        _health = 1;
        _speed = 5;
    }
    protected override void Tapped()
    {
        base.Tapped();
        gameManager.GetComponent<LevelManager>().IncWaspKilled();
        _health--;
    }
    protected override void Update()
    {
        base.Update();
        if(!atBottom)
        {
            Move();
        }
    }
    protected override void Move()
    {
        _rb.velocity = new Vector3(0, -_speed, 0);
    }
    private void OnMouseDown()
    {
        Tapped();
    }
}
