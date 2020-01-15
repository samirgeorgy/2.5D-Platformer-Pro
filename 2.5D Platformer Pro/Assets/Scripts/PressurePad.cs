using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("MovingBox"))
        {
            float distance = Vector3.Distance(this.transform.position, other.transform.position);

            if (distance < 0.05)
            {
                Rigidbody box = other.GetComponent<Rigidbody>();

                if (box != null)
                {
                    box.isKinematic = true;
                }

                MeshRenderer renderer = GetComponentInChildren<MeshRenderer>();

                if (renderer != null)
                {
                    renderer.material.color = Color.blue;
                }

                Destroy(this);
            }
        }
    }
}
