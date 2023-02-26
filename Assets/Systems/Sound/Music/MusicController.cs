using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;

    public AudioSource[] songList;
    public enum SongTitles { None, Beginning, Moody_Piano, Map_March, Beetle_Battle, Beetle_Enlightenment}
    public AudioSource beginning;
    public AudioSource moodyPiano;
    public AudioSource mapMarch;
    public AudioSource beetleBattle;
    public AudioSource beetleEnlightenment;

    public SongTitles currentSong;

    private void Awake()
    {
        instance = this;

        songList = GetComponents<AudioSource>();
        beginning = songList[0];
        moodyPiano = songList[1];
        mapMarch = songList[2];
        beetleBattle = songList[3];
        beetleEnlightenment = songList[4];
    }

    public void PlaySong(SongTitles _songTitle) {

        if (currentSong == _songTitle)
            return; //Song already playing. Let it.
        else {
            StopMusic();
        }

        currentSong = _songTitle;

        switch (_songTitle)
        {
            case SongTitles.Beginning:
                StartCoroutine(AudioFade.FadeIn(beginning, .5f));
                break;
            case SongTitles.Moody_Piano:
                StartCoroutine(AudioFade.FadeIn(moodyPiano, 1f));
                break;
            case SongTitles.Map_March:
                StartCoroutine(AudioFade.FadeIn(mapMarch, .5f));
                break;
            case SongTitles.Beetle_Battle:
                StartCoroutine(AudioFade.FadeIn(beetleBattle, 1f));
                break;
            case SongTitles.Beetle_Enlightenment:
                StartCoroutine(AudioFade.FadeIn(beetleEnlightenment, 1f));
                break;
        }
    }

    public void StopMusic() {
        switch (currentSong)
        {
            case SongTitles.Beetle_Battle:
                StartCoroutine( AudioFade.FadeOut(beetleBattle, 1f) );
                break;
            case SongTitles.Moody_Piano:
                StartCoroutine( AudioFade.FadeOut(moodyPiano, 1f) );
                break;
            case SongTitles.Beetle_Enlightenment:
                StartCoroutine( AudioFade.FadeOut(beetleEnlightenment, 1f) );
                break;
            case SongTitles.Map_March:
                StartCoroutine(AudioFade.FadeOut(mapMarch, 1f));
                break;
            case SongTitles.Beginning:
                StartCoroutine(AudioFade.FadeOut(beginning, 1f));
                break;
        }
    }
}
