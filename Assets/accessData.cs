﻿using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class accessData : MonoBehaviour
{
    //HttpClient client = new HttpClient();
    public float temperatureVal;
    public Text temperatureText;
    public float humidityVal;
    public Text humidityText;

    public void Start()
    {
        getResponse();
    }
    async void getResponse()
    {
        try
        {
            //string example = "{'Username': 'myusername','Password':'pass'}"; 
            string json = @"{""operationName"":null,""variables"":{},""query"":""{\n asset(uuid: \""3c8ca712-6cf8-4ed1-94bf-4cfc1e89b43e\"") {\n    readings(filter: {types: [\""temperature\"", \""humidity\""]}) {\n      type {\n        name\n      }\n      values(filter: {limit: 1}) {\n        values\n      }\n    }\n  }\n}\n""}";
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
        catch
        {
            throw new System.Exception("some error");
        }






    }


}
