using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private XMLController _xmlController;

    [SerializeField] private GameObject _SettingsPanel;

    [SerializeField] private TMP_Dropdown _windowSizeDropdown;
    [SerializeField] private Toggle _windowModeToggle;
    [SerializeField] private GameObject[] _windowModeToggleSprites;
    [SerializeField] private TMP_Text _windowModeText;
    [SerializeField] private Toggle _soundsAndMusicToggle;
    [SerializeField] private GameObject[] _soundsAndMusicToggleSprites;
    [SerializeField] private TMP_Text _soundsAndMusicText;
    [SerializeField] private Slider _volumeSlider;

    [SerializeField] private Button[] _exitBtns;
    [SerializeField] private Button _saveBtn;

    [SerializeField] private GameObject _confirmPanel;
    [SerializeField] private Button _resetBtn;
    [SerializeField] private Button _stayBtn;

    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        ResetSettings();

        _windowModeToggle.onValueChanged.AddListener(ChangeWindowMode);
        _soundsAndMusicToggle.onValueChanged.AddListener(TurnOnOffSoundAndMusic);

        foreach ( var btn in _exitBtns )
        {
            btn.onClick.AddListener(() =>
            {
                if (_xmlController.CheckSettings(_windowSizeDropdown.options[_windowSizeDropdown.value].text, _windowModeToggle.isOn, _soundsAndMusicToggle.isOn, (int)_volumeSlider.value))
                    _SettingsPanel.SetActive(false);
                else
                    _confirmPanel.SetActive(true);
            });
        }

        _resetBtn.onClick.AddListener(() =>
        {
            ResetSettings();

            _confirmPanel.SetActive(false);
        });

        _stayBtn.onClick.AddListener(() =>
        {
            _confirmPanel.SetActive(false);
        });

        _saveBtn.onClick.AddListener(() =>
        {
            _xmlController.UpdateSettings(_windowSizeDropdown.options[_windowSizeDropdown.value].text, _windowModeToggle.isOn, _soundsAndMusicToggle.isOn, (int)_volumeSlider.value);

            ChangeWindowSize();
            Screen.fullScreen = _windowModeToggle.isOn;
            _audioSource.mute = _soundsAndMusicToggle.isOn;
            ChangeVolume();
        });

        ChangeWindowMode(_windowModeToggle.isOn);
        TurnOnOffSoundAndMusic(_soundsAndMusicToggle.isOn);
    }

    private void ResetSettings()
    {
        List<string> settings = _xmlController.GetSettings();

        string windowSize = settings[0];
        string windowMode = settings[1];
        string sound = settings[2];
        string volume = settings[3];

        for (int i = 0; i < _windowSizeDropdown.options.Count; i++)
        {
            if (windowSize == _windowSizeDropdown.options[i].text)
            {
                _windowSizeDropdown.value = i;
                break;
            }
        }

        if (windowMode == "ON")
            _windowModeToggle.isOn = true;
        else
            _windowModeToggle.isOn = false;
        if (sound == "ON")
            _soundsAndMusicToggle.isOn = true;
        else
            _soundsAndMusicToggle.isOn = false;

        _volumeSlider.value = int.Parse(volume);
    }

    private void ChangeWindowSize()
    {
        int x = int.Parse(_windowSizeDropdown.options[_windowSizeDropdown.value].text.Split(':')[0]);
        int y = int.Parse(_windowSizeDropdown.options[_windowSizeDropdown.value].text.Split(':')[1]);

        Screen.SetResolution(x, y, _windowModeToggle.isOn);
    }

    private void ChangeWindowMode(bool value)
    {
        if (value)
        {
            _windowModeToggleSprites[0].gameObject.SetActive(false);
            _windowModeToggleSprites[1].gameObject.SetActive(true);
            _windowModeText.text = "ON";
        }
        else
        {
            _windowModeToggleSprites[0].gameObject.SetActive(true);
            _windowModeToggleSprites[1].gameObject.SetActive(false);
            _windowModeText.text = "OFF";
        }
    }

    private void TurnOnOffSoundAndMusic(bool value)
    {
        if (value)
        {
            _soundsAndMusicToggleSprites[0].gameObject.SetActive(false);
            _soundsAndMusicToggleSprites[1].gameObject.SetActive(true);
            _soundsAndMusicText.text = "ON";
        }
        else
        {
            _soundsAndMusicToggleSprites[0].gameObject.SetActive(true);
            _soundsAndMusicToggleSprites[1].gameObject.SetActive(false);
            _soundsAndMusicText.text = "OFF";
        }
    }

    private void ChangeVolume()
    {
        _audioSource.volume = (_volumeSlider.value / 100);
    }
}
