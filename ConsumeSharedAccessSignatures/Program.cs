using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace ConsumeSharedAccessSignatures
{
    class Program
    {
       
        static void Main(string[] args)
        {
            string containerSAS = "https://azure532.blob.core.windows.net/vlecontainer?sv=2015-04-05&sr=c&sig=31DU6lRNJV65BCOXAsv%2F%2Fu0LPiwSWY2mE6gp2h%2BHzTY%3D&se=2015-12-24T13%3A40%3A11Z&sp=wl";
            string blobSAS = "https://azure532.blob.core.windows.net/vlecontainer/test.txt?sv=2015-04-05&sr=b&sig=W%2F5LcVwL3CaQSt5uHOtIWcQAHNoVRlK0X3cFSxovLgM%3D&st=2015-12-23T13%3A35%3A11Z&se=2015-12-24T13%3A40%3A11Z&sp=rw";
            string containerSASWithAccessPolicy = "https://azure532.blob.core.windows.net/vlecontainer?sv=2015-04-05&sr=c&si=testpolicy&sig=2VQ8JH7grFfmJFQUKEOzRHqJOg6vvBHOLNh4nuPSPlE%3D";
            string blobSASWithAccessPolicy = "https://azure532.blob.core.windows.net/vlecontainer/test2.txt?sv=2015-04-05&sr=b&si=testpolicy&sig=uf%2BxxNPUQJ6ERzXRci0VobVmLPRuZc2nh1A2IDbPDKI%3D";

            //Call the test methods with the shared access signatures created on the container, with and without the access policy.
            //UseContainerSAS(containerSAS);
            UseContainerSAS(containerSASWithAccessPolicy);

            //Call the test methods with the shared access signatures created on the blob, with and without the access policy.
            //UseBlobSAS(blobSAS);
            //UseBlobSAS(blobSASWithAccessPolicy);

        }

        static void UseContainerSAS(string sas)
        {
            CloudBlobContainer container = new CloudBlobContainer(new Uri(sas));

            List<ICloudBlob> bloblist = new List<ICloudBlob>();

            try
            {
                CloudBlockBlob blob = container.GetBlockBlobReference("documentation.zip");

                // string blobContent = "This blob was created with a shared access signature granting write permissions to the container. ";

                FileStream fs = File.OpenRead(@"C:\Data\Documents\documentation.zip");

                try {
                    int length = (int)fs.Length;
                    byte[] buffer = new byte[length];
                    int count;
                    int sum = 0;
                    while ((count = fs.Read(buffer, sum, length - sum)) > 0)
                        sum += count;  // sum is a buffer offset for next reading

                    //Encoding.UTF8.GetBytes(blobContent)
                    MemoryStream msWrite = new MemoryStream(buffer);
                    msWrite.Position = 0;
                    using (msWrite)
                    {
                        Console.WriteLine(System.DateTime.Now);
                        blob.UploadFromStream(msWrite);
                        Console.WriteLine(System.DateTime.Now);
                    }
                }
                finally
                {
                    fs.Close();
                }

                ////Encoding.UTF8.GetBytes(blobContent)
                //MemoryStream msWrite = new MemoryStream(buffer);
                //msWrite.Position = 0;
                //using (msWrite)
                //{
                //    blob.UploadFromStream(msWrite);
                //}


                Console.WriteLine("Write operation succeeded for SAS " + sas);
                Console.WriteLine();
                Console.ReadLine();

            }
            catch(StorageException e)
            {
                Console.WriteLine("Write operation failed for SAS " + sas);
                Console.WriteLine("Additional error information: " + e.Message);
                Console.WriteLine();
            }

           
            //List operation: List the blobs in the container.
            try
            {
               
                foreach (ICloudBlob blob in container.ListBlobs())
                {
                    bloblist.Add(blob);
                }
                Console.WriteLine("List operation succeeded for SAS " + sas);
                Console.WriteLine();
            }
            catch (StorageException e)
            {
                Console.WriteLine("List operation failed for SAS " + sas);
                Console.WriteLine("Additional error information: " + e.Message);
                Console.WriteLine();
            }


            //Read operation: Get a reference to one of the blobs in the container and read it. 
            try
            {
                CloudBlockBlob blob = container.GetBlockBlobReference(bloblist[0].Name);
                MemoryStream msRead = new MemoryStream();
                msRead.Position = 0;
                using (msRead)
                {
                    blob.DownloadToStream(msRead);
                    Console.WriteLine(msRead.Length);
                }
                Console.WriteLine("Read operation succeeded for SAS " + sas);
                Console.WriteLine();
            }
            catch (StorageException e)
            {
                Console.WriteLine("Read operation failed for SAS " + sas);
                Console.WriteLine("Additional error information: " + e.Message);
                Console.WriteLine();
            }
            Console.WriteLine();

            //Delete operation: Delete a blob in the container.
            try
            {
                CloudBlockBlob blob = container.GetBlockBlobReference(bloblist[0].Name);
                blob.Delete();
                Console.WriteLine("Delete operation succeeded for SAS " + sas);
                Console.WriteLine();
            }
            catch (StorageException e)
            {
                Console.WriteLine("Delete operation failed for SAS " + sas);
                Console.WriteLine("Additional error information: " + e.Message);
                Console.WriteLine();
            }




        }

        static void UseBlobSAS(string sas)
        {
            //Try performing blob operations using the SAS provided.

            //Return a reference to the blob using the SAS URI.
            CloudBlockBlob blob = new CloudBlockBlob(new Uri(sas));

            //Write operation: Write a new blob to the container. 
            try
            {
                string blobContent = "This blob was created with a shared access signature granting write permissions to the blob. ";
                MemoryStream msWrite = new MemoryStream(Encoding.UTF8.GetBytes(blobContent));
                msWrite.Position = 0;
                using (msWrite)
                {
                    blob.UploadFromStream(msWrite);
                }
                Console.WriteLine("Write operation succeeded for SAS " + sas);
                Console.WriteLine();
            }
            catch (StorageException e)
            {
                Console.WriteLine("Write operation failed for SAS " + sas);
                Console.WriteLine("Additional error information: " + e.Message);
                Console.WriteLine();
            }

            //Read operation: Read the contents of the blob.
            try
            {
                MemoryStream msRead = new MemoryStream();
                using (msRead)
                {
                    blob.DownloadToStream(msRead);
                    msRead.Position = 0;
                    using (StreamReader reader = new StreamReader(msRead, true))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
                Console.WriteLine("Read operation succeeded for SAS " + sas);
                Console.WriteLine();
            }
            catch (StorageException e)
            {
                Console.WriteLine("Read operation failed for SAS " + sas);
                Console.WriteLine("Additional error information: " + e.Message);
                Console.WriteLine();
            }

            //Delete operation: Delete the blob.
            try
            {
                blob.Delete();
                Console.WriteLine("Delete operation succeeded for SAS " + sas);
                Console.WriteLine();
            }
            catch (StorageException e)
            {
                Console.WriteLine("Delete operation failed for SAS " + sas);
                Console.WriteLine("Additional error information: " + e.Message);
                Console.WriteLine();
            }
        }
    }
}
