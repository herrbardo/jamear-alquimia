using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class GlobalDJ : MonoBehaviour
{
    [SerializeField] List<AudioClip> Clips;
    [SerializeField] public float EffectsMaxVolume;
    [SerializeField] public float EffectsMinVolume;
    [SerializeField] public float MusicMaxVolume;
    [SerializeField] public float MusicMinVolume;
    [SerializeField] public AudioMixer GlobalMixer;

    public static GlobalDJ Instance;

    AudioSource audioSource;
    float originalVolume;
    int localIndexSong;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
            UIEvents.GetInstance().UIButtonPressed += UIButtonPressed;
            DontDestroyOnLoad (gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        UIEvents.GetInstance().UIButtonPressed -= UIButtonPressed;
    }

    private void Start()
    {
        originalVolume = audioSource.volume;
        CheckAudioSettings();
    }

    public void PlaySong(int indexSong)
    {
        localIndexSong = indexSong;
        float time = 0;
        if(audioSource.isPlaying)
        {
            time = 5;
            StartCoroutine(AudioHelper.StartFade(this.audioSource, time, 0f));
        }
        
        Invoke("FinallyPlay", time);
    }

    void FinallyPlay()
    {
        audioSource.clip = Clips[localIndexSong];
        audioSource.volume = 0;
        audioSource.Play();
        StartCoroutine(AudioHelper.StartFade(this.audioSource, 5, originalVolume));
    }

    void CheckAudioSettings()
    {
        int sound = PlayerPrefs.GetInt("Herrbardo_Settings_Sound", 1);
        float puta = (sound == 0) ? EffectsMinVolume : EffectsMaxVolume;
        GlobalMixer.SetFloat("EffectsVolume", puta);

        int music = PlayerPrefs.GetInt("Herrbardo_Settings_Music", 1);
        float puta2 = (music == 0) ? MusicMinVolume : MusicMaxVolume;
        GlobalMixer.SetFloat("MusicVolume", puta2);
    }

    public bool IsBusy()
    {
        return audioSource.isPlaying;
    }

    public void StopMusic()
    {
        StartCoroutine(AudioHelper.StartFade(this.audioSource, 5f, 0f));
    }

    void UIButtonPressed(string buttonName, bool value)
    {
        if(buttonName == "BtnSound")
            SwitchVolume("EffectsVolume", EffectsMaxVolume, EffectsMinVolume, value);
        else if(buttonName == "BtnMusic")
            SwitchVolume("MusicVolume", MusicMaxVolume, MusicMinVolume, value);
    }

    void SwitchVolume(string variableName, float maxVolume, float minVolume, bool value)
    {
        if(value)
            GlobalMixer.SetFloat(variableName, maxVolume);
        else
            GlobalMixer.SetFloat(variableName, minVolume);
    }
}
