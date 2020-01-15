using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    #region Private Variables

    [SerializeField] int _coinsRequired = 8;
    [SerializeField] Renderer _callButton;
    [SerializeField] private Elevator _elevator;

    private bool _elevatorCall = false;

    #endregion

    #region Unity Functions

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                if (Input.GetKeyDown(KeyCode.E) && (player.GetCoinCount() >= _coinsRequired))
                {
                    if (_elevatorCall == true)
                    {
                        _callButton.material.color = Color.red;
                    }
                    else
                    {
                        _callButton.material.color = Color.green;
                        _elevatorCall = true;
                    }

                    _elevator.CallElevator();
                }
            }
        }
    }
    
    #endregion
}
