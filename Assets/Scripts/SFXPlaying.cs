using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlaying : MonoBehaviour
{
    public AudioSource WarriorCresShield;
    public AudioSource warriorheavy;
    public AudioSource WarriorRegAttack;
    public AudioSource WarriorTaunt;
    public AudioSource Health_Potion;
    public AudioSource luckycharm;
    public AudioSource berzerkerpot;
    public AudioSource sacredash;
    public AudioSource sactpact;
    public AudioSource electricalsurge;
    public AudioSource haste;
    public AudioSource infusion;
    public AudioSource searingflames;
    public AudioSource coinflip;
    public AudioSource diceroll;
    public AudioSource quickstab;
    public AudioSource rageswipe;

    public void PlayCresShield(){
        WarriorCresShield.Play();
    }
    public void Playwarriorheavy(){
        warriorheavy.Play();
    }
    public void PlayWarriorRegAttack(){
        WarriorRegAttack.Play();
    }
    public void PlayWarriorTaunt(){
        WarriorTaunt.Play();
    }

    public void PlayHealthPotion(){
        Health_Potion.Play();
    }

    public void playluckycharm(){
        luckycharm.Play();
    }

    public void playberzerkerpot(){
        berzerkerpot.Play();
    }
    public void playsacredash(){
        sacredash.Play();
    }
    public void playsactpact(){
        sactpact.Play();
    }
    public void elecsurge(){
        electricalsurge.Play();
    }
    public void playhaste(){
        haste.Play();
    }
    public void playinfusion(){
        infusion.Play();
    }
    public void playsearingflames(){
        searingflames.Play();
    }
    public void playcoinflip(){
        coinflip.Play();
    }
    public void playdiceroll(){
        diceroll.Play();
    }
    public void playquickstab(){
        quickstab.Play();
    }
    public void playrageswipe(){
        rageswipe.Play();
    }

}

