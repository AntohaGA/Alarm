using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private const float SpeedVolumeChange = 0.2f;

    private AudioSource _alarmSound;

    private string _target = "Burglar";

    private IEnumerator _VolumeUpCoroutine;
    private IEnumerator _VolumeDownCoroutine;

    private void Awake()
    {
        _VolumeUpCoroutine = ChangeVolumeUp();
        _VolumeDownCoroutine = ChangeVolumeDown();
        _alarmSound = GetComponent<AudioSource>();
        _alarmSound.volume = 0;
        _alarmSound.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsTargets(other))
        {
            StopCoroutine(_VolumeDownCoroutine);
            _VolumeUpCoroutine = ChangeVolumeUp();
            StartCoroutine(_VolumeUpCoroutine);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (IsTargets(other))
        {
            StopCoroutine(_VolumeUpCoroutine);
            _VolumeDownCoroutine = ChangeVolumeDown();
            StartCoroutine(_VolumeDownCoroutine);
        }
    }

    private bool IsTargets(Collider target)
    {
        return target.CompareTag(_target);
    }

    private IEnumerator ChangeVolumeUp()
    {
        while (_alarmSound.volume != 1)
        {
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, 1, SpeedVolumeChange * Time.deltaTime);

            yield return null;
        }
    }

    private IEnumerator ChangeVolumeDown()
    {
        while (_alarmSound.volume != 0)
        {
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, 0, SpeedVolumeChange * Time.deltaTime);

            yield return null;
        }
    }
}