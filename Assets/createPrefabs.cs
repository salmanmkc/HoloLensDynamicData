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
    //public GameObject canvas;
    //public GameObject fetchdata;
    public GameObject objects;

    //public DefaultTrackableEventHandler defaultTrackableEventHandler;
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
                //GameObject canvas1 = Instantiate(canvas);
                //GameObject fetchdata1 = Instantiate(fetchdata);
                GameObject objects1 = Instantiate(objects);
                GameObject fetchDataChild = objects1.transform.Find("FetchData").gameObject;
                GameObject canvasChild = objects1.transform.Find("Canvas").gameObject;
                //DefaultTrackableEventHandler defaultTrackableEventHandler1 = Instantiate(defaultTrackableEventHandler);
                ImageTargetBehaviour imageTargetBehaviour = (ImageTargetBehaviour)trackableBehaviour;
                Debug.Log("TrackableName: " + imageTargetBehaviour.TrackableName);
                
                imageTargetBehaviour.gameObject.AddComponent<DefaultTrackableEventHandler>();
                imageTargetBehaviour.gameObject.AddComponent<loadData>();
                imageTargetBehaviour.gameObject.AddComponent<TurnOffBehaviour>();
                

                //imageTargetBehaviour.gameObject.AddComponent<accessData>();

                //canvas1.transform.parent = imageTargetBehaviour.transform;
                //fetchdata1.transform.parent = imageTargetBehaviour.transform;
                fetchDataChild.transform.parent = imageTargetBehaviour.transform;
                canvasChild.transform.parent = imageTargetBehaviour.transform;
                canvasChild.gameObject.transform.localScale = new Vector3(0.002f, 0.002f, 0.002f);

                objtracker.Start();



            }
        }
    }
}
