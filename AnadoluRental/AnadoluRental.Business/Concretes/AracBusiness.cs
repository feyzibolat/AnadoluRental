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
    //Bu sınıf verilerimizi bilgiye dönüştürür ve onları müşterinin istediği iş kurallarıyla harmanlayıp Araç işlemlerini dış dünyaya açtığımız yerdir. 
    public class AracBusiness : IDisposable
    {
        public bool AracEkle(Arac arac)
        {
            try
            {
                bool isSuccess;
                using (var repo = new AracRepository())
                {
                    isSuccess = repo.Insert(arac);
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Business:AracBusiness::AracEkle::Hata Oluştu.", ex);
            }
        }

        public bool AracGuncelle(Arac arac)
        {
            try
            {
                bool isSuccess;
                using (var repo = new AracRepository())
                {
                    isSuccess = repo.Update(arac);
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Business:AracBusiness::AracGuncelle::Hata Oluştu.", ex);
            }
        }

        public bool AracSilById(int aracID)
        {
            try
            {
                bool isSuccess;
                using (var repo = new AracRepository())
                {
                    isSuccess = repo.DeletedById(aracID);
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Business:AracBusiness::AracSilById::Hata Oluştu.", ex);
            }
        }

        public Arac AracSecById(int aracID)
        {
            try
            {
                Arac secilenArac;
                using (var repo = new AracRepository())
                {
                    secilenArac = repo.SelectedById(aracID);
                    if (secilenArac == null)
                        throw new NullReferenceException("Girilen aracID bulunamadi!");
                }
                return secilenArac;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Business:AracBusiness::AracSecById::Hata Oluştu.", ex);
            }
        }

        public List<Arac> SelectAllArac()
        {
            var aracListesi = new List<Arac>();

            try
            {
                using (var repo = new AracRepository())
                {
                    foreach (var arac in repo.SelectAll())
                    {
                        aracListesi.Add(arac);
                    }
                }
                return aracListesi;
            }
            catch (Exception ex)
            {
                //LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Business:AracBusiness::SelectAllArac::Hata Oluştu.", ex);
            }
        }

        public AracBusiness()
        {
            //Auto-generated Code   
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
