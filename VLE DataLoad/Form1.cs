using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Transactions;



namespace VLE_DataLoad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Entities en = new Entities();

                        //int i = 2;
           for (int i = 0; i < 3; i++) {


                using (var scope = new TransactionScope())
                {


                    VleResource resource = new VleResource();

                    resource.Title = "Test Project using Loader " + System.Guid.NewGuid() +  " " +  i;
                    resource.Description = "Descriptrion for Test Project using loader " + System.Guid.NewGuid() + " " + i;
                    resource.OwnerId = 2;
                    resource.ContentTypeId = 1;
                    resource.ParentId =  System.Int32.Parse(txtRooNode.Text); //NMAHP = 2
                    resource.IsActive = true;
                    resource.CreatedOn = DateTime.Now;
                    resource.CreatedBy = -1;
                    resource.IsFeatured = true;

                    en.VleResources.Add(resource);

                    en.SaveChanges();

                    int resourceId = resource.Id;

                    // [ContentResource]
                    ContentResource contentResource = new ContentResource();
                    contentResource.Id = resourceId;
                    en.ContentResources.Add(contentResource);
                    en.SaveChanges();

                    // [ProjectResource]
                    ProjectResource projectResource = new ProjectResource();
                    projectResource.Id = resourceId;
                    en.ProjectResources.Add(projectResource);
                    en.SaveChanges();


                    Status status = new Status();
                    status.VleResourceId = resourceId;
                    status.ResourceStatus = 1;
                    status.Date = DateTime.Now;
                    status.User = Guid.NewGuid();
                    en.Status.Add(status);
                    en.SaveChanges();

                    scope.Complete();
                }

            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
