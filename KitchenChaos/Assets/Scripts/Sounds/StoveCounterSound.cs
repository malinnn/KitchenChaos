using UnityEngine;

public class StoveCounterSound : MonoBehaviour
{
    #region FIELDS
    [SerializeField] private StoveCounter _stoveCounter;
    private AudioSource _audioSource;
    #endregion

    #region SUBSCRIPTIONS
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        _stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }

    private void OnDestroy()
    {
        _stoveCounter.OnStateChanged -= StoveCounter_OnStateChanged;
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        bool playSound = e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried;

        if(playSound)
        {
            _audioSource.Play();
        }
        else
        {
            _audioSource.Pause();
        }
    }
    #endregion
}
