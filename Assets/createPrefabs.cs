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
            if (trackableBehaviour is VuMarkBehaviour && trackableBehaviour.isActiveAndEnabled)
            {
                ImageTargetBehaviour imageTargetBehaviour = (ImageTargetBehaviour)trackableBehaviour;
                Debug.Log("TrackableName: " + imageTargetBehaviour.TrackableName);
                imageTargetBehaviour.gameObject.AddComponent<DefaultTrackableEventHandler>();
            }
        }// must be stopped when switching datasets
    }


    //GameObject prefab1 = Instantiate(prefab);
    //prefab1.GetComponent<ImageTargetBehaviour>().ImageTarget;
    //    IEnumerable<TrackableBehaviour> tbs = TrackerManager.Instance.GetStateManager().GetTrackableBehaviours();
    //    foreach(var tb in tbs)
    //    {
    //        GameObject prefab2 = Instantiate(prefab);
    //        //prefab2.GetComponent<ImageTargetBehaviour>().ImageTarget = tb.TrackableName;
    //    }

    //        foreach(db in getNu)
    //    {
    //        GameObject prefab = Instantiate(prefab);
    //        prefab.GetComponent<ImageTargetBehaviour>().ImageTarget = db.
    //    }
    //}

    // Update is called once per frame

}
