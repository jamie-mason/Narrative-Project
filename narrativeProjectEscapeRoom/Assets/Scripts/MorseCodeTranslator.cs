using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;


public class MorseCodeTranslator : MonoBehaviour
{
    public AudioClip dotSound;
    public AudioClip dashSound;
    public AudioSource audioSource;
    private bool coroutineRunning = false;
    public float spaceDelay;
    public float letterDelay;

    //morse code numbers
    private string[] numbers =
        {/*0*/"-----", /*1*/".----", /*2*/"..---", 
        /*3*/"...--" , /*4*/ "....-", /*5*/ ".....", 
        /*6*/"-....", /*7*/"--...", /*8*/ "---..", 
        /*9*/"----."};

    public void PlayMorseCodeMessage(string message)
    {
        StartCoroutine(_PlayMorseCodeMessage(message));
    }
    private IEnumerator _PlayMorseCodeMessage(string code)
    {
        coroutineRunning = true;
        foreach (char number in code.ToCharArray())
        {
            if (number == ' ')
            {
                Debug.Log("space found");
                yield return new WaitForSeconds(spaceDelay);
            }
            else
            {
                int index = number - '0';
                if (index < 0)
                    Debug.LogError("Index less than 0");
                string numberCode = numbers[index];
                foreach (char bit in numberCode)
                {
                    // Dot or Dash?
                    AudioClip sound = dotSound;
                    if (bit == '-') sound = dashSound;

                    // Play the audio clip and wait for it to end before playing the next one.
                    audioSource.clip = sound;
                    audioSource.Play();
                    yield return new WaitForSeconds(sound.length + letterDelay);
                }
            }
        }
        coroutineRunning = false;
    }
   
    public bool getCoroutineIsRunning()
    {
        return coroutineRunning;
    }
   
}
