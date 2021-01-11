using Data.Dto;
using Presantation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.UnitOfWorkPattern;
using Data.Database;

namespace Presantation.Services
{
    public class ProjectService : IProjectService
    {
        public void AddProject(ProjectDto project)
        {
            using (UnitOfWorkPattern unitof = new UnitOfWorkPattern())//Using kullanma amacımız; işimiz bittiğinde 
            {//belleği serbest bırakıp kodumuzu standarta yakın yazmamız. 
                project proj = new project() // edmx datasınının project classından nesne oluşturup ProjectDto'dan
                {//aldığımız bilgileri DataBase'e kayıt ediyoruz.
                    id = project.Id,
                    name = project.ProjectName
                }; ;
                unitof.RepositoryPattern<project>().Add(proj);//Ekleme işlemi.
                unitof.Save();//Kayıt işlemi.
            }
        }

        public void AddProjectRole(ProjectRoleDto prdto) //ProjectRole eklemeyi sağlayan servis. Parametre olarak ProjectDto alır.
        {
            using (UnitOfWorkPattern unitOf = new UnitOfWorkPattern())
            {
                projectrole prol = new projectrole() //Yukarıdaki işlemin aynısını uyguladık.
                {
                    userid = prdto.UserId,
                    projectid = prdto.ProjectId
                };
                unitOf.RepositoryPattern<projectrole>().Add(prol);
                unitOf.Save();
            }
        }

        public string DelProject(ProjectDto projectDto) //Aldığı projectDto yla eşleşen projeyi silen servis.
        {
            using (UnitOfWorkPattern unitOf = new UnitOfWorkPattern())
            {
                project pr = unitOf.RepositoryPattern<project>().Get(projectDto.Id);// Id ile eşleşen project tipinde dönen veri
                if (pr != null) //eğer yukarıdaki satırda uygun eşleşme bulunamazsa delete işlemi yapılmaz.Else satırına düşer.
                {
                    unitOf.RepositoryPattern<project>().Delete(pr); //Delete işlemi.
                    unitOf.Save(); //Delete işlemi kayıt kısmı.
                    return "Kayıt silindi"; 
                }
                else
                    return "Kayıt bulunamadı"; 
            }
        }

        public string DelProjectRole(ProjectRoleDto projectRoleDto) //ProjectRoleDto alıp delete işlemi uygulayan servis.
        {
            using (UnitOfWorkPattern unitOf = new UnitOfWorkPattern())
            {
                projectrole prol = unitOf.RepositoryPattern<projectrole>().Get(projectRoleDto.Id);
                if (prol != null)
                {
                    unitOf.RepositoryPattern<projectrole>().Delete(prol);
                    unitOf.Save();
                    return "Kayıt silindi";
                }
                else
                    return "Kayıt bulunamadı";
            }
        }
        public ProjectDto GetProject(int projectid) //Aldığı id ye göre proje bilgilerini getiren servis.
        {
            using (UnitOfWorkPattern unitOf = new UnitOfWorkPattern())
            {
                project proj = unitOf.RepositoryPattern<project>().Get(projectid);
                ProjectDto projectDto = new ProjectDto()
                {
                    Id = proj.id,
                    ProjectName = proj.name
                };
                return projectDto;
            }
        }

        public List<ProjectRoleDto> GetProjectRoles(int projectid) //Aldığı projectid ye göre proje,user,projectrole'e
        {//join işlemi yapıp. Projede hangi çalışanlar olduğunu gösteren kod.
            using (UnitOfWorkPattern unitOf = new UnitOfWorkPattern())
            {

                dataEntities _context = new dataEntities();
                List<ProjectRoleDto> rolesDtosLi = (from prol in _context.projectroles
                                                    join us in _context.users on prol.userid equals us.id
                                                    join proj in _context.projects on prol.projectid equals proj.id
                                                    where prol.projectid == projectid
                                                    select new ProjectRoleDto
                                                    {
                                                        UserName = us.username,
                                                        UserId = us.id,
                                                        ProjectId = proj.id,
                                                        ProjectName = proj.name,
                                                        Id = prol.id
                                                    }
                    ).ToList();
                return rolesDtosLi;
            }
        }

        public string SetProject(ProjectDto projectDto) //Proje'yi update etmeye yarayan kod.
        {
            using (UnitOfWorkPattern unitOf = new UnitOfWorkPattern())
            {
                var project = unitOf.RepositoryPattern<project>().Get(projectDto.Id);
                if (project != null)
                {
                    try
                    {
                        project.name = projectDto.ProjectName;
                        unitOf.RepositoryPattern<project>().Update(project);
                        unitOf.Save();
                        return "Kayıt güncellendi";
                    }
                    catch
                    {
                        return "Güncellerken bir hata oluştu";
                    }
                }
                else
                    return "Kayıt bulunamadı";
            }
        }

        public string SetProjectRole(ProjectRoleDto projectRoleDto) //Projectrole'ü update etmeye yarayan kod.
        {
            using (UnitOfWorkPattern unitOf = new UnitOfWorkPattern())
            {
                projectrole prole = unitOf.RepositoryPattern<projectrole>().Get(projectRoleDto.Id);
                if (prole != null)
                {
                    try
                    {
                        prole.projectid = projectRoleDto.ProjectId;
                        prole.userid = projectRoleDto.UserId;
                        unitOf.RepositoryPattern<projectrole>().Update(prole);
                        unitOf.Save();
                        return "Kayıt güncellendi";
                    }
                    catch
                    {

                        return "Güncellerken bir hata oluştu";
                    }
                }
                else
                {
                    return "Kayıt bulunamadı";
                }

            }
        }
    }
}