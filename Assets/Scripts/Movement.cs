using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField]
    ShipHandler ship;
    public float StartSpeed;
    
    float speed;
    float addedspeed=0;
    public void Update()
    {
        
        speed = addedspeed + StartSpeed;

        MouseMovement();
    }

    public void IncreaseSpeed(float value)
    {
        addedspeed += Mathf.Abs(value);
        addedspeed = addedspeed > 100 ? 100 : addedspeed;
    }
    public void DecreaseSpeed(float value)
    {
        addedspeed -= ((addedspeed - Mathf.Abs(value) < 0 )? 0 : Mathf.Abs(value));
    }

    void ArrowsMovement()
    {
        
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);




        
        ship.Rb.velocity = Vector3.zero;
        var targetPos = transform.position + (move * speed * Time.deltaTime);
        targetPos.z = 0;
        var heading = targetPos - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance; // This is now the normalized direction.

        if (distance > 1)
        {
            ship.Rb.AddForce(direction * speed, ForceMode2D.Impulse);
        }
        else
        {
            ship.Rb.AddForce(direction * speed * (distance * distance), ForceMode2D.Impulse);
        }

        direction = Camera.main.MyScreenToWorldPosition(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }

    void MouseMovement()
    {
        ship.Rb.velocity = Vector3.zero;
        var targetPos = Camera.main.MyScreenToWorldPosition(Input.mousePosition);
        targetPos.z = 0;
        var heading = targetPos - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance; // This is now the normalized direction.

        if (distance > 1)
        {
            ship.Rb.AddForce(direction * speed, ForceMode2D.Impulse);
        }
        else
        {
            ship.Rb.AddForce(direction * speed * (distance * distance), ForceMode2D.Impulse);
        }

        direction = Camera.main.MyScreenToWorldPosition(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }


}

