using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] Transform _origin, _target;
    [SerializeField] float _speed = 1;

    private bool _goingDown = false;

    public void CallElevator()
    {
        _goingDown = !_goingDown;
    }

    private void FixedUpdate()
    {
        if (_goingDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        }
        else
            transform.position = Vector3.MoveTowards(transform.position, _origin.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.transform.parent = this.transform;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.transform.parent = null;
            }
        }
    }
}
