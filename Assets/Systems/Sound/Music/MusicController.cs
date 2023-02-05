using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;

    public AudioSource[] songList;
    public enum SongTitles { Beetle_Battle, Root_Map, Ending}
    public AudioSource battleSong;
    public AudioSource mapSong;
    public AudioSource endSong;

    public SongTitles currentSong;

    private void Start()
    {
        instance = this;

        songList = GetComponents<AudioSource>();
        battleSong = songList[0];
        mapSong = songList[1];
        endSong = songList[2];
    }

    public void PlaySong(SongTitles _songTitle) {

        currentSong = _songTitle;

        switch (_songTitle)
        {
            case SongTitles.Beetle_Battle:
                StartCoroutine(AudioFade.FadeIn(battleSong, 1f));
                break;
            case SongTitles.Root_Map:
                StartCoroutine(AudioFade.FadeIn(mapSong, 1f));
                break;
            case SongTitles.Ending:
                StartCoroutine(AudioFade.FadeIn(endSong, 1f));
                break;
        }
    }

    public void StopMusic() {
        switch (currentSong)
        {
            case SongTitles.Beetle_Battle:
                StartCoroutine( AudioFade.FadeOut(battleSong, 1f) );
                break;
            case SongTitles.Root_Map:
                StartCoroutine( AudioFade.FadeOut(mapSong, 1f) );
                break;
            case SongTitles.Ending:
                StartCoroutine( AudioFade.FadeOut(endSong, 1f) );
                break;
        }
    }
}
