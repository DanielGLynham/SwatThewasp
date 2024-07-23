using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBug : MonoBehaviour
{
    protected int _health;
    protected float _speed;
    public bool atBottom;

    protected Rigidbody _rb;
    public GameObject head;
    private Collider OurCollider;
    protected GameObject gameManager;

    private bool increasedSpeed;

    protected virtual void Start()
    {
        increasedSpeed = false;
        gameManager = GameObject.Find("GameManager");
        OurCollider = GetComponent<Collider>();
        _rb = GetComponent<Rigidbody>();
        atBottom = false;
    }
    protected virtual void Update()
    {
        if(_health <= 0)
        {
            Instantiate(head, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if(transform.position.y < -9.5f)
        {
            atBottom = true;
            _rb.velocity = Vector3.zero;
            StartCoroutine(GetAway());
        }
    }
    private void FixedUpdate()
    {
        if(transform.position.x > 7 || transform.position.x < -7)
        {
            Destroy(this.gameObject);
            gameManager.GetComponent<LevelManager>().toEndLevelCounter++;
        }
        if(gameManager.GetComponent<LevelManager>().GetWaveNum() >= 10 && gameManager.GetComponent<LevelManager>().GetWaveNum() < 15)
        {
            if(!increasedSpeed)
            {
            increasedSpeed = true;
            _speed *= 1.25f;
            }
        }
        else if(gameManager.GetComponent<LevelManager>().GetWaveNum() == 15 && gameManager.GetComponent<LevelManager>().GetWaveNum() < 20)
        {
            if (!increasedSpeed)
            {
                increasedSpeed = true;
                _speed *= 1.25f;
            }
        }
        else if (gameManager.GetComponent<LevelManager>().GetWaveNum() == 20)
        {
            if (!increasedSpeed)
            {
                increasedSpeed = true;
                _speed *= 1.25f;
            }
        }
        else
        {
            increasedSpeed = false;
        }

    }
    protected virtual void Move()
    {

    }
    protected virtual void Tapped()
    {
    }
    protected int GetHealth()
    {
        return _health;
    }
    protected float GetSpeed()
    {
        return _speed;
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Wasp" || other.gameObject.tag == "LadyBug")
        {
            Physics.IgnoreCollision(other.collider, OurCollider);
        }
    }
    IEnumerator GetAway()
    {
        yield return new WaitForSeconds(1);
        if(transform.position.x >= 0)
        {
            _rb.velocity = new Vector3(1, 0, 0);
        }
        else
        {
            _rb.velocity = new Vector3(-1, 0, 0);
        }
    }
}
