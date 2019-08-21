using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class loadData : MonoBehaviour, ITrackableEventHandler
{
    #region PROTECTED_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;
    public float temperatureVal;
    public Text temperatureText;
    public float humidityVal;
    public Text humidityText;
    //float temperature;
    //float humidity;



    #endregion // PROTECTED_MEMBER_VARIABLES

    #region UNITY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    protected virtual void OnDestroy()
    {
        //if (mTrackableBehaviour)
        //    mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName +
                  " " + mTrackableBehaviour.CurrentStatus +
                  " -- " + mTrackableBehaviour.CurrentStatusInfo);

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PROTECTED_METHODS

    protected virtual async void OnTrackingFound()
    {
            try
            {
                //string name = gameObject.GetComponent<Trackable>().Name;
                //string name = "e1ebb451-40c4-4e3b-980a-f495695a3855";
                //string example = "{'Username': 'myusername','Password':'pass'}"; 
                string json = @"{""operationName"":null,""variables"":{},""query"":""{\n asset(uuid: \""" + name + @"\"") {\n    readings(filter: {types: [\""temperature\"", \""humidity\""]}) {\n      type {\n        name\n      }\n      values(filter: {limit: 1}) {\n        values\n      }\n    }\n  }\n}\n""}";
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE1NjY4MjAzMTksInVzZXJuYW1lIjoiYWRtaW4ifQ.FMPYbA4s_jghL686qIPEPRliMLnUIJxeLeuVQ763NDk");
                    var response = await client.PostAsync("https://apidae.stage.rco-bozal.uk/graphql", new StringContent(json, Encoding.UTF8, "application/json"));
                    var content = await response.Content.ReadAsStringAsync();
                    var parseddata = JsonConvert.DeserializeObject<parseData.Rootobject>(content);
                    float temperature = parseddata.data.asset.readings[0].values[0].values[0];
                    float humidity = parseddata.data.asset.readings[1].values[0].values[0];
                    //string test = parseddata.data.assets[0].type;
                    string toBreakpoint = "";
                    gameObject.GetComponent<accessData>().temperatureVal = temperature;
                    gameObject.GetComponent<accessData>().humidityVal = humidity;
                    temperatureText.text = temperatureVal.ToString();
                    humidityText.text = humidityVal.ToString();

                }

                //var request = "https://apidae.stage.rco-bozal.uk/graphql";
                //var response = await client.GetAsync(request);
                //var response = await client.GetAsync(request);

            }
            catch (Exception e)
            {
                throw e;
            }






        
    }


    protected virtual void OnTrackingLost()
    {
        
    }

    #endregion // PROTECTED_METHODS
}
