﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CbIntegrator.Bussynes.Tools
{
    public static class XElementExtensions
    {
        public static DataTable ToDataTable(this XElement element)
        {
            DataSet ds = new DataSet();
            string rawXml = element.ToString();
            ds.ReadXml(new StringReader(rawXml));
            return ds.Tables[0];
        }

        public static DataTable ToDataTable(this IEnumerable<XElement> elements)
        {
            return ToDataTable(new XElement("Root", elements));
        }
    }
}
