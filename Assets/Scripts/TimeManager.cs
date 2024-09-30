using UnityEngine;

public class TimeManager: MonoBehaviour{
    public static TimeManager instance; 
    public TimeStack tStack; 
    public void Awake() {
        // check for any other inst. 
        if(instance != null && instance!= this) {
            Destroy(gameObject); 
            return;
        }
        // Okay then init
        tStack = new TimeStack();
        instance = new TimeManager();
        DontDestroyOnLoad(gameObject);
    }
    
}