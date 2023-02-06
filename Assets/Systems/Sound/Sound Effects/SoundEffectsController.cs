using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsController : MonoBehaviour
{
    public static SoundEffectsController instance;

    public AudioSource[] soundList;
    public enum SongTitles { Beetle_Battle, Root_Map, Ending }
    public AudioSource attack;
    public AudioSource heal;
    public AudioSource endSong;

    public SongTitles currentSong;

    private void Awake()
    {
        instance = this;

        soundList = GetComponents<AudioSource>();
        attack = soundList[0];
        heal = soundList[1];
    }

    public void PlaySound(string _soundString)
    {

        switch (_soundString)
        {
            case "Attack":
                attack.Play();
                break;
            case "Heal":
                heal.Play();
                break;
        }
    }
}
