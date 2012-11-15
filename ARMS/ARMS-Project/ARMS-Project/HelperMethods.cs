using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Reflection;

namespace ARMS_Project
{
    public class HelperMethods
    {

        public static DataTable ConvertArrayListToDataTable(ArrayList arrayList)
        {
            DataTable dt = new DataTable();

            if (arrayList.Count != 0)
            {
                dt = ConvertObjectToDataTableSchema(arrayList[0]);
                FillData(arrayList, dt);
            }

            return dt;
        }

        public static DataTable ConvertObjectToDataTableSchema(Object o)
        {
            DataTable dt = new DataTable();
            PropertyInfo[] properties = o.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                DataColumn dc = new DataColumn(property.Name);
                dc.DataType = property.PropertyType; dt.Columns.Add(dc);
            }
            return dt;
        }

        private static void FillData(ArrayList arrayList, DataTable dt)
        {
            foreach (Object o in arrayList)
            {
                DataRow dr = dt.NewRow();
                PropertyInfo[] properties = o.GetType().GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    dr[property.Name] = property.GetValue(o, null);
                }
                dt.Rows.Add(dr);
            }
        }

    }
}