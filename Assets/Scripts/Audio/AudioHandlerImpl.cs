using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Audio
{
    public class AudioHandlerImpl : IAudioHandler
    {

        private readonly IDictionary<SoundType, AudioSource> _audios;

        public AudioHandlerImpl()
        {
            _audios = new Dictionary<SoundType, AudioSource>();
        }

        public void AddSound(SoundType type, AudioSource clip)
        {
            _audios[type] = clip;
        }

        public void PlaySound(SoundType type)
        {

            var clip = _audios[type];
            clip.Play();

        }

        public bool HasSound(SoundType type)
        {
            return _audios.ContainsKey(type);
        }
        
    }

}