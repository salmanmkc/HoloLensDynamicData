using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class createPrefabs : MonoBehaviour
{
    private ObjectTracker objtracker;
    public GameObject prefab;
    private StateManager stateManager;
    string datasetname = "ArIot";
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        try { VuforiaARController.Instance.RegisterVuforiaStartedCallback(OnVuforiaStarted); }
        catch(Exception e)
        {
            Debug.Log(e.Message);
        }
        
        

    }

    private void OnVuforiaStarted()
    {
        TrackerManager trackerManager = (TrackerManager)TrackerManager.Instance;
        objtracker = trackerManager.GetTracker<ObjectTracker>();
        stateManager = trackerManager.GetStateManager();

        objtracker.Stop();
        if (DataSet.Exists(datasetname))
        {
            DataSet dataset = objtracker.CreateDataSet();
            dataset.Load(datasetname);
            objtracker.ActivateDataSet(dataset);
        }
        else
        {
            Debug.Log("No dataset with name: " + datasetname);
            return;
        }

        // find the gameobject created by Vuforia for the vumark that has just been activated
        foreach (TrackableBehaviour trackableBehaviour in stateManager.GetTrackableBehaviours())
        {
            if (trackableBehaviour is ImageTargetBehaviour && trackableBehaviour.isActiveAndEnabled)
            {
                GameObject canvas1 = Instantiate(canvas);
                ImageTargetBehaviour imageTargetBehaviour = (ImageTargetBehaviour)trackableBehaviour;
                Debug.Log("TrackableName: " + imageTargetBehaviour.TrackableName);
                imageTargetBehaviour.gameObject.AddComponent<DefaultTrackableEventHandler>();
                canvas1.transform.parent = imageTargetBehaviour.transform;
            }
        }
    }
}
