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
    private string[] characters =
     //A     B       C       D      E    F       G
    {".-", "-...", "-.-.", "-..", ".", "..-.", "--.",
    //H       I     J       K      L       M     N
     "....", "..", ".---", "-.-", ".-..", "--", "-.",
    //O      P       Q       R      S      T    U
     "---", ".--.", "--.-", ".-.", "...", "-", "..-",
    //V       W      X       Y       Z
     "...-", ".--", "-..-", "-.--", "--..",
    //0        1        2        3        4        
     "-----", ".----", "..---", "...--", "....-",
    //5        6        7        8        9    
     ".....", "-....", "--...", "---..", "----."};

    public void PlayMorseCodeMessage(string message)
    {
        StartCoroutine(_PlayMorseCodeMessage(message));
    }
    private IEnumerator _PlayMorseCodeMessage(string code)
    {
        coroutineRunning = true;
        Regex regex = new Regex("[^A-z0-9 ]");
        code = regex.Replace(code.ToUpper(), "");


        foreach (char character in code.ToCharArray())
        {
            if (character == ' ')
            {
                Debug.Log("space found");
                yield return new WaitForSeconds(spaceDelay);
            }
            else
            {
                int index = character - 'A';
                if (index < 0)
                    index = character - '0' + 26;
                string numberCode = characters[index];
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
