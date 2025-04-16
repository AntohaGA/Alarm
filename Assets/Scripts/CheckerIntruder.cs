using System;
using UnityEngine;

public class CheckerIntruder : MonoBehaviour
{
    public event Action BurglarDetected;
    public event Action BurglarGone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Burglar _))
        {
            BurglarDetected?.Invoke();
            Debug.Log("Burglar on");
        }

        else
        {
            Debug.Log("Someone else on");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Burglar _))
        {
            BurglarGone?.Invoke();
            Debug.Log("Burglar gone");
        }
        else
        {
            Debug.Log("Someone else off");
        }
    }
}