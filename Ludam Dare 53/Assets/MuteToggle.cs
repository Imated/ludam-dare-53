using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteToggle : MonoBehaviour
{
    public void ToggleMute()
    {
        FindObjectOfType<AudioManager>().ToggleMute();
    }
}
