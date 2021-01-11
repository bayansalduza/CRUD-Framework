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
    public class UserService : IUserService
    {
        public void AddUser(SaveUserDto user) //AddUser adlı methodun gövdesi.
        {
            using (UnitOfWorkPattern unitof = new UnitOfWorkPattern()) //Using kullanma amacımız; işimiz bittiğinde 
            {//belleği serbest bırakıp kodumuzu standarta yakın yazmamız.
                user users = new user() //.edmx 'den oluşturduğumuz user ı SaveUserDto dan aldığımız ile dolduruyoruz.
                {
                    name = user.Name,
                    username = user.UserName,
                    id = user.Id
                };
                unitof.RepositoryPattern<user>().Add(users); //UnitOfWork ile Repository'e ulaştık ve Add methodumuza ulaştık.
                unitof.Save(); //Aynı şekilde save methodumuza ulaştık
            }
        }

        public string DelUser(UserDto userDto)
        {
            using (UnitOfWorkPattern unitOf = new UnitOfWorkPattern())
            {
                user us = unitOf.RepositoryPattern<user>().Get(userDto.Id); //Id ile eşleşen user tipinde dönen veri
                if (us != null) //eğer yukarıdaki satırda uygun eşleşme bulunamazsa delete işlemi yapılmaz. Else satırına düşer.
                {
                    unitOf.RepositoryPattern<user>().Delete(us);
                    unitOf.Save();
                    return "Kayıt silindi";
                }
                else //Delete işlemi yapılmazsa geriye döndürdüğü string mesaj.
                    return "Silmek istediğiniz kayıt bulunamadı";
            }
        }

        public UserDto GetUser(int userid)
        {
            using (UnitOfWorkPattern unitof = new UnitOfWorkPattern())
            {
                user us = unitof.RepositoryPattern<user>().Get(userid); //"userid" eşleşmesi durumunda user dönen bilgiler ile dolacak.
                UserDto userDto = new UserDto(); //Bir geri dönüş gelmezse tüm bilgiler boş döner.
                userDto.Id = us.id;
                userDto.Name = us.name;
                userDto.UserName = us.username;
                return userDto;
            }
        }

        public string SetUser(SaveUserDto saveUserDto) 
        {
            using (UnitOfWorkPattern unitOf = new UnitOfWorkPattern())
            {
                user us = unitOf.RepositoryPattern<user>().Get(saveUserDto.Id);
                if (us != null) //Get işlemi null döndermedi ise güncelleme işlemi yapılır.
                {
                    try //Herhangi bir hata olursa catch satırında uyarı verilecek.
                    {
                        us.name = saveUserDto.Name;
                        us.username = saveUserDto.UserName;
                        unitOf.RepositoryPattern<user>().Update(us); //Update işlemi yaptığımız kısım.
                        unitOf.Save();
                        return "Kayıt güncellendi"; //Bilgilendirme ekranı.
                    }
                    catch
                    {
                        return "Kayıt güncellenirken hata oluştu";//Catch'e düşmesi halinde dönecek mesaj.
                    }
                }
                else
                {
                    return "Kayıtlı kullanıcı bulunamadı"; //Aldığımız SaveUserDto eşleşmez ise dönecek mesaj.
                }
            }
        }
    }
}