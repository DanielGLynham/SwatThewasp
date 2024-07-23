using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentipedeLegs : MonoBehaviour
{
    private Rigidbody _rb;

    private bool rotatingleft = false;
    private bool needRotBig = true;
    private int rot = -1;
    private bool bodyHurt = false;

    private void Start()
    {
        _rb = this.gameObject.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if(!bodyHurt)
        {
            if(rotatingleft)
            {
                _rb.transform.Rotate(new Vector3(0, 0, rot), 4f, 0);
            }
            else
            {
                _rb.transform.Rotate(new Vector3(0, 0, rot), 4f, 0);
            }
            if(_rb.transform.localRotation.z * Mathf.Rad2Deg >= 20 && !needRotBig)
            {
                needRotBig = true;
                rot *= -1;
            }
            else if( _rb.transform.localRotation.z * Mathf.Rad2Deg <= -20 && needRotBig)
            {
                needRotBig = false;
                rot *= -1;
            }
        }
        else
        {
            _rb.transform.Rotate(new Vector3(0, 0, 0), 0, 0);
            //_rb.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }
    public void SetBodyHurt(bool veryMuch)
    {
        bodyHurt = veryMuch;
    }
}
