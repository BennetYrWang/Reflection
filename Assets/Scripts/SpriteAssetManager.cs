using System;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAssetManager : MonoBehaviour
{
    [SerializeField] private string SpriteAsstedDirectory;
    
    private Dictionary<string, Sprite> spriteAssets;

    private void Awake()
    {
        LoadSpriteAssets();
    }

    private void LoadSpriteAssets()
    {
        throw new NotImplementedException();
    }

    public Sprite GetSpriteAsset(ref string spriteName)
    {
        Sprite sprite;
        if (spriteAssets.TryGetValue(spriteName, out sprite))
            return sprite;
        return GetSpriteAssetBackupPlan(ref spriteName);
    }

    private Sprite GetSpriteAssetBackupPlan(ref string spriteName)
    {
        throw new NotImplementedException();
    }
}