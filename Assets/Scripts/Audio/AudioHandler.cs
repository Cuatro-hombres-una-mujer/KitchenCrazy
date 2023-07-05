using UnityEngine;

namespace DefaultNamespace.Audio
{
    public interface IAudioHandler
    {

        void AddSound(SoundType type, AudioSource audio);

        bool HasSound(SoundType type);

        void PlaySound(SoundType type);

    }

    public enum SoundType
    {
        
    }
    
}