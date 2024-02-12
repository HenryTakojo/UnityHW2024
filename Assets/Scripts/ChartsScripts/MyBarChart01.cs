using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts.Runtime;

public class MyBarChart01 : MonoBehaviour
{
    private BarChart barChart01;
    void Start()
    {
        barChart01 = GetComponent<BarChart>();
        var xAxis = barChart01.EnsureChartComponent<XAxis>();
        var serie0 = barChart01.GetSerie<Bar>(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
