using System;
using System.Collections.Generic;
using Helper;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

namespace DefaultNamespace.Audio
{
    public class AudioHandlerScript : MonoBehaviour
    {

        private static IAudioHandler _audioHandler;

        [SerializeField] private List<AudioSource> audios;
        [SerializeField] private List<string> names;

        private void Awake()
        {
            _audioHandler = new AudioHandlerImpl();
            LoadSounds();
        }

        public void LoadSounds()
        {

            for (var i = 0; i < audios.Count; i++)
            {

                var audio = audios[i];
                var name = names[i];
                
                var soundType = 
                    ParserHelper.ParseEnum<SoundType>(name);
                
                _audioHandler.AddSound(soundType, audio);
                
            }

        }
        
        public static IAudioHandler GetAudioHandler()
        {
            return _audioHandler;
        }

    }
    
}