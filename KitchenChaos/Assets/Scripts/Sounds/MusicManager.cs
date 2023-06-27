using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MusicManager : MonoBehaviour
{
    #region FIELDS

    public static MusicManager Instance { get; private set; }

    private AudioSource _audioSource;

    private float _volume = 0.3f;

    private const string PLAYER_PREFS_MUSIC = "MUSIC";

    #endregion

    #region SUBSCRIPTIONS
    private void Awake()
    {
        Instance = this;

        _audioSource = GetComponent<AudioSource>();

        _volume = PlayerPrefs.GetFloat(PLAYER_PREFS_MUSIC, 1f);
    }
    #endregion

    #region FUNCTIONS
    public void ChangeVolume(float changeAmount)
    {
        _volume = changeAmount;

        if (changeAmount > 1)
        {
            Debug.LogWarning("ChangeAmount should be between 0 and 1 !");
        }

        if (_volume > 1f)
        {
            _volume = 0f;
        }
        
        _audioSource.volume = _volume;

        PlayerPrefs.SetFloat(PLAYER_PREFS_MUSIC, _volume);
        PlayerPrefs.Save();
    }

    public float GetVolume()
    {
        return _volume;
    }

    #endregion
}
