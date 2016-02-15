using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;


namespace MAStorageSAS
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("vlecontainer");

            CloudBlobContainer srcContainer = blobClient.GetContainerReference("nesndpvlecms");
            CloudBlobContainer destContainer = blobClient.GetContainerReference("nesndpvlecmsuat");

            
                

            ////container.CreateIfNotExists();

            //////---calls to methods---
            ////// Generate a SAS URI for the container, without a stored access policy.
            ////Console.WriteLine("Container SAS URI: " + GetContainerSasUri(container));
            ////Console.WriteLine();

            ////// Generate a SAS URI for a blob within the container, without a stored access policy.
            ////Console.WriteLine("Blob SAS URI: " + GetBlobSasUri(container));
            ////Console.WriteLine();


            ////BlobContainerPermissions perms = container.GetPermissions();
            ////perms.SharedAccessPolicies.Clear();
            ////container.SetPermissions(perms);

            ////string sharedAccessPolicyName = "testpolicy";
            ////CreateSharedAccessPolicy(blobClient, container, sharedAccessPolicyName);

            //////Generate a SAS URI for the container, using a stored access policy to set constraints on the SAS.
            ////Console.WriteLine("Container SAS URI using stored access policy: " + GetContainerSasUriWithPolicy(container, sharedAccessPolicyName));
            ////Console.WriteLine();

            //////Generate a SAS URI for a blob within the container, using a stored access policy to set constraints on the SAS.
            ////Console.WriteLine("Blob SAS URI using stored access policy: " + GetBlobSasUriWithPolicy(container, sharedAccessPolicyName));
            ////Console.WriteLine();



            CopyBlobs(srcContainer, "", destContainer);



            Console.WriteLine("Done");
            Console.ReadLine();

        }

        static string GetContainerSasUri(CloudBlobContainer container)
        {
            SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy();
            sasConstraints.SharedAccessExpiryTime = DateTime.UtcNow.AddHours(24);
            sasConstraints.Permissions = SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.List;
            string sasContainerToken = container.GetSharedAccessSignature(sasConstraints);
            return container.Uri + sasContainerToken;
        }

        static string GetBlobSasUri(CloudBlobContainer container)
        {
            CloudBlockBlob blob = container.GetBlockBlobReference("test.txt");
            string blobContent = "This blob will be accessible to clients via a SAS";
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(blobContent));
            ms.Position = 0;
            using (ms)
            {
                blob.UploadFromStream(ms);
            }

            SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy();
            sasConstraints.SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-5);
            sasConstraints.SharedAccessExpiryTime = DateTime.UtcNow.AddHours(24);
            sasConstraints.Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write;

            string sasBlobToken = blob.GetSharedAccessSignature(sasConstraints);

            return blob.Uri + sasBlobToken;


        }


        static void CreateSharedAccessPolicy(CloudBlobClient blobClient, CloudBlobContainer container, string policyName)
        {
            SharedAccessBlobPolicy sharedPolicy = new SharedAccessBlobPolicy()
            {
                SharedAccessExpiryTime = DateTime.UtcNow.AddHours(24),
                                            Permissions = SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.List | SharedAccessBlobPermissions.Read
            };

            BlobContainerPermissions permissions = container.GetPermissions();

            permissions.SharedAccessPolicies.Add(policyName, sharedPolicy);
            container.SetPermissions(permissions);


        }

        static string GetContainerSasUriWithPolicy(CloudBlobContainer container, string policyName)
        {
            string sasContainerToken = container.GetSharedAccessSignature(null, policyName);
            return container.Uri + sasContainerToken;

        }

        static string GetBlobSasUriWithPolicy(CloudBlobContainer container, string policyName)
        {
            CloudBlockBlob blob = container.GetBlockBlobReference("test2.txt");

            string blobContent = "This blob will be accessible to clients via a shared acess signature." + "A stored access policy defines the constraints for the signatire";

            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(blobContent));

            ms.Position = 0;
            using (ms)
            {
                blob.UploadFromStream(ms);
            }

            string sasBlobToken = blob.GetSharedAccessSignature(null, policyName);

            return blob.Uri + sasBlobToken;


        }


        public static void CopyBlobs(
                CloudBlobContainer srcContainer,
                string policyId,
                CloudBlobContainer destContainer)
        {
            // get the SAS token to use for all blobs
            string blobToken = srcContainer.GetSharedAccessSignature(
                               new SharedAccessBlobPolicy(), policyId);


            var srcBlobList = srcContainer.ListBlobs(null, false);
            foreach (var src in srcBlobList)
            {
                var srcBlob = src as CloudBlob;

                try {

                    // Create appropriate destination blob type to match the source blob
                    CloudBlob destBlob;
                    if (srcBlob.Properties.BlobType == BlobType.BlockBlob)
                    {
                        destBlob = destContainer.GetBlockBlobReference(srcBlob.Name);
                    }
                    else
                    {
                        destBlob = destContainer.GetPageBlobReference(srcBlob.Name);
                    }

                    // copy using src blob as SAS
                    // destBlob.StartCopyFromBlob(new Uri(srcBlob.Uri.AbsoluteUri + blobToken));

                    destBlob.StartCopy(new Uri(srcBlob.Uri.AbsoluteUri));
                    Console.WriteLine("Copied: " + srcBlob.Uri.AbsoluteUri);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: "  + e.Message);
                }
            }
        }

    }
}
