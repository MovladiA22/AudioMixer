using UnityEngine;
using UnityEngine.Audio;

public class SoundCustomizer : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;

    private float _multiplier = 20f;

    public void ToggleMaster(bool enabled)
    {
        float minVolume = Mathf.Log10(-80f) * _multiplier;
        float maxVolume = Mathf.Log10(0f) * _multiplier;

        if (enabled)
            _mixer.audioMixer.SetFloat("Master", minVolume);
        else
            _mixer.audioMixer.SetFloat("Master", maxVolume);
    }

    public void ChangeMasterVolume(float volume) =>
        ChangeVolume("Master", volume);

    public void ChangeBackroundVolume(float volume) =>
        ChangeVolume("Backround", volume);

    public void ChangeSoundsVolume(float volume) =>
        ChangeVolume("Sounds", volume);

    private void ChangeVolume(string name, float volume)
    {
        float _multiplier = 20f;

        _mixer.audioMixer.SetFloat(name, Mathf.Log10(volume) * _multiplier);
    }
}
