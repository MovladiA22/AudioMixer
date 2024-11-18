using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        ChangeVolume(_slider.value);
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void ChangeVolume(float volume)
    {
        float _multiplier = 20f;

        if (_mixer.audioMixer.GetFloat(_mixer.name, out float volue))
        {
            if (volue == 0)
                volume = -80f;
            else
                volume = Mathf.Log10(volume) * _multiplier;

            _mixer.audioMixer.SetFloat(_mixer.name, volume);
        }
    }
}
