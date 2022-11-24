using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
    public float timer_max;
    private float timer;
    public Text countdown_text;
    private int seconds;
    public bool playing;
    public game_manager manager_script;
    public ruby_score ruby_score_script;

    // Game objects with th outcome (you win / you lose)
    // UI images inside canvas_minijuego
    public GameObject outcome_win;
    public GameObject outcome_lose;

    void Start()
    {
        timer = timer_max;
        countdown_text.text = zerosPrefix(timer) + timer.ToString();
        playing = false;

        // Hide "you win/you lose" UI images on canvas_minijuego
        outcome_lose.SetActive(false); 
        outcome_win.SetActive(false); 
    }

    void Update()
    {
        if (manager_script.clock_start == true)
        {
            startTimer();
        }
    }

    /**********************************************
    @description Timer starts til 00:00, then the result is showed (You Win or You Lose)
    @design  -> startTimer() ->
    @author Diana Hernández Soler
    @date 23/12/2020
    ***********************************************/
    private void startTimer()
    {
        timer -= Time.deltaTime;
        seconds = Mathf.FloorToInt(timer % timer_max);

        // -1 cause' the timer needs to stop just in 00:00
        if (seconds > -1 && ruby_score_script.score < manager_script.RUBYSTOWIN)
        {

            countdown_text.text = zerosPrefix(timer) + seconds.ToString();

        }else{

            showOutcome();

        }
    }

    /**********************************************
    @description Shows "You Win/You Lose" UI image (canvas_minijuego)
    @design -> showOutcome() ->
    @author Diana Hernández Soler
    @date 26/12/2020
    ***********************************************/
    public void showOutcome()
    {
        if (ruby_score_script.score == manager_script.RUBYSTOWIN){

            Debug.Log("You win!");
            outcome_lose.SetActive(false); // I don't know if we need this
            outcome_win.SetActive(true);

        }else{

            Debug.Log("You lose!");
            outcome_win.SetActive(false); // I don't know if we need this
            outcome_lose.SetActive(true);

        }

    }

    /**********************************************
    @description string with zeros prefix for timer;
    @examples:
     ** input => 5 output => 00:0
     ** input => 34 output => 00:
    @design  float currentTime > zerosPrefix() -> string 
    @author Diana Hernández Soler
    @date 25/12/2020
    ***********************************************/
    private string zerosPrefix(float currentTime)
    {
        string prefix = "00:";
        if (currentTime < 10){
            
            prefix = "00:0";

        }

        return prefix;
    }

    /**********************************************
    @description loss 10 seconds in the game
    @design  -> lostTime() ->  
    @author Diana Hernández Soler
    @date 27/12/2020
    ***********************************************/
    public void lossTime()
    {
        timer -= 10;
    }
}

