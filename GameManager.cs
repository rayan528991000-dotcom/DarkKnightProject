using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public MissionManager missionManager;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (missionManager == null)
            missionManager = FindObjectOfType<MissionManager>();
    }
}
