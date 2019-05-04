using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Project1
{
    public partial class process : System.Web.UI.Page
    {
        private double sumQC = 0;
        private double sumQI = 0;
        private double avgQC;
        private double avgQI;

        protected void Page_Load(object sender, EventArgs e)
        {
            //student information with the course
            String name = Request["txtName"];
            String email = Request["txtEmail"];
            String id = Request["numID"];
            String course = Request["txtCourse"];

            //create array list to store radio choice value
            ArrayList quesCourse = new ArrayList();
            ArrayList quesInst = new ArrayList();

            //request question for course score value
            quesCourse.Add(System.Convert.ToInt32(Request["qc1"]));
            quesCourse.Add(System.Convert.ToInt32(Request["qc2"]));
            quesCourse.Add(System.Convert.ToInt32(Request["qc3"]));
            quesCourse.Add(System.Convert.ToInt32(Request["qc4"]));
            quesCourse.Add(System.Convert.ToInt32(Request["qc5"]));
            quesCourse.Add(System.Convert.ToInt32(Request["qc6"]));
            quesCourse.Add(System.Convert.ToInt32(Request["qc7"]));
            quesCourse.Add(System.Convert.ToInt32(Request["qc8"]));
            quesCourse.Add(System.Convert.ToInt32(Request["qc9"]));
            quesCourse.Add(System.Convert.ToInt32(Request["qc10"]));
            quesCourse.Add(System.Convert.ToInt32(Request["qc11"]));
            quesCourse.Add(System.Convert.ToInt32(Request["qc12"]));

            //request question for instructor score value
            quesInst.Add(System.Convert.ToInt32(Request["qi1"]));
            quesInst.Add(System.Convert.ToInt32(Request["qi2"]));
            quesInst.Add(System.Convert.ToInt32(Request["qi3"]));
            quesInst.Add(System.Convert.ToInt32(Request["qi4"]));
            quesInst.Add(System.Convert.ToInt32(Request["qi5"]));
            quesInst.Add(System.Convert.ToInt32(Request["qi6"]));
            quesInst.Add(System.Convert.ToInt32(Request["qi7"]));
            quesInst.Add(System.Convert.ToInt32(Request["qi8"]));

            //calculate the sum score
            foreach (int i in quesCourse)
            {
                sumQC = sumQC + i;
            }
            foreach (int i in quesInst)
            {
                sumQI = sumQI + i;
            }

            //calculate the average score
            avgQC = sumQC / quesCourse.Count;
            avgQI = sumQI / quesInst.Count;

            //Letter grade for the course
            string courseGrade;
            if (avgQC > 3.0 && avgQC <= 4.0)
            {
                courseGrade = "A";
            }
            else if (avgQC > 2.0 && avgQC <= 3.0)
            {
                courseGrade = "B";
            }
            else if (avgQC >= 1.0 && avgQC <= 2.0)
            {
                courseGrade = "C";
            }
            else
            {
                courseGrade = "D";
            }

            //letter grade for the instructor
            string instructorGrade;
            if (avgQI > 3.0 && avgQI <= 4.0)
            {
                instructorGrade = "A";
            }
            else if (avgQI > 2.0 && avgQI <= 3.0)
            {
                instructorGrade = "B";
            }
            else if (avgQI >= 1.0 && avgQI <= 2.0)
            {
                instructorGrade = "C";
            }
            else
            {
                instructorGrade = "D";
            }

            //assign course with professor name
            string instructor;
            if (course == "cis3309")
            {
                instructor = "Joe Jupin";
            }
            else if (course == "cis3342")
            {
                instructor = "Christopher Pascuccci";
            }
            else if (course == "cis4296")
            {
                instructor = "Rose McGinnis";
            }
            else
            {
                instructor = "";
            }
            /*switch (course)
            {
                case "cis3309":
                    instructor = "Joe Jupin";
                    break;
                case "cis3342":
                    instructor = "Christopher Pascuccci";
                    break;
                case "cis4296":
                    instructor = "Rose McGinnis";
                    break;
            }*/

            //display the result
            Response.Write("<br /><h3>Thank you " + name + " for submitting the Student Feedback!</h3>");
            Response.Write("Here's the result: <br /><br />");
            Response.Write("Name: " + name + "<br />Email: " + email + "<br />TUid: " + id + "<br />Course: "
                            + course + "<br />Professor: " + instructor + "<br />");
            Response.Write("<br />Course grade: " + courseGrade + " - average score: " + avgQC);
            Response.Write("<br />Instructor grade: " + instructorGrade + " - average score: " + avgQI);
        }
    }
}