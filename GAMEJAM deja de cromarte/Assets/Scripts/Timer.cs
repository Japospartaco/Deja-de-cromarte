using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
 
    private float TimeLeft;
    private float TimeS;
    [SerializeField] private float TimeMax;
    [SerializeField] private TextMeshProUGUI TimerText;
    [SerializeField] private TextMeshProUGUI TimeText;
    private bool time_on;
    private Blackout blackout;
    public AudioClip sound;
    private AudioSource audioSource;
    

    private int time_wasted_mode;

    public Image battery_bar;
    // Start is called before the first frame update
    void Start()
    {
        blackout = gameObject.GetComponent<Blackout>();
        time_on = true;
        time_wasted_mode = 1;

        TimeLeft = TimeMax;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (blackout.estado == 2)
            time_wasted_mode = 2;
        else if (blackout.estado == 0)
            time_wasted_mode = 3;
        else if (blackout.estado == 1)
            time_wasted_mode = 1;
        

        float passed_Time = Time.deltaTime * time_wasted_mode;

        if (time_on)
		{
            TimeS += Time.deltaTime;
            float minutes = Mathf.FloorToInt(TimeS / 60);
            float seconds = Mathf.FloorToInt(TimeS % 60);
            if(seconds < 10)
            {
                TimeText.text = $"Has sobrevivido: {minutes}:0{seconds}";
            }
            else
            {
                TimeText.text = $"Has sobrevivido: {minutes}:{seconds}";
            }
            
            TimeLeft -= passed_Time;
            UpdateTimer(TimeLeft, passed_Time);
        }

    }

    void UpdateTimer(float current_Time, float passed_Time)
	{
        current_Time += passed_Time;

        float minutes = Mathf.FloorToInt(current_Time / 60);
        float seconds = Mathf.FloorToInt(current_Time % 60);
        if (seconds < 10)
        {
            TimerText.text = $"Bateria: {minutes}:0{seconds}"; 
        }
        else
        {
            TimerText.text = $"Bateria: {minutes}:{seconds}";
        }
        
        battery_bar.fillAmount = current_Time / TimeMax;
        if (minutes <= 0 && seconds <= 0)
        {
            time_on = false;
            TimerText.text = "Bateria: 0:00";
            SceneManager.LoadScene("End");
        }
        if (TimeLeft > TimeMax)
        {
            TimeLeft= TimeMax;
        }
    }

    public void UpdateTimerOnHit(int hit)
	{
        if (hit < 0)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(sound);
        }
        TimeLeft -= hit;
	}
}
