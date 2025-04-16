using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;
    [SerializeField] private CheckerIntruder _checkerIntruder;

    private void Awake()
    {
        _checkerIntruder.BurglarDetected += _alarm.On;
        _checkerIntruder.BurglarGone += _alarm.Off;
    }

    private void OnDisable()
    {
        _checkerIntruder.BurglarDetected -= _alarm.On;
        _checkerIntruder.BurglarGone -= _alarm.Off;
    }
}
