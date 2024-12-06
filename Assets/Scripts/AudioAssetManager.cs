using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class AudioAssetManager : MonoBehaviour
{
    [SerializeField] private string SfxAssetDirectory;
    [SerializeField] private string MusicAssetDirectory;

    private Dictionary<string,AudioClip> SfxAssets;
    private Dictionary<string, AudioClip> MusicAssets;

    private void Awake()
    {
        throw new NotImplementedException();
    }

    private void LoadAudioAssets()
    {
        throw new NotImplementedException();
    }

    public AudioClip FindSfx(ref string sfxName)
    {
        AudioClip clip;
        if (SfxAssets.TryGetValue(sfxName, out clip))
            return clip;
        return FindSfxBackupPlan(ref sfxName);
    }
    public AudioClip FindMusic(ref string musicName)
    {
        AudioClip clip;
        if (MusicAssets.TryGetValue(musicName, out clip))
            return clip;
        return FindMusicBackupPlan(ref musicName);
    }

    private AudioClip FindSfxBackupPlan(ref string sfxName)
    {
        Debug.LogWarning($"{sfxName} is not under SfxAssetDirectory, start search all files under Resources folder");
        AudioClip clip = default;

        throw new RowNotInTableException();

        if (clip == null)
            throw new Exception($"Cannot find the audioClip called {sfxName}.");
        return clip;
    }

    private AudioClip FindMusicBackupPlan(ref string sfxName)
    {
        Debug.LogWarning($"{sfxName} is not under MusicAssetDirectory, start search all files under Resources folder");
        AudioClip clip = default;

        throw new RowNotInTableException();
        
        if (clip == null)
            throw new Exception($"Cannot find the audioClip called {sfxName}.");
        return clip;
    }
}