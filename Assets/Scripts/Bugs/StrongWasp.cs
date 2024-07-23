using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongWasp : BasicBug
{
    public GameObject _shield;
    protected override void Start()
    {
        base.Start();
        _health = 2;
        _speed = 4;
    }
    protected override void Tapped()
    {
        base.Tapped();
        _health--;
        if (_health == 1)
        {
            Destroy(_shield);
        }
        else if (_health < 1)
        {
            gameManager.GetComponent<LevelManager>().IncStrongWaspKilled();
            Instantiate(head, transform.position, Quaternion.identity);
        }
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
