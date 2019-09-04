using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//play all sound wihout player
public class soundScript : MonoBehaviour
{
    AudioSource[] audioSources;

    
    
    // Start is called before the first frame update
    void Start()
    {
        audioSources= GetComponents<AudioSource>(); //for many array
      
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource winner =null;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //GetComponent<AudioSource>().Play();
           

           // if (!audioSources[0].isPlaying)
           // {
            //    audioSources[0].Play();
                
          //  }
          //  else
          //  {
               // audioSources[1].Play();
           // }



           float winnerRatio = 0;
           for (int i = 0; i < audioSources.Length; i++)
           {
               if (audioSources[i].isPlaying == false)
               {

                   winner = audioSources[i];
                   break; //stop the loop
               }
               else
               {
                   
                   float currentSoundCompletionRation = audioSources[i].time / audioSources[i].clip.length;
                   if (currentSoundCompletionRation > winnerRatio)
                   {
                       winner = audioSources[i];
                       winnerRatio = currentSoundCompletionRation;
                   }
               }

           }

           if (winner)
           {
                winner.Play();
           }

          


        }
    }
}
