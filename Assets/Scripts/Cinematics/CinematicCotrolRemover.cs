using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using RPG.Core;
using RPG.Control;

namespace RPG.Cinematics
{
    public class CinematicCotrolRemover : MonoBehaviour
    {
        GameObject player;

        void Awake() 
        {
            player = GameObject.FindWithTag("Player");
        }

        void OnEnable() 
        {
            GetComponent<PlayableDirector>().played += DisableControl;
            GetComponent<PlayableDirector>().stopped += EnableControl;
        }

        void OnDisable() 
        {
            GetComponent<PlayableDirector>().played += DisableControl;
            GetComponent<PlayableDirector>().stopped += EnableControl;
        }

        void Update() 
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SkipCutscene();
            }
        }

        void DisableControl(PlayableDirector pd)
        {
            player.GetComponent<ActionScheduler>().CancelCurrentAction();
            player.GetComponent<PlayerController>().enabled = false;
        }

        void EnableControl(PlayableDirector pd)
        {
            player.GetComponent<PlayerController>().enabled = true;
        }

        void SkipCutscene()
        {
                GetComponent<PlayableDirector>().Stop();
                EnableControl(GetComponent<PlayableDirector>());
        }
    }
}
