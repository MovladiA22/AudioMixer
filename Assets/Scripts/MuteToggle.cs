using UnityEngine;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour
{
    [SerializeField] private AudioListener _audioListener;
    [SerializeField] private Toggle _toggle;

    private void Awake()
    {
        _audioListener.enabled = _toggle.isOn;
    }

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(ToggleMute);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(ToggleMute);
    }

    private void ToggleMute(bool enable) =>
        _audioListener.enabled = enable;
}
