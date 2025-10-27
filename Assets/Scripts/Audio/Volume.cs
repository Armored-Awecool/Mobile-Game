using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Volume : MonoBehaviour
{
    /*  public AudioMixer mixer;

      public AudioMixerGroup targetMixerGroup; // Drag your desired AudioMixerGroup here in the Inspector

      private AudioSource audioSource;

      public Slider volumeSlider;

      public string exposedParamName = "MasterVolume"; // Match the name from step 1
  void Awake()
      {
          audioSource = GetComponent<AudioSource>();
          if (audioSource != null && targetMixerGroup != null)
          {
              audioSource.outputAudioMixerGroup = targetMixerGroup;
          }
      }
      private void Start()
      {
          // Load saved volume or set to default
          float savedVol = PlayerPrefs.GetFloat(exposedParamName, 1f);
          SetVolume(savedVol);
          volumeSlider.value = savedVol;
      }


      public void SetVolume(float sliderValue)
      {
          // Convert linear slider value to logarithmic decibel scale
          mixer.SetFloat(exposedParamName, Mathf.Log10(sliderValue) * 20);
          PlayerPrefs.SetFloat(exposedParamName, sliderValue);
      }*/
    /* public Slider volumeSlider;
     public AudioMixer masterMixer; // Reference to your Audio Mixer

     private const string VolumeParamName = "MasterVolume"; // Name of your exposed parameter

     void Start()
     {
         // Load saved volume setting, or set a default
         if (PlayerPrefs.HasKey(VolumeParamName))
         {
             float savedVolume = PlayerPrefs.GetFloat(VolumeParamName);
             volumeSlider.value = ConvertToSliderValue(savedVolume); // Convert mixer value to slider value
             SetVolume(volumeSlider.value);
         }
         else
         {
             volumeSlider.value = 1f; // Default to full volume
             SetVolume(1f);
         }

         // Add listener for slider value changes
         volumeSlider.onValueChanged.AddListener(SetVolume);
     }

     public void SetVolume(float sliderValue)
     {
         // Convert slider value (0-1) to mixer value (logarithmic, e.g., -80 to 0)
         float mixerVolume = Mathf.Log10(sliderValue) * 20;
         masterMixer.SetFloat(VolumeParamName, mixerVolume);
         PlayerPrefs.SetFloat(VolumeParamName, mixerVolume); // Save the volume setting
     }

     // Helper function to convert mixer value to slider value for initialization
     private float ConvertToSliderValue(float mixerValue)
     {
         return Mathf.Pow(10, mixerValue / 20);
     }*/


    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
