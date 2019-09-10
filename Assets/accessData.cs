using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class accessData : MonoBehaviour
{
    public float temperatureVal;
    public Text temperatureText;
    public float humidityVal;
    public Text humidityText;
  

    public void Start()
    {
     
    }
    public async void getResponse(string name)
    {
        try
        {
          
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
                temperatureVal = temperature;
                humidityVal = humidity;
                temperatureText.text = temperature.ToString();
                humidityText.text = humidity.ToString();
              
            }
        }
        catch(Exception e)
        {
            throw e;
        }






    }


}
