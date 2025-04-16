using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private const float SpeedVolumeChange = 0.2f;
    private const float MaxVolume = 1.0f;
    private const float MinVolume = 0.0f;

    private bool _isVolumeChanges;

    private AudioSource _alarmSound;

    private IEnumerator _changeVolumeUpCoroutine;
    private IEnumerator _changeVolumeDownCoroutine;

    private void Awake()
    {
        _isVolumeChanges = false;
        _alarmSound = GetComponent<AudioSource>();
        _alarmSound.volume = 0;
    }

    public void On()
    {
        if (_isVolumeChanges)
        {
            StopCoroutine(_changeVolumeDownCoroutine);
        }

        _changeVolumeUpCoroutine = ChangeVolume(MaxVolume);
        StartCoroutine(_changeVolumeUpCoroutine);
    }

    public void Off()
    {
        if (_isVolumeChanges)
        {
            StopCoroutine(_changeVolumeUpCoroutine);
        }

        _changeVolumeDownCoroutine = ChangeVolume(MinVolume);
        StartCoroutine(_changeVolumeDownCoroutine);
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        _isVolumeChanges = true;

        if (targetVolume > 0)
        {
            _alarmSound.Play();
        }

        while (_alarmSound.volume != targetVolume)
        {
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, targetVolume, SpeedVolumeChange * Time.deltaTime);

            yield return null;
        }

        _isVolumeChanges = false;

        if (_alarmSound.volume == 0)
        {
            _alarmSound.Stop();
        }
    }
}