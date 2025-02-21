using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource musicSource;
    private AudioSource effectsSource;

    public AudioClip musicClip;
    public AudioClip ballHitSound;
    public AudioClip scoreSound;
    public AudioClip buttonClickSound; 
    public AudioClip winSound;


    public Slider musicSlider;
    public Slider effectsSlider;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        // Criando duas fontes de áudio: uma para música e outra para efeitos
        musicSource = gameObject.AddComponent<AudioSource>();
        effectsSource = gameObject.AddComponent<AudioSource>();

        musicSource.volume = PlayerPrefs.GetFloat("MusicVolume", 1f); ;
        effectsSource.volume = PlayerPrefs.GetFloat("EffectsVolume", 1f); ;

        // Configurando a fonte de música
        musicSource.clip = musicClip;
        musicSource.loop = true;
        musicSource.Play();

    }

    void SetSliders()
    {
        GameObject musicObj = GameObject.Find("MusicSlider");
        if (musicObj != null)
        {
            musicSlider = musicObj.GetComponent<Slider>();
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
            musicSlider.onValueChanged.RemoveAllListeners();
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
        }

        GameObject effectsObj = GameObject.Find("EffectsSlider");
        if (effectsObj != null)
        {
            effectsSlider = effectsObj.GetComponent<Slider>();
            effectsSlider.value = PlayerPrefs.GetFloat("EffectsVolume", 1f);
            effectsSlider.onValueChanged.RemoveAllListeners();
            effectsSlider.onValueChanged.AddListener(SetEffectsVolume);
        }
    }

    public void PlaySoundEffect(AudioClip clip)
    {

        effectsSource.PlayOneShot(clip, effectsSource.volume);
    }

    // Ajusta o volume da música
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume); // Salva preferências
        PlayerPrefs.Save();
    }

    // Ajusta o volume dos efeitos sonoros
    public void SetEffectsVolume(float volume)
    {
        effectsSource.volume = volume;
        PlayerPrefs.SetFloat("EffectsVolume", volume); // Salva preferências
        PlayerPrefs.Save();
    }

    // Adiciona som de clique nos botões
    public void AddButtonClickSounds()
    {
        Button[] buttons = FindObjectsByType<Button>(FindObjectsSortMode.None);
        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(PlayButtonClickSound);
        }
    }

    void PlayButtonClickSound()
    {
        PlaySoundEffect(buttonClickSound);
    }

    public void PlayWinSound()
    {
        PlaySoundEffect(winSound);
    }

    public void UpdateMenu()
    {
        AddButtonClickSounds();
        SetSliders();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateMenu();
    }
}
