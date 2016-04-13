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
    public enum TaxonomyMetadataFieldType
    {
        AudienceStaffGroup,
        Type,
        RightsCreativeCommons,
        Format,
        Publisher
    }

    public enum enumVleResourceType
    {
        ProjectResource = 1,
        CurriculumResource = 2,
        EventResource = 3,
        BlobResource = 4,
        ScormResource = 5,
        WebResource = 6,
        ImageResource = 7
    }


    public partial class Loader : Form
    {
        public Loader()
        {
            InitializeComponent();
        }

        private void butLoad_Click(object sender, EventArgs e)
        {

            if (cmbVleResourceType.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a Vle Resource Type");
                cmbVleResourceType.Focus();
            }
            else
            {
                #region MetadataIdLists
                List<int> audiennceStaff = new List<int>();
                audiennceStaff.Add(297861);
                audiennceStaff.Add(297864);
                audiennceStaff.Add(297865);
                audiennceStaff.Add(297866);
                audiennceStaff.Add(297867);
                audiennceStaff.Add(299652);

                List<int> type = new List<int>();
                type.Add(289980);
                type.Add(290156);
                type.Add(290157);
                type.Add(297681);
                type.Add(297861);
                type.Add(297866);
                type.Add(297869);
                #endregion MetadataIdLists

                Random rnd = new Random();

                Entities en = new Entities();

                string title = "";
                string desc = "";
                int totalRecords = Convert.ToInt32(txtTotalRecords.Text);

                progressBarLoader.Minimum = 0;
                progressBarLoader.Maximum = totalRecords;
                progressBarLoader.Step = 1;

                //int i = 2;
                for (int i = 0; i < totalRecords; i++)
                {

                    int pnodeid = rnd.Next(213513);

                    using (elibEntities eliben = new elibEntities())
                    {
                        p_node pNode = eliben.p_node.Find(pnodeid);

                        if (pNode != null)
                        {
                            title = (pNode.title.Length > 250) ? pNode.title.Substring(0, 249) : pNode.title;
                            if (pNode.description != null)
                            {
                                desc = (pNode.description.Length > 250) ? pNode.description.Substring(0, 249) : pNode.description;
                            }
                            else
                            {
                                desc = "Loader Resource " + i;
                            }
                        }
                        else
                        {
                            title = "Loader Resource " + i;
                            desc = "Loader Resource " + i;
                        }


                    }

                    using (var scope = new TransactionScope())
                    {

                        VleResource resource = new VleResource();
                        // elib Id = 213513

                        resource.Title = title;
                        resource.Description = desc;
                        resource.OwnerId = null; // 2;

                        #region AssignResourceType
                        if (cmbVleResourceType.SelectedIndex == 0)
                        {
                            resource.ContentTypeId = Convert.ToInt32(enumVleResourceType.ProjectResource); // 1 = Project; 2 = Curriculum Resource
                        }
                        else if (cmbVleResourceType.SelectedIndex == 1)
                        {
                            resource.ContentTypeId = Convert.ToInt32(enumVleResourceType.CurriculumResource);
                        }
                        else if (cmbVleResourceType.SelectedIndex == 2)
                        {
                            resource.ContentTypeId = Convert.ToInt32(enumVleResourceType.EventResource);
                        }
                        #endregion AssignResourceType

                        resource.ParentId = System.Int32.Parse(txtRootNode.Text); //NMAHP = 2, another, other nodes
                        resource.IsActive = true;
                        resource.CreatedOn = DateTime.Now;
                        resource.CreatedBy = System.Guid.NewGuid();
                        resource.IsFeatured = true;

                        en.VleResources.Add(resource);

                        en.SaveChanges();

                        int resourceId = resource.Id;

                        // [ContentResource]
                        ContentResource contentResource = new ContentResource();
                        contentResource.Id = resourceId;
                        en.ContentResources.Add(contentResource);
                        en.SaveChanges();

                        if (cmbVleResourceType.SelectedIndex == 0)
                        {
                            // [ProjectResource]
                            ProjectResource projectResource = new ProjectResource();
                            projectResource.Id = resourceId;
                            en.ProjectResources.Add(projectResource);
                            en.SaveChanges();
                        }
                        else if (cmbVleResourceType.SelectedIndex == 1)
                        {
                            resource.ContentTypeId = Convert.ToInt32(enumVleResourceType.CurriculumResource);
                            // [CurriculumResource]
                            CurriculumResource curriculumResource = new CurriculumResource();
                            curriculumResource.Id = resourceId;
                            en.CurriculumResources.Add(curriculumResource);
                            en.SaveChanges();
                        }
                        else if (cmbVleResourceType.SelectedIndex == 2)
                        {
                            resource.ContentTypeId = Convert.ToInt32(enumVleResourceType.EventResource);
                            // [CurriculumResource]
                            EventResource eventResource = new EventResource();
                            eventResource.Id = resourceId;
                            en.EventResources.Add(eventResource);
                            en.SaveChanges();
                        }

                        ResourceTaxonomy resourceTaxonomy = new ResourceTaxonomy();
                        resourceTaxonomy.VleResourceId = resourceId;
                        resourceTaxonomy.TaxonomyId = audiennceStaff[rnd.Next(audiennceStaff.Count)];
                        resourceTaxonomy.TaxonomyFieldType = System.Convert.ToInt32(TaxonomyMetadataFieldType.AudienceStaffGroup);
                        en.ResourceTaxonomies.Add(resourceTaxonomy);
                        en.SaveChanges();

                        resourceTaxonomy = new ResourceTaxonomy();
                        resourceTaxonomy.VleResourceId = resourceId;
                        resourceTaxonomy.TaxonomyId = type[rnd.Next(type.Count)];
                        resourceTaxonomy.TaxonomyFieldType = System.Convert.ToInt32(TaxonomyMetadataFieldType.Type);
                        en.ResourceTaxonomies.Add(resourceTaxonomy);
                        en.SaveChanges();

                        // [Status]
                        Status status = new Status();
                        status.VleResourceId = resourceId;
                        status.ResourceStatus = 1;
                        status.Date = DateTime.Now;
                        status.User = Guid.NewGuid();
                        en.Status.Add(status);
                        en.SaveChanges();

                        scope.Complete();
                        progressBarLoader.Value = i+1;
                    }
                }
            }
        }
    }
}

