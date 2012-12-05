using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Reflection;
using Org.BouncyCastle.Asn1.Ocsp;
using Amazon.S3;
using Amazon.S3.Model;
using System.IO;

namespace ARMS_Project
{
    public class HelperMethods
    {

        public static String UploadToS3(string fileName, Stream fileContent)
        {
            if (String.IsNullOrEmpty(fileName))
            {
                return "";
            }

            AmazonS3 s3Client = Amazon.AWSClientFactory.CreateAmazonS3Client("AKIAJ4A6DAATIDU6ELAA", "EiA6EILkCp7pqzvnIUhXg3FFOft0j+pA/DtBM8if");

            PutObjectRequest putObjectRequest = new PutObjectRequest();
            putObjectRequest.WithBucketName("shriners_rms");
            putObjectRequest.CannedACL = S3CannedACL.PublicRead;
            putObjectRequest.Key = fileName;
            putObjectRequest.InputStream = fileContent;
            S3Response response = s3Client.PutObject(putObjectRequest);
            response.Dispose();

            return "http://shriners_rms.s3.amazonaws.com/" + fileName;
        }

        public bool UploadFileToS3(string uploadAsFileName, Stream ImageStream, S3CannedACL filePermission, S3StorageClass storageType)
        {
            try
            {
                AmazonS3 client = Amazon.AWSClientFactory.CreateAmazonS3Client("AKIAJ4A6DAATIDU6ELAA", "EiA6EILkCp7pqzvnIUhXg3FFOft0j+pA/DtBM8if");
                PutObjectRequest request = new PutObjectRequest();
                request.WithKey( "folder" + "/" + uploadAsFileName );
                request.WithInputStream(ImageStream);
                request.WithBucketName("shriners_rms");
                request.CannedACL = filePermission;
                request.StorageClass = storageType;

                client.PutObject(request);
                client.Dispose();
            }
            catch
            {            
                return false;
            }
            return true;
        }

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