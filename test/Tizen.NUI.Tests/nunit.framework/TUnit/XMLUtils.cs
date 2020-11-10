using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace NUnit.Framework.TUnit
{
    public class XMLUtils
    {
        private static string XML_ELEMENT_ENVIRONMENT = "environment";
        private static string XML_ELEMENT_SUITE = "suite";
        private static string XML_ELEMENT_SET = "set";
        private static string XML_ELEMENT_TESTCASE = "testcase";
        private static string XML_ELEMENT_TEST_ONLOAD_DELAY = "onload_delay";
        private static string XML_ELEMENT_RESULT = "result";

        private static string XML_ELEMENT_ACTUAL_RESULT = "actual_result";
        private static string XML_ELEMENT_START = "start";
        private static string XML_ELEMENT_END = "end";
        private static string XML_ELEMENT_STDOUT = "stdout";
        private static string XML_ELEMENT_STDERR = "stderr";


        private static string XML_ATTR_NAME_COMPONENT = "component";
        private static string XML_ATTR_NAME_ELEMENT_EXECUTION_TYPE = "execution_type";
        private static string XML_ATTR_NAME_ELEMENT_ID = "id";
        private static string XML_ATTR_NAME_ELEMENT_PRIORITY = "priority";
        private static string XML_ATTR_NAME_ELEMENT_PURPOSE = "purpose";


        /*XML Reader*/
        private XmlReader reader;

        /* Test Environment */
        private TestcaseEnvironment testcaseEnv;

        /* Suite Value*/
        private TestcaseSuite testcaseSuite;

        /* Suite Value*/
        //private ArrayList tcList;

        private int count;

        private Boolean flag;


        // Instance Constructor
        public XMLUtils()
        {
            reader = null;
            testcaseEnv = new TestcaseEnvironment();
            testcaseSuite = new TestcaseSuite();
            count = 0;
            flag = false;
        }

        private List<TestcaseData> readXML(string path)
        {
            List<TestcaseData> tcList = new List<TestcaseData>();

            reader = null;
            //reader = new XmlReader.Create(path);
            reader = XmlReader.Create(path);

            try
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name == XML_ELEMENT_ENVIRONMENT)
                            {
                                /* TEST ENVIRONMENT */
                                while (reader.MoveToNextAttribute())
                                {
                                    if (reader.Name == "build_id")
                                    {
                                        testcaseEnv.build_id = reader.Value;
                                        //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"ENV build_id : " + testcaseEnv.build_id);
                                    }
                                    else if (reader.Name == "device_id")
                                    {
                                        testcaseEnv.device_id = reader.Value;
                                        //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"ENV device_id : " + testcaseEnv.device_id);
                                    }
                                    else if (reader.Name == "device_model")
                                    {
                                        testcaseEnv.device_model = reader.Value;
                                        //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"ENV device_model : " + testcaseEnv.device_model);
                                    }
                                    else if (reader.Name == "device_name")
                                    {
                                        testcaseEnv.device_name = reader.Value;
                                        //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"ENV device_name : " + testcaseEnv.device_name);
                                    }
                                    else if (reader.Name == "lite_version")
                                    {
                                        testcaseEnv.lite_version = reader.Value;
                                        //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"ENV lite_version : " + testcaseEnv.lite_version);
                                    }
                                    else if (reader.Name == "host")
                                    {
                                        testcaseEnv.host = reader.Value;
                                        //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"ENV host : " + testcaseEnv.host);
                                    }
                                    else if (reader.Name == "manufacturer")
                                    {
                                        testcaseEnv.manufacturer = reader.Value;
                                        //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"ENV manufacturer : " + testcaseEnv.manufacturer);
                                    }
                                    else if (reader.Name == "resolution")
                                    {
                                        testcaseEnv.resolution = reader.Value;
                                        //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"ENV resolution : " + testcaseEnv.resolution);
                                    }
                                    else if (reader.Name == "screen_size")
                                    {
                                        testcaseEnv.screen_size = reader.Value;
                                        //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"ENV screen_size : " + testcaseEnv.screen_size);
                                    }
                                }
                            }
                            /* TEST CASE SUITE */
                            else if (reader.Name == XML_ELEMENT_SUITE)
                            {
                                while (reader.MoveToNextAttribute())
                                {
                                    if (reader.Name == "category")
                                    {
                                        testcaseSuite.suite_category = reader.Value;
                                        //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"SUITE category : " + testcaseSuite.suite_category);
                                    }
                                    else if (reader.Name == "launcher")
                                    {
                                        testcaseSuite.suite_launcher = reader.Value;
                                        //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"SUITE launcher : " + testcaseSuite.suite_launcher);
                                    }
                                    else if (reader.Name == "name")
                                    {
                                        testcaseSuite.suite_name = reader.Value;
                                        //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"SUITE name : " + testcaseSuite.suite_name);
                                    }
                                }
                            }
                            else if (reader.Name == XML_ELEMENT_SET)
                            {
                                reader.MoveToNextAttribute();
                                if (reader.Name == "name")
                                {
                                    testcaseSuite.set_name = reader.Value;
                                    //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"SET name : " + testcaseSuite.set_name);
                                }
                            }
                            /* TEST CASE READ */
                            else if (reader.Name == XML_ELEMENT_TESTCASE)
                            {
                                TestcaseData tmp = new TestcaseData();
                                // add in arrayList 
                                tcList.Add(tmp);
                                //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"CASE ARY ADD *****************************");
                                while (reader.MoveToNextAttribute())
                                {
                                    if (reader.Name == XML_ATTR_NAME_COMPONENT)
                                    {
                                        ((TestcaseData)tcList[count]).component = reader.Value;
                                        //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"        CASE component : " + reader.Value);
                                    }
                                    else if (reader.Name == XML_ATTR_NAME_ELEMENT_EXECUTION_TYPE)
                                    {
                                        ((TestcaseData)tcList[count]).execution_type = reader.Value;
                                        //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"        CASE execution : " + reader.Value);
                                    }
                                    else if (reader.Name == XML_ATTR_NAME_ELEMENT_ID)
                                    {
                                        ((TestcaseData)tcList[count]).id = reader.Value;
                                        //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"        CASE ID : " + reader.Value);

                                    }
                                    else if (reader.Name == XML_ATTR_NAME_ELEMENT_PRIORITY)
                                    {
                                        ((TestcaseData)tcList[count]).priority = reader.Value;
                                        //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"        CASE priority : " + reader.Value);
                                    }
                                    else if (reader.Name == XML_ATTR_NAME_ELEMENT_PURPOSE)
                                    {
                                        ((TestcaseData)tcList[count]).purpose = reader.Value;
                                        //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"        CASE purpose : " + reader.Value);
                                    }
                                    else if (reader.Name == XML_ELEMENT_RESULT)
                                    {
                                        ((TestcaseData)tcList[count]).result = reader.Value;
                                        //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"        CASE result : " + reader.Value);
                                    }

                                    else if (reader.Name == XML_ELEMENT_TEST_ONLOAD_DELAY)
                                    {
                                        ((TestcaseData)tcList[count]).onloaddelay = reader.Value;
                                        //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"        CASE onloaddelay : " + reader.Value);
                                    }
                                }
                            }

                            /* Description */
                            else if (reader.Name == "description")
                            {
                                while (reader.NodeType != XmlNodeType.Text && reader.NodeType != XmlNodeType.EndElement)
                                    reader.Read();

                                ((TestcaseData)tcList[count]).test_script_entry = reader.Value;
                                //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"        CASE test_script_entry : " + reader.Value);
                            }
                            /* TEST CASE READ */
                            else if (reader.Name == "result_info")
                            {
                                flag = true;
                                while (flag)
                                {
                                    reader.Read();
                                    if (reader.NodeType == XmlNodeType.Element)
                                    {
                                        if (reader.Name == XML_ELEMENT_ACTUAL_RESULT)
                                        {
                                            while (reader.NodeType != XmlNodeType.Text && reader.NodeType != XmlNodeType.EndElement)
                                                reader.Read();

                                            ((TestcaseData)tcList[count]).actual_result = reader.Value;
                                            //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"        CASE actual_result : " + reader.Value);
                                        }
                                        else if (reader.Name == XML_ELEMENT_START)
                                        {
                                            while (reader.NodeType != XmlNodeType.Text && reader.NodeType != XmlNodeType.EndElement)
                                                reader.Read();

                                            ((TestcaseData)tcList[count]).start = reader.Value;
                                            //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"        CASE start : " + reader.Value);
                                        }
                                        else if (reader.Name == XML_ELEMENT_END)
                                        {
                                            while (reader.NodeType != XmlNodeType.Text && reader.NodeType != XmlNodeType.EndElement)
                                                reader.Read();

                                            ((TestcaseData)tcList[count]).end = reader.Value;
                                            //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"        CASE end : " + reader.Value);
                                        }
                                        else if (reader.Name == XML_ELEMENT_STDOUT)
                                        {
                                            while (reader.NodeType != XmlNodeType.Text && reader.NodeType != XmlNodeType.EndElement)
                                                reader.Read();

                                            ((TestcaseData)tcList[count]).stdout = reader.Value;
                                            //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"        CASE stdout : " + reader.Value);
                                        }
                                        else if (reader.Name == XML_ELEMENT_STDERR)
                                        {
                                            while (reader.NodeType != XmlNodeType.Text && reader.NodeType != XmlNodeType.EndElement)
                                                reader.Read();

                                            ((TestcaseData)tcList[count]).stderr = reader.Value;
                                            //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"        CASE stderr : " + reader.Value);
                                        }
                                    }
                                    if (reader.NodeType == XmlNodeType.EndElement)
                                    {
                                        if (reader.Name == "result_info")
                                        {
                                            flag = false;
                                        }
                                    }
                                }
                            }
                            break;
                        case XmlNodeType.Text:
                            //if (reader.Name == XML_ELEMENT_TEST_SCRIPT_ENTRY)
                            //{
                            //((TestcaseData)tcList[count]).test_script_expected_result = reader.Value;
                            ////LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"        CASE test_script_entry : " + reader.Value);
                            ////LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,"CASE ARY END ***************************** ");
                            //}
                            break;
                        case XmlNodeType.EndElement:
                            flag = false;
                            if (reader.Name == "testcase")
                            {
                                //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ," ***************************** END ***************************** ");
                                count++;
                            }
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                LogUtils.Write(LogUtils.ERROR, LogUtils.TAG, "ERROR : " + e.Message);
            }

            reader.Dispose();

            return tcList;
        }

        public String[] getTestIdList(string path)
        {
            List<string> res = new List<string>();
            List<TestcaseData> tcList;

            try
            {
                tcList = readXML(path);
                foreach (TestcaseData data in tcList)
                {
                    res.Add(data.id);
                }
            }
            catch (Exception e)
            {
                LogUtils.Write(LogUtils.ERROR, LogUtils.TAG, "ERROR : " + e.Message);
            }
            return (string[])res.ToArray<string>();
        }

        public String[] getFailList(string path)
        {

            List<string> res = new List<string>();
            List<TestcaseData> tcList;

            try
            {
                tcList = readXML(path);
                foreach (TestcaseData data in tcList)
                {
                    if (data.result == "FAIL")
                    {
                        res.Add(data.id);
                        //LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG ,data.id);
                    }
                }
            }
            catch (Exception e)
            {
                LogUtils.Write(LogUtils.ERROR, LogUtils.TAG, "ERROR : " + e.Message);
            }

            return (string[])res.ToArray<string>();
        }

        public void writeResult(String path, String fileName, TestcaseEnvironment testEnv, List<TestcaseData> list)
        {
            try
            {
                FileStream fs = new FileStream(path + fileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);

                XmlWriter xmlWriter = XmlWriter.Create(sw);
                xmlWriter.WriteStartDocument();

                xmlWriter.WriteStartElement("test_definition");

                xmlWriter.WriteStartElement("suite");
                xmlWriter.WriteAttributeString("category", "");
                xmlWriter.WriteAttributeString("extension", "");
                xmlWriter.WriteAttributeString("name", "");

                xmlWriter.WriteStartElement("set");
                xmlWriter.WriteAttributeString("name", "C#");
                xmlWriter.WriteAttributeString("set_debug_msg", "N/A");
                xmlWriter.WriteAttributeString("type", "js");

                /* MAKE TESTCASE */
                foreach (TestcaseData data in list)
                {

                    xmlWriter.WriteStartElement("testcase");
                    xmlWriter.WriteAttributeString("component", data.component);
                    xmlWriter.WriteAttributeString("execution_type", data.execution_type);
                    xmlWriter.WriteAttributeString("id", data.id);
                    xmlWriter.WriteAttributeString("priority", data.priority);
                    xmlWriter.WriteAttributeString("purpose", data.purpose);
                    xmlWriter.WriteAttributeString("onload_delay", data.onloaddelay);
                    xmlWriter.WriteAttributeString("result", data.result);

                    /*
                    <description>
                        <test_script_entry>/opt/tct-messaging-mms-tizen-tests/messaging/MessageBody_mms_extend.html</test_script_entry>
                    </description>
                    */
                    xmlWriter.WriteStartElement("description");
                    xmlWriter.WriteStartElement("test_script_entry");
                    xmlWriter.WriteString(data.test_script_entry);
                    xmlWriter.WriteEndElement(); // close test_script_entry
                    xmlWriter.WriteEndElement(); // close description

                    /*
                    <result_info>
                        <actual_result>PASS</actual_result>
                        <start>2016-04-01 16:53:06</start>
                        <end>2016-04-01 16:53:07</end>
                        <stdout>[Message]</stdout>
                        <stderr />
                    </result_info>
                    */
                    xmlWriter.WriteStartElement("result_info");

                    xmlWriter.WriteStartElement("actual_result");
                    xmlWriter.WriteString(data.actual_result);
                    xmlWriter.WriteEndElement(); // end of atcual_result

                    xmlWriter.WriteStartElement("start");
                    xmlWriter.WriteString(data.start);
                    xmlWriter.WriteEndElement(); // end of start

                    xmlWriter.WriteStartElement("end");
                    xmlWriter.WriteString(data.end);
                    xmlWriter.WriteEndElement(); // end of end

                    xmlWriter.WriteStartElement("stdout");
                    xmlWriter.WriteString(data.stdout);
                    xmlWriter.WriteEndElement(); // end of stdout

                    xmlWriter.WriteStartElement("stderr");
                    xmlWriter.WriteString(data.stderr);
                    xmlWriter.WriteEndElement(); // end of stderr

                    xmlWriter.WriteEndElement(); // end of resultinfo


                    xmlWriter.WriteEndElement(); // end of testcase
                }
                xmlWriter.WriteEndElement(); // end of set
                xmlWriter.WriteEndElement(); // end of suite

                xmlWriter.WriteEndDocument();

                xmlWriter.Dispose();

                sw.Dispose();
                fs.Dispose();
            }
            catch (Exception e)
            {
                LogUtils.Write(LogUtils.ERROR, LogUtils.TAG, "ERROR :: : " + e.Message);
            }
        }
        
        /*
            @fileName : fileName of summary XML
            @path : path of  summary XML
            @list : SummaryData object list
        */
        public void writeSummary(String path, String fileName, List<SummaryData> list)
        {
            FileStream fs = new FileStream(path + fileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            XmlWriter xmlWriter = XmlWriter.Create(sw);
            xmlWriter.WriteStartDocument();

            xmlWriter.WriteStartElement("result_summary");
            xmlWriter.WriteAttributeString("plan_name", "temp");
            

            /*
            <environment 
            build_id ="" 
                tct_version,"TCT_3.0" 
                tct_profile,"mobile" 
                device_id,"0000d85b00006200" 
                device_model,"" 
                device_name,"localhost  " 
                host,"Linux-3.13.0-83-generic-x86_64-with-Ubuntu-12.04-precise" 
                resolution,"" 
                screen_size,"" 
                manufacturer,"">
            */

            xmlWriter.WriteStartElement("environment");
            xmlWriter.WriteAttributeString("build_id", "");
            xmlWriter.WriteAttributeString("tct_version", "TCT_3.0");
            xmlWriter.WriteAttributeString("tct_profile", "mobile");
            xmlWriter.WriteAttributeString("device_id", "0000d85b00006200");
            xmlWriter.WriteAttributeString("device_model", "");
            xmlWriter.WriteAttributeString("device_name", "localhost");
            xmlWriter.WriteAttributeString("host", "Linux -3.13.0-83-generic-x86_64-with-Ubuntu-12.04-precise");
            xmlWriter.WriteAttributeString("resolution", "");
            xmlWriter.WriteAttributeString("screen_size", "");
            xmlWriter.WriteAttributeString("manufacturer", "");


            //<other xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:type="xs:string" />
            xmlWriter.WriteStartElement("other");
            //string attr = "xmlns:xs";
            //xmlWriter.WriteAttributeString(attr, "http://www.w3.org/2001/XMLSchema");
            //xmlWriter.WriteAttributeString(attr, "http://www.w3.org/2001/XMLSchema-instance");
            //xmlWriter.WriteAttributeString("xsi:type", "xs:string");
            xmlWriter.WriteEndElement(); // close other

            xmlWriter.WriteEndElement(); // close environment


            /*
              <summary test_plan_name = "Empty test_plan_name" >
                < start_at > 2016 - 04 - 08_18_37_38 </ start_at >
                < end_at > 2016 - 04 - 08_18_38_07 </ end_at >
              </ summary >
            */
            xmlWriter.WriteStartElement("summary");
            xmlWriter.WriteAttributeString("test_plan_name", "Empty test_plan_name");

            xmlWriter.WriteStartElement("start_at");
            xmlWriter.WriteString("2016-04-20_18_37_38");
            xmlWriter.WriteEndElement();  // close start_at

            xmlWriter.WriteStartElement("end_at");
            xmlWriter.WriteString("2016 - 04 - 08_18_38_07");
            xmlWriter.WriteEndElement();  // close end_at

            xmlWriter.WriteEndElement();  // close summary


            /*
                < suite name = "tct-fullscreen-nonw3c-tests" >
                    < total_case > 13 </ total_case >
                    < pass_case > 13 </ pass_case >
                    < pass_rate > 100.00 </ pass_rate >
                    < fail_case > 0 </ fail_case >
                    < fail_rate > 0.00 </ fail_rate >
                    < block_case > 0 </ block_case >
                    < block_rate > 0.00 </ block_rate >
                    < na_case > 0 </ na_case >
                    < na_rate > 0.00 </ na_rate >
                </ suite >
            */

            foreach (SummaryData data in list)
            {
                xmlWriter.WriteStartElement("suite");
                xmlWriter.WriteAttributeString("name", data.suiteName);


                xmlWriter.WriteStartElement("total_case");
                xmlWriter.WriteString(data.totalCase+"");
                xmlWriter.WriteEndElement();//  end of total_case

                xmlWriter.WriteStartElement("pass_case");
                xmlWriter.WriteString(data.passCase + "");
                xmlWriter.WriteEndElement();//  end of pass_case

                xmlWriter.WriteStartElement("pass_rate");
                xmlWriter.WriteString(data.passRate + "");
                xmlWriter.WriteEndElement();//  end of pass_rate

                xmlWriter.WriteStartElement("fail_case");
                xmlWriter.WriteString(data.failCase + "");
                xmlWriter.WriteEndElement();//  end of fail_case

                xmlWriter.WriteStartElement("fail_rate");
                xmlWriter.WriteString(data.failRate + "");
                xmlWriter.WriteEndElement();//  end of fail_rate

                xmlWriter.WriteStartElement("block_case");
                xmlWriter.WriteString(data.blockCase + "");
                xmlWriter.WriteEndElement();//  end of block_case

                xmlWriter.WriteStartElement("block_rate");
                xmlWriter.WriteString(data.blockRate + "");
                xmlWriter.WriteEndElement();//  end of block_rate

                xmlWriter.WriteStartElement("na_case");
                xmlWriter.WriteString(data.naCase + "");
                xmlWriter.WriteEndElement(); //  end of na_case

                xmlWriter.WriteStartElement("na_rate");
                xmlWriter.WriteString(data.naRate + "");
                xmlWriter.WriteEndElement();//  end of na_reate

                xmlWriter.WriteEndElement(); //  end of suite

            }

            xmlWriter.WriteEndDocument(); //  end of document

            xmlWriter.Dispose();


            sw.Dispose();
            fs.Dispose();
        }
    }


    /* Testcase Data */
    public class TestcaseData
    {
        /* testcase value */
        public String component { get; set; }
        public String execution_type { get; set; }
        public String id { get; set; }
        public String priority { get; set; }
        public String onloaddelay { get; set; }
        public String purpose { get; set; }
        public String test_script_entry { get; set; }
        public String result { get; set; }

        public String actual_result { get; set; }
        public String start { get; set; }
        public String end { get; set; }
        public String stdout { get; set; }
        public String stderr { get; set; }

        public TestcaseData()
        {
            component = "";
            execution_type = "";
            id = "";
            priority = "";
            purpose = "";
            purpose = "";
            test_script_entry = "";
            onloaddelay = "";
            result = "";

            actual_result = "";
            start = "";
            end = "";
            stdout = "";
            stderr = "";
        }
    }

    /* TestcaseSuite Data */
    public class TestcaseSuite
    {
        /*
          <suite category = "W3C/HTML5 APIs" 
                launcher="WRTLauncher" name="tct-3dtransforms-css3-tests">
            <set name = "3DTransforms" >
        */
        public String suite_category { get; set; }
        public String suite_launcher { get; set; }
        public String suite_name { get; set; }
        public String set_name { get; set; }

        public TestcaseSuite()
        {
            suite_category = "";
            suite_launcher = "";
            suite_name = "";
            set_name = "";
        }

    }

    /* TestcaseEnvironment Data */
    public class TestcaseEnvironment
    {
        /*
          <suite category = "W3C/HTML5 APIs" 
                launcher="WRTLauncher" name="tct-3dtransforms-css3-tests">
            <set name = "3DTransforms" >
        */
        public String build_id { get; set; }
        public String device_id { get; set; }
        public String device_model { get; set; }
        public String device_name { get; set; }

        public String host { get; set; }
        public String lite_version { get; set; }
        public String manufacturer { get; set; }
        public String resolution { get; set; }
        public String screen_size { get; set; }

        public TestcaseEnvironment()
        {
            build_id = "";
            device_id = "";
            device_model = "";
            device_name = "";
            device_name = "";

            host = "";
            lite_version = "";
            manufacturer = "";
            resolution = "";
            screen_size = "";
        }
    }

    /* Summary Data */
    public class SummaryData
    {
        public int totalCase { get; set; }
        public int passCase { get; set; }
        public int passRate { get; set; }
        public int failCase { get; set; }
        public int failRate { get; set; }
        public int blockCase { get; set; }
        public int blockRate { get; set; }
        public int naCase { get; set; }
        public int naRate { get; set; }

        public string suiteName { get; set; }

        public SummaryData()
        {
            totalCase = 0;
            passCase = 0;
            passRate = 0;
            failCase = 0;
            failRate = 0;
            blockCase = 0;
            blockRate = 0;
            naCase = 0;
            naRate = 0;
            suiteName = "";
        }
    }
}
