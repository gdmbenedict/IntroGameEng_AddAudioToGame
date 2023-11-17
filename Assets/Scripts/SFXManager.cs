using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    //SFX
    public AudioClip playerShoot;
    public AudioClip asteroidExplosion;
    public AudioClip playerDamage;
    public AudioClip playerExplosion;
    public AudioClip Start;
    public AudioClip Exit;

    //Music
    public AudioClip BgMusicGameplay;
    public AudioClip BgMusicTitleScreen;
    public AudioClip GameOver;

    //Voice Lines

    //Audio Sources
    private AudioSource SFXaudioSource;
    private AudioSource BgMusicAudioSource;
    private AudioSource BGM2;
    private AudioSource VoiceLines;

    //variables
    [SerializeField] private float TimeToFade = 1f;

    public void Awake()
    {
        SFXaudioSource = GetComponent<AudioSource>();
        //GameObject child = this.transform.Find("BgMusic").gameObject;
        BgMusicAudioSource = gameObject.transform.Find("BgMusic").gameObject.GetComponent<AudioSource>();
        BGM2 = gameObject.transform.Find("BGM2").gameObject.GetComponent<AudioSource>();
        VoiceLines = gameObject.transform.Find("VoiceLines").gameObject.GetComponent<AudioSource>();

        //setting clip
        BGM2.clip = GameOver;

        //BgMusicAudioSource.GetComponent<AudioSource>().Play();       
    }

    //called in the PlayerController Script
    public void PlayerShoot()
    {
        SFXaudioSource.PlayOneShot(playerShoot);
    }

    //called in the PlayerController Script
    public void PlayerDamage()
    {
        SFXaudioSource.PlayOneShot(playerDamage);
    }

    //called in the PlayerController Script
    public void PlayerExplosion()
    {
        SFXaudioSource.PlayOneShot(playerExplosion);
    }

    //called in the AsteroidDestroy script
    public void AsteroidExplosion()
    {
        SFXaudioSource.PlayOneShot(asteroidExplosion);
    }

    
    public void BGMusicMainMenu()
    {
        BgMusicAudioSource.clip = BgMusicTitleScreen;
        BgMusicAudioSource.Play();
    }

    public void BGMusicGameplay()
    {
        BgMusicAudioSource.GetComponent<AudioSource>().clip = BgMusicGameplay;
        BgMusicAudioSource.Play();

    }

    //play start sound
    public void StartSFX()
    {
        SFXaudioSource.PlayOneShot(Start);
    }

    //plays ecit sound
    public void ExitSFX()
    {
        SFXaudioSource.PlayOneShot(Exit);
    }

    //stops game over track
    public void stopGameOver()
    {
        BGM2.Stop();
        BgMusicAudioSource.volume = 0.25f;
    }

    public void FadeTransition()
    {
        StartCoroutine(FadeToTrack());
    }

    //function that transitions from gameplay music to game over music
    public IEnumerator FadeToTrack()
    {
        //setting variables
        float ttf = TimeToFade;
        float timeElasped = 0;

    
            BGM2.Play();

            while (timeElasped < ttf)
            {
                BgMusicAudioSource.volume = Mathf.Lerp(0.25f, 0, timeElasped / ttf);
                BGM2.volume = Mathf.Lerp(0, 0.25f, timeElasped / ttf);
                timeElasped += Time.deltaTime;
                yield return null;
            }

            BgMusicAudioSource.Stop();
        
         
    }
}
