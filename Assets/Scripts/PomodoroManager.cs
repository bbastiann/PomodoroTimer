using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PomodoroManager : MonoBehaviour
{
    public Button btnStart;
    public Button btnShortBreak;
    public Button btnLongBreak;

    public Timer timer;
    // Start is called before the first frame update
    
    public float targetTime;
    public float shortTime;
    public float largeTime;
    public float tiempo;

    private float minutes;
    private float seconds;
    
    public GameObject textTiempo;
    
    //-----------------------AUDIO------------------------
    private AudioSource _audioSource;

    //----------------------------------------------------

    public enum PomodoroStates {
        pausado,
        pomodoro, 
        shortB, 
        longB,
        finalizado
    };

    private PomodoroStates estado = PomodoroStates.pausado;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        textTiempo.GetComponent<TextMeshProUGUI>().text = "25:00";
    }

 
    void Update()
    {

        if (estado == PomodoroStates.pomodoro)
        {
            
            TimerController();
        }

        if (estado == PomodoroStates.shortB)
        {
            TimerController();
        }

        if (estado == PomodoroStates.longB)
        {
            TimerController();
        }
    }

    public void StartTimer()
    {
       
            estado = PomodoroStates.pomodoro;
            tiempo = targetTime;
           
    }
    public void ShortBreak()
    {
        
            estado = PomodoroStates.shortB;
            tiempo = shortTime;
            
    }
    
    public void LongBreak()
    {
        estado = PomodoroStates.longB;
        tiempo = largeTime;
    }
    
    private void TimerController()
    {
        if (tiempo > 0)
        {
            tiempo -= Time.deltaTime;
            UpdateTime(tiempo);
        }
        else
        {
            _audioSource.Play();
            tiempo = 0;
        }
        
        
    }

    private void UpdateTime(float currentTime)
    {
        currentTime += 1;
        
        float minutes = Mathf.FloorToInt(currentTime/60);
        float seconds = Mathf.FloorToInt(currentTime%60);
        
        
        textTiempo.GetComponent<TextMeshProUGUI>().text = 
            string.Format("{0}:{1}",minutes.ToString("00"),seconds.ToString("00") );
    }
    
}
