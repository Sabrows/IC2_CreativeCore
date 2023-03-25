using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Cameras")]
    /// <summary>
    /// Switch between WideAngle, MidRange and CloseUp cameras in scene
    /// Swap text label accordingly
    /// </summary>
    [SerializeField]
    private Camera[] _cameras;

    [SerializeField] private TMP_Dropdown _cameraDropdown;

    [Header("Audio")]
    /// <summary>
    /// Mute and unmute the sound sources
    /// Swap button sprites respectively
    /// </summary>
    [SerializeField]
    private Button _audioMuteButton;

    [SerializeField] public AudioSource[] _audioSources;
    [SerializeField] private Sprite _audioMutedSprite;
    [SerializeField] private Sprite _audioUnmutedSprite;

    [Header("VFX")]
    /// <summary>
    /// Toggle firepit particle systems on key press/button click
    /// </summary>
    public ParticleSystem fireParticle;

    public GameObject pointLight;
    public ParticleSystem smokeParticle;
    public ParticleSystem sparkParticle;

    [Header("Animations")]
    /// <summary>
    /// Trigger NPC animations
    /// </summary>
    [SerializeField]
    private Animator _animatorNina;

    private bool _audioIsMuted;
    private Camera _currentCamera;
    private bool _isPlaying;

    private void Start()
    {
        foreach (var camera in _cameras) camera.gameObject.SetActive(false);

        _cameras[0].gameObject.SetActive(true);
        _currentCamera = _cameras[0];

        if (SceneManager.GetActiveScene().buildIndex == 0)
            _isPlaying = false;
        else
            _isPlaying = true;
    }

    private void Update()
    {
        CheckPressedKey();
    }

    private void CheckPressedKey()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (SceneManager.GetActiveScene().buildIndex == 0) TriggerBallKick();
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFire();
        }
    }

    public void SwitchScene()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            // currently day scene
            case 0:
                SceneManager.LoadScene(1);
                break;
            // currently night scene
            case 1:
                SceneManager.LoadScene(0);
                break;
        }
    }

    public void ChangeCamera()
    {
        _currentCamera.gameObject.SetActive(false);
        _currentCamera = _cameras[_cameraDropdown.value];
        _currentCamera.gameObject.SetActive(true);
    }

    public void ToggleAudio()
    {
        if (!_audioIsMuted)
        {
            _audioMuteButton.image.sprite = _audioMutedSprite;
            foreach (var audioSource in _audioSources) audioSource.mute = true;

            _audioIsMuted = true;
        }
        else
        {
            _audioMuteButton.image.sprite = _audioUnmutedSprite;
            foreach (var audioSource in _audioSources) audioSource.mute = false;

            _audioIsMuted = false;
        }
    }

    public void TriggerBallKick()
    {
        if (_animatorNina.gameObject.CompareTag("Nina"))
        {
            _animatorNina.SetTrigger("KickBall");
            GameObject.Find("BeachBall").GetComponent<Animator>().SetTrigger("BallKicked");
        }
    }

    public void ToggleFire()
    {
        if (_isPlaying)
        {
            smokeParticle.Play();
            fireParticle.Stop();
            sparkParticle.Stop();
            pointLight.SetActive(false);
            _isPlaying = false;
        }
        else
        {
            smokeParticle.Play();
            fireParticle.Play();
            sparkParticle.Play();
            pointLight.SetActive(true);
            _isPlaying = true;
        }
    }
}