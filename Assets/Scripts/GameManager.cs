using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(AudioAssetManager), typeof(SpriteAssetManager))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance => _instance;
    private static GameManager _instance;
    
    [SerializeField] private GameObject imagePoster;
    [SerializeField] private Image backgroundImage;
    
    [Header("Controller")]
    public bool controllerEnabled;
    public KeyCode InteractKey => interactKey;
    [SerializeField] private KeyCode interactKey = KeyCode.Mouse0;
    public KeyCode CancelKey => cancelKey;
    [SerializeField] private KeyCode cancelKey = KeyCode.Mouse1;
    public event Action OnControllerKeyPressed;
    private List<KeyCode> _pressedControlKey = new(5);
    public ReadOnlyCollection<KeyCode> PressedControlKey => _pressedControlKey.AsReadOnly();

    
    
    
    private AudioSource _audioSource;
    private AudioAssetManager _audioAssetManager;
    private SpriteAssetManager _spriteAssetManager;
    private Dictionary<string, GameObject> postedImages = new();


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioAssetManager = GetComponent<AudioAssetManager>();
        _instance = this;
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            _pressedControlKey.Clear();
            if (Input.GetKeyDown(interactKey))
                _pressedControlKey.Add(interactKey);
            if(Input.GetKeyDown(cancelKey))
                _pressedControlKey.Add(cancelKey);
            if (_pressedControlKey.Count > 0)
                OnControllerKeyPressed?.Invoke();
        }
    }

    public void PlaySfx(string sfxName)
    {
        _audioSource.PlayOneShot(_audioAssetManager.FindSfx(ref sfxName));
    }

    public void ChangeBackgroundMusic(string musicName)
    {
        _audioSource.clip = _audioAssetManager.FindMusic(ref musicName);
        _audioSource.Play();
    }

    public void ChangeBackgroundImage(string imageName)
    {
        backgroundImage.sprite = _spriteAssetManager.GetSpriteAsset(ref imageName);
    }

    public void PostSpriteOnScreen(string spriteName)
    {
        var imgObject = new GameObject(spriteName, typeof(RectTransform), typeof(Image));
        imgObject.transform.parent = imagePoster.transform;
        postedImages.Add(spriteName,imgObject);
    }

    public void RemovePostedSpriteOnScreen(string spriteName)
    {
        postedImages.TryGetValue(spriteName, out var spriteObject);
        if (spriteObject == null)
        {
            Debug.LogWarning($"{spriteName} is not posted");
            return;
        }
        Destroy(spriteObject);
        postedImages.Remove(spriteName);
    }
}
