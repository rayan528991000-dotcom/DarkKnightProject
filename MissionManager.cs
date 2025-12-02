using UnityEngine;
using System.Collections.Generic;

public class MissionManager : MonoBehaviour
{
    public int currentMissionIndex = 0;
    public List<string> missions = new List<string>() { "Hunt 5 Wights", "Protect the Village" };

    void Start()
    {
        Debug.Log("Current mission: " + GetCurrentMission());
    }

    public string GetCurrentMission()
    {
        if (currentMissionIndex >= 0 && currentMissionIndex < missions.Count)
            return missions[currentMissionIndex];
        return "No mission";
    }

    public void CompleteCurrentMission()
    {
        Debug.Log("Mission completed: " + GetCurrentMission());
        currentMissionIndex++;
    }
}
