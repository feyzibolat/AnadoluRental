using AnadoluRental.CrossCutting.Concretes.Helper;
using AnadoluRental.CrossCutting.Concretes.Logger;
using AnadoluRental.DataAccess.Concretes;
using AnadoluRental.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnadoluRental.Business
{
    //Bu sınıf verilerimizi bilgiye dönüştürür ve onları müşterinin istediği iş kurallarıyla harmanlayıp Kiralama işlemlerini dış dünyaya açtığımız yerdir. 
    public class KiralikBusiness : IDisposable
    {
        public bool AracKirala(Kiralik kiralik)
        {
            try
            {
                bool isSuccess;
                using (var repo = new KiralikRepository())
                {
                    isSuccess = repo.Insert(kiralik);
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Business:KiralikBusiness::KiralikEkle::Hata Oluştu.", ex);
            }
        }

        public bool KiralikGuncelle(Kiralik kiralik)
        {
            try
            {
                bool isSuccess;
                using (var repo = new KiralikRepository())
                {
                    isSuccess = repo.Update(kiralik);
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Business:KiralikBusiness::KiralikGuncelle::Hata Oluştu.", ex);
            }
        }

        public bool KiralikSilById(int kiralikID)
        {
            try
            {
                bool isSuccess;
                using (var repo = new KiralikRepository())
                {
                    isSuccess = repo.DeletedById(kiralikID);
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Business:KiralikBusiness::KiralikSilById::Hata Oluştu.", ex);
            }
        }

        public Kiralik KiralikSecById(int kiralikID)
        {
            try
            {
                Kiralik secilenKiralik;
                using (var repo = new KiralikRepository())
                {
                    secilenKiralik = repo.SelectedById(kiralikID);
                    if (secilenKiralik == null)
                        throw new NullReferenceException("Girilen KiralikID bulunamadi!");
                }
                return secilenKiralik;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Business:KiralikBusiness::KiralikSecById::Hata Oluştu.", ex);
            }
        }

        public List<Kiralik> SelectAllKiralik()
        {
            var kiralikListesi = new List<Kiralik>();

            try
            {
                using (var repo = new KiralikRepository())
                {
                    foreach (var kiralik in repo.SelectAll())
                    {
                        kiralikListesi.Add(kiralik);
                    }
                }
                return kiralikListesi;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Business:KiralikBusiness::SelectAllKiralik::Hata Oluştu.", ex);
            }
        }

        public KiralikBusiness()
        {
            //Auto-generated Code   
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
