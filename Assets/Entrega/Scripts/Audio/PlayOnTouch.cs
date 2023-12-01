using UnityEngine;

public class PlayOnTouch : MonoBehaviour
{
    public AudioSource BotonAudioSource;
    public AudioClip SonidoBoton;

    public void PlaySound() => BotonAudioSource.PlayOneShot(SonidoBoton);
}
