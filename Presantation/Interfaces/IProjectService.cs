using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;
using Data.Dto;

namespace Presantation.Interfaces
{
    [ServiceContract] //Bu interface in servis için olduğunu belirten kod.
    public interface IProjectService
    {
        [OperationContract] //Method olduğunu belirttiğimiz kısım 
        [WebInvoke(RequestFormat = WebMessageFormat.Json, Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddProjectRole")]
        //Üst satırda svc dosyasında çalışmasını sağlayan, istek biçiminin json tipinde olduğunu,
        //geri dönüş bildiriminin json tipinde olduğunu, "UriTemplate" : Method'a ulaşırken gireceğimiz adres bilgisi.
        void AddProjectRole(ProjectRoleDto prdto);

        [OperationContract] //POST = Ekleme işlerini yapacağımızı diye anlatabiliriz POST'u.
        [WebInvoke(RequestFormat = WebMessageFormat.Json, Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddProject")]
        void AddProject(ProjectDto project);

        [OperationContract] //GET = Okuma işlemi yapacağımızı belirttiğimiz satır.
        [WebInvoke(RequestFormat = WebMessageFormat.Json, Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetProject?projectid={projectid}")]
        ProjectDto GetProject(int projectid);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetProjectRoles?projectid={projectid}")]
        List<ProjectRoleDto> GetProjectRoles(int projectid);
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SetProject")]
        string SetProject(ProjectDto projectDto);
        [OperationContract] //PUT : Update işlemini yapacağımızı bir nevi anlattığımız kısım.
        [WebInvoke(RequestFormat = WebMessageFormat.Json, Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SetProjectRole")]
        string SetProjectRole(ProjectRoleDto projectRoleDto);
        [OperationContract] //DELETE : Silme işlemini yapacağımızı anlattığımız kısım.
        [WebInvoke(RequestFormat = WebMessageFormat.Json, Method = "DELETE", ResponseFormat = WebMessageFormat.Json, UriTemplate = "DelProject")]
        string DelProject(ProjectDto projectDto);
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Xml, Method = "DELETE", ResponseFormat = WebMessageFormat.Json, UriTemplate = "DelProjectRole")]
        string DelProjectRole(ProjectRoleDto projectRoleDto);
    }
}