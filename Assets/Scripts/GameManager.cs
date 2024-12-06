using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(AudioAssetManager), typeof(SpriteAssetManager))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject imagePoster;
    
    private AudioSource _audioSource;
    private AudioAssetManager _audioAssetManager;
    private SpriteAssetManager _spriteAssetManager;
    private Dictionary<string, GameObject> postedImages = new();

    [SerializeField] private Image backgroundImage;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioAssetManager = GetComponent<AudioAssetManager>();
        
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