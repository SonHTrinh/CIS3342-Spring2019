using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Project1
{
    public class calculate
    {
        private double sumQC = 0;
        private double sumQI = 0;
        private double avgQC;
        private double avgQI;
        private ArrayList quesCourse = new ArrayList();
        private ArrayList quesInst = new ArrayList();

        public void calSumQC()
        {
            foreach (int i in quesCourse)
            {
                sumQC = sumQC + i;
            }
        }

        public void calSumQI()
        {
            foreach (int i in quesInst)
            {
                sumQI = sumQI + i;
            }
        }

        public void getAvgQC()
        {
            avgQC = sumQC / quesCourse.Count;
        }

        public void getAvgQI()
        {
            avgQI = sumQI / quesInst.Count;
        }
    }
}