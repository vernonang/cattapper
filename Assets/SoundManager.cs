using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider soundEffectsSlider;
    [SerializeField] private Sprite mutedBGMImage;
    [SerializeField] private Sprite unmutedBGMImage;
    [SerializeField] private Button bgmButton;
    [SerializeField] private Button sfxButton;
    [SerializeField] private List<AudioClip> catSounds = new List<AudioClip>();
    [SerializeField] private AudioClip uiSound;
    [SerializeField] private AudioSource sfxSource;

    private static bool mutedBGM;
    private static float prevBGMVol;

    private static bool mutedSFX;
    private static float prevSFXVol;

    private void Start()
    {
        SetBGMVolume();
        SetSFXVolume();
        prevBGMVol = 1;
        prevSFXVol = 1;
        mutedBGM = false;
        mutedSFX = false;
        bgmSlider.onValueChanged.AddListener(delegate { BGMSliderUpdate(); });
        soundEffectsSlider.onValueChanged.AddListener(delegate { SFXSliderUpdate(); });
    }

    private void Update()
    {

    }

    public void BGMSliderUpdate()
    {
        if (bgmSlider.value == bgmSlider.minValue)
        {
            bgmButton.GetComponent<Image>().sprite = mutedBGMImage;
            mutedBGM = true;
        }
        else if (bgmSlider.value > bgmSlider.minValue && mutedBGM == true)
        {
            mutedBGM = false;
            bgmButton.GetComponent<Image>().sprite = unmutedBGMImage;
        }
    }

    public void SFXSliderUpdate()
    {
        if (soundEffectsSlider.value == soundEffectsSlider.minValue)
        {
            sfxButton.GetComponent<Image>().sprite = mutedBGMImage;
            mutedSFX = true;
        }
        else if (soundEffectsSlider.value > soundEffectsSlider.minValue && mutedSFX == true)
        {
            mutedSFX = false;
            sfxButton.GetComponent<Image>().sprite = unmutedBGMImage;
        }
    }

    public void SetBGMVolume()
    {
        float volume = bgmSlider.value;
        mixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume()
    {
        float volume = soundEffectsSlider.value;
        mixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }

    public void PlayUISound()
    {
        sfxSource.clip = uiSound;
        sfxSource.Play();
    }

    public void PlayKittySFX()
    {
        if (sfxSource.isPlaying)
            return;

        sfxSource.clip = catSounds[Random.Range(0, catSounds.Count)];
        sfxSource.Play();
    }

    public void MuteBGM()
    {
        if (mutedBGM == false)
        {
            mutedBGM = true;
            bgmButton.GetComponent<Image>().sprite = mutedBGMImage;
            prevBGMVol = bgmSlider.value;
            bgmSlider.value = bgmSlider.minValue;
            mixer.SetFloat("BGM", Mathf.Log10(bgmSlider.value) * 20);
            return;
        }
        else
        {
            mutedBGM = false;
            bgmButton.GetComponent<Image>().sprite = unmutedBGMImage;
            bgmSlider.value = prevBGMVol;
            mixer.SetFloat("BGM", Mathf.Log10(prevBGMVol) * 20);
            return;
        }
    }

    public void MuteSFX()
    {
        if (mutedSFX == false)
        {
            mutedSFX = true;
            sfxButton.GetComponent<Image>().sprite = mutedBGMImage;
            prevSFXVol = soundEffectsSlider.value;
            soundEffectsSlider.value = soundEffectsSlider.minValue;
            mixer.SetFloat("SFX", Mathf.Log10(soundEffectsSlider.value) * 20);
            return;
        }
        else
        {
            mutedSFX = false;
            sfxButton.GetComponent<Image>().sprite = unmutedBGMImage;
            soundEffectsSlider.value = prevSFXVol;
            mixer.SetFloat("SFX", Mathf.Log10(prevSFXVol) * 20);
            return;
        }
    }
}
