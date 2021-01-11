using Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Presantation.Interfaces
{
    [ServiceContract] //Bu interface in servis için olduğunu belirten kod.
    public interface IUserService
    {
        [OperationContract] //Method olduğunu belirttiğimiz kısım // POST = Ekleme işlerini yapacağımızı diye anlatabiliriz POST'u.
        [WebInvoke(RequestFormat = WebMessageFormat.Json, Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddUser")]
        //Üst satırda svc dosyasında çalışmasını sağlayan, istek biçiminin json tipinde olduğunu,
        //geri dönüş bildiriminin json tipinde olduğunu, "UriTemplate" : Method'a ulaşırken gireceğimiz adres bilgisi.
        void AddUser(SaveUserDto user);
        [OperationContract] //GET = Okuma işlemi yapacağımızı belirttiğimiz satır.
        [WebInvoke(RequestFormat = WebMessageFormat.Json, Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetUser?userid={userid}")]
        UserDto GetUser(int userid);
        [OperationContract] //PUT : Update işlemini yapacağımızı bir nevi anlattığımız kısım.
        [WebInvoke(RequestFormat =WebMessageFormat.Json, Method ="PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate ="SetUser")]
        string SetUser(SaveUserDto saveUserDto);
        [OperationContract] //DELETE : Silme işlemini yapacağımızı anlattığımız kısım.
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "DELETE", RequestFormat = WebMessageFormat.Json, UriTemplate = "DelUser")]
        string DelUser(UserDto userDto);
    }
}
