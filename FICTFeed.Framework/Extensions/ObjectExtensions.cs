﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FICTFeed.Framework.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToXmlString(this object obj)
        {
            var xml = string.Empty;
            XmlSerializer xsSubmit = new XmlSerializer(obj.GetType());
            using (StringWriter sww = new StringWriter())
            using (XmlWriter writer = XmlWriter.Create(sww))
            {
                xsSubmit.Serialize(writer, obj);
                xml = sww.ToString();
            }
            return xml;
        }
    }
}
