using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadyBug : BasicBug
{
    protected override void Start()
    {
        base.Start();
        _health = 1;
        _speed = 5;
    }
    protected override void Tapped()
    {
        gameManager.GetComponent<LevelManager>().IncLadyBugKilled();
        _health--;
    }
    protected override void Update()
    {
        if (!atBottom)
        {
            Move();
        }
        base.Update();
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
