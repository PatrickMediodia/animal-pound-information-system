using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PODBProject.Actions
{
    public class PostPhoto
    {
        public String PostPhotoPetOwner(HttpPostedFileBase file)
        {
            PODBProjectEntities entities = new PODBProjectEntities();
            String imagePath = "";
            var path = "";
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    if (Path.GetExtension(file.FileName).ToLower() == ".jpg"
                       || Path.GetExtension(file.FileName).ToLower() == ".png"
                       || Path.GetExtension(file.FileName).ToLower() == ".jpeg")
                    {
                        imagePath = "~/Content/images/PetOwnerProfile/" + file.FileName;
                        path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/images/PetOwnerProfile/"), file.FileName);
                        file.SaveAs(path);
                        entities.Images.Add(new Image()
                        {
                            imagePath = imagePath,
                            imageType = "PetOwnerProfile",
                        });
                        entities.SaveChanges();
                    }
                }
            }
            return imagePath;
        }
        public String PostPhotoPet(HttpPostedFileBase file)
        {
            PODBProjectEntities entities = new PODBProjectEntities();
            String imagePath = "";
            var path = "";
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    if (Path.GetExtension(file.FileName).ToLower() == ".jpg"
                       || Path.GetExtension(file.FileName).ToLower() == ".png"
                       || Path.GetExtension(file.FileName).ToLower() == ".jpeg")
                    {
                        imagePath = "/Content/images/PetProfile/" + file.FileName;
                        path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/images/PetProfile/"), file.FileName);
                        file.SaveAs(path);
                        entities.Images.Add(new Image()
                        {
                            imagePath = imagePath,
                            imageType = "PetProfile",
                        });
                        entities.SaveChanges();
                    }
                }
            }
            return imagePath;
        }
        public String PostPhotoAnnouncement(HttpPostedFileBase file)
        {
            PODBProjectEntities entities = new PODBProjectEntities();
            String imagePath = "";
            var path = "";
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    if (Path.GetExtension(file.FileName).ToLower() == ".jpg"
                       || Path.GetExtension(file.FileName).ToLower() == ".png"
                       || Path.GetExtension(file.FileName).ToLower() == ".jpeg")
                    {
                        imagePath = "/Content/images/Announcement/" + file.FileName;
                        path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/images/Announcement/"), file.FileName);
                        file.SaveAs(path);
                        entities.Images.Add(new Image()
                        {
                            imagePath = imagePath,
                            imageType = "Announcement",
                        });
                        entities.SaveChanges();
                    }
                }
            }
            return imagePath;
        }
    }
}