﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;

namespace RestSharpDemo
{
    [TestFixture]
    public class UnitTest1
    {
        string[,] values;
        StringBuilder log = new StringBuilder("Console log: UnitTest1");
        String[] statusarr;
        String expath = null;
        string[,] resultss = { { "Test Method", "Test Status", "Percentage", "Failed Validations", "Input Json", "Response" } };
        [OneTimeSetUp]
        public void InitOT()
        {
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string[] path = projectDirectory.Split(new char[] { '\\' });
            Console.Write(projectDirectory + "\n");
            Console.Write(path.Length + "\n");
            for (int n = 0; n < path.Length - 3; n++)
            {
                expath = string.Concat(expath, path[n], "\\");
            }
            Console.Write(expath + "\n");
            values = ReadExcel.getExcelFile(expath, log);
            //log.Append("\nin InitOTR");
            log.Append(expath);
        }
        [OneTimeTearDown]
        public void CleanupOT()
        {
            WriteResultExcel.WriteRes(resultss, expath);
            Console.Write(log);
            System.IO.File.WriteAllText(expath+ @"data\ConsoleLog_UnitTest1"+DateTime.Now.ToString("yyyyMMddHHmmss")+".txt", log.ToString());
        }
        [SetUp]
        public void InitRFEM()
        { statusarr = null; }
        [TearDown]
        public void CleanupRFEM()
        {if (statusarr != null) {
                resultss = ReSizeArray.Addresultrow(resultss, statusarr);
            }
            }
        [Test]
        [Ignore("Ignore Test1")]
        public void TestMethod1()
        {
            string[,] datass = Readcsv.Loadcsv1(expath+@"data\testdata.csv");
            foreach (var item in datass)
            {
                Console.WriteLine(item.ToString());
            }
            StringBuilder resultset = null;
            var client = new RestClient("http://dummy.restapiexample.com/api/");
            var request = new RestRequest("v1/employee/53533", Method.GET);
            //request.AddUrlSegment("postid", 2);
            var response = client.Execute(request);
            int rescode = (int)response.StatusCode;
            Console.Write(response.Content);
            //var deserialize = new JsonDeserializer();
            //var output = deserialize.Deserialize<Dictionary<String, String>>(response);
            //int rescnt = output.Count;
            //var result = output["id"];
            //Assert.That(result, Is.EqualTo("53533"), "ID not correct");
            if (response.Content != "false" && response.StatusCode.Equals(200))
            {
                JObject obs = JObject.Parse(response.Content);
                Assert.That(obs["id"].ToString, Is.EqualTo("53533"), "ID not correct");
                resultset.Append(",Pass");
            }
            else if ((response.Content == "false") && (response.StatusCode.Equals("OK")))
            {
                Console.Write("\nFailure Response");
            }
            else if (rescode == 200)
            {
                Console.Write("\nFailure Response & Wrong ENUM");
            }
        }
        [Test]
        [Ignore("Ignore Test2")]
        public void TestMethod2()
        {
            //string[,] values = ReadExcel.getExcelFile();
            //Console.Write(values[2, 4]);
            string currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Console.Write(currentMethodName);
            //settestdata(currentMethodName);
            //Console.Write("\nMType : " + MType);
            //Console.Write("\nRidentifier : " + Ridentifier);
            //Console.Write("\nRusultToValidate : " + RusultToValidate);
            //Console.Write("\nInputJson : " + InputJson);
            //Console.Write("\nRIdentifier2 : " + RIdentifier2);
            //Console.Write("\nOutputJson : " + OutputJson);

            //--------------------------------------------
            //JObject obs = JObject.Parse(values[2, 4]);
            //Assert.That(obs["question"].ToString, Is.EqualTo("tett"), "Name not correct");
            ////------------------------------------------

            //------------------------------------------------
            //var client = new RestClient("http://dummy.restapiexample.com/api/");
            //var request = new RestRequest("v1/create", Method.POST);
            //request.AddJsonBody(values[2,4]);
            //var rresponse2 = client.Execute(request);
            //Console.Write(rresponse2.Content);
            //-----------------------------------------------
        }
        [Test]
        //[Ignore("Ignore Test3")]
        public void TestMethod3()
        {
            string currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Console.Write(currentMethodName);
            Variables.setdata(currentMethodName, values);
            Console.Write("\nMType : " + Variables.MType);
            Console.Write("\nRidentifier : " + Variables.Ridentifier);
            Console.Write("\nRusultToValidate : " + Variables.RusultToValidate);
            Console.Write("\nInputJson : " + Variables.InputJson);
            Console.Write("\nRIdentifier2 : " + Variables.RIdentifier2);
            Console.Write("\nOutputJson : " + Variables.OutputJson);
            Console.Write("\nmeme : " + Variables.mdata);
        }
        [Test]
        public void TestMethod4()
        {
            string currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Console.Write(currentMethodName);
            Variables.setdata(currentMethodName, values);
            Console.Write("\nMType : " + Variables.MType);
            Console.Write("\nRidentifier : " + Variables.Ridentifier);
            Console.Write("\nRusultToValidate : " + Variables.RusultToValidate);
            Console.Write("\nInputJson : " + Variables.InputJson);
            Console.Write("\nRIdentifier2 : " + Variables.RIdentifier2);
            Console.Write("\nOutputJson : " + Variables.OutputJson);
            Console.Write("\nmeme : " + Variables.mdata);
            String status = "Fail", percent = "49%", failedval = "all", inputjson = Variables.InputJson, response = "201";
            statusarr = new string[]{ currentMethodName, status, percent, failedval, inputjson, response };

        }
        [Test]
        //[Ignore("Ignore Test1")]
        public void TestMethod5()
        {
            string currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Variables.setdata(currentMethodName, values);
            String status = "Pass", percent = "50%", failedval ="nothing", inputjson=Variables.InputJson, response="200";
            statusarr = new string[] {currentMethodName, status, percent, failedval, inputjson, response };
        }

    }
    [TestFixture]
    public class UnitTest3
    {
        string[,] values;
        StringBuilder log = new StringBuilder("Console log: UnitTest1");
        String[] statusarr;
        String expath = null;
        string[,] resultss = { { "Test Method", "Test Status", "Percentage", "Failed Validations", "Input Json", "Response" } };
        [OneTimeSetUp]
        public void InitOT()
        {
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string[] path = projectDirectory.Split(new char[] { '\\' });
            Console.Write(projectDirectory + "\n");
            Console.Write(path.Length + "\n");
            for (int n = 0; n < path.Length - 3; n++)
            {
                expath = string.Concat(expath, path[n], "\\");
            }
            Console.Write(expath + "\n");
            values = ReadExcel.getExcelFile(expath, log);
            //log.Append("\nin InitOTR");
            log.Append(expath);
        }
        [OneTimeTearDown]
        public void CleanupOT()
        {
            WriteResultExcel.WriteRes(resultss, expath);
            Console.Write(log);
            System.IO.File.WriteAllText(expath + @"data\ConsoleLog_UnitTest1" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt", log.ToString());
        }
        [Test]
        public void TestMethod6()
        {
            string currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Variables.setdata(currentMethodName, values);
            if (Variables.mdata != null && Variables.mdata.Equals(currentMethodName))
            {
                String status = "Pass", percent = "50%", failedval = "nothing", inputjson = Variables.InputJson, response = "200";
                statusarr = new string[] { currentMethodName, status, percent, failedval, inputjson, response };
                var client = new RestClient("http://my-json-server.typicode.com/vickynov13/repo/");
                var request = new RestRequest("sales", Method.GET);
                //request.AddUrlSegment("postid", 2);
                var responsetm5 = client.Execute(request);
                //JObject obs = JObject.Parse(responsetm5.Content);
                var deserialize = new JsonDeserializer();
                var output = deserialize.Deserialize<Dictionary<String, String>>(responsetm5);

                int rescode = (int)responsetm5.StatusCode;
                Console.Write(responsetm5.Content);
                Console.Write("Working");
            }
            else
            {
                Console.Write("Data not available for "+ currentMethodName);
            }
        }

    }



    }
