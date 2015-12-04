﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FICTFeed.Bussines.Models
{
    public class Group : Entity
    {
        static Group()
        {
            var shedule = new XmlDocument();
            shedule.LoadXml("<Shedule xmlns:xsi=\"www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"www.w3.org/2001/XMLSchema\"><Weeks><WeekShedule><Days><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule></Days></WeekShedule><WeekShedule><Days><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule></Days></WeekShedule><WeekShedule><Days><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule></Days></WeekShedule><WeekShedule><Days><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule><DayShedule><Lessons><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson><Lesson><Start>0001-01-01T00:00:00</Start><End>0001-01-01T00:00:00</End><Room xsi:nil=\"true\" /></Lesson></Lessons></DayShedule></Days></WeekShedule></Weeks></Shedule>");
            Global = new Group()
            {
                Name = "Global",
                CanBeDeleted = false,
                Users = new List<User>(),
                Shedule = shedule
            };
        }

        public static Group Global;

        public virtual string Name { get; set; }

        public virtual IList<User> Users { get; set; }

        public virtual bool CanBeDeleted { get; set; }

        public virtual XmlDocument Shedule { get; set; }
    }
}
