using UnityEngine;
using UnityEngine.Audio;

public enum AudioGroup
{
    BGM,
    SFX,
}


[CreateAssetMenu(menuName ="AudioData")]
public class AudioDataSO : ScriptableObject
{
    public AudioClip[] AudioClip;
    public AudioGroup AudioGroup;
}
