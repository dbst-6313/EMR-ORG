using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Core.Utilities.Constants
{
    public class Messages
    {
        //Answer
        public static string AnswerAdded = "Cevap eklendi";
        public static string StateAccept = "Başvuru durumu:Kabul edildi";
        public static string StateDenied = "Başvuru durumu:Reddedildi";
        public static string AnswerDeleted = "Cevap silindi";
        public static string AnswerListed = "Cevaplar listelendi";
        public static string AnswerUpdated = "Cevaplar güncellendi";

        //Auth
        public static string AuthRegister = "Kullanıcı başarıyla kaydedildi";
        public static string AuthLogin = "Kullanıcı başarıyla giriş yaptı";
        public static string PasswordError = "Şifre hatalı";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        //Question
        public static string QuestionAdded = "Soru eklendi";
        public static string QuestionDeleted = "Soru silindi";
        public static string QuestionListed = "Soruları listelendi";
        public static string QuestionUpdate = "Soru güncellendi";

        //User
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";

    }
}
