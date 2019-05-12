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
    //Bu sınıf verilerimizi bilgiye dönüştürür ve onları müşterinin istediği iş kurallarıyla harmanlayıp Kullanıcı işlemlerini dış dünyaya açtığımız yerdir. 
    public class KullaniciBusiness : IDisposable
    {
        public bool KullaniciEkle(Kullanici kull)
        {
            try
            {
                bool isSuccess;
                using (var repo = new KullaniciRepository())
                {
                    isSuccess = repo.Insert(kull);
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Business:KullaniciBusiness::KullaniciEkle::Hata Oluştu.", ex);
            }
        }

        public bool KullaniciGuncelle(Kullanici kull)
        {
            try
            {
                bool isSuccess;
                using (var repo = new KullaniciRepository())
                {
                    isSuccess = repo.Update(kull);
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Business:KullaniciBusiness::KullaniciGuncelle::Hata Oluştu.", ex);
            }
        }

        public bool KullaniciSilById(int kullID)
        {
            try
            {
                bool isSuccess;
                using (var repo = new KullaniciRepository())
                {
                    isSuccess = repo.DeletedById(kullID);
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Business:KullaniciBusiness::KullaniciSilById::Hata Oluştu.", ex);
            }
        }

        public Kullanici KullaniciSecById(int kullID)
        {
            try
            {
                Kullanici secilenKullanici;
                using (var repo = new KullaniciRepository())
                {
                    secilenKullanici = repo.SelectedById(kullID);
                    if (secilenKullanici == null)
                        throw new NullReferenceException("Girilen KullaniciID bulunamadi!");
                }
                return secilenKullanici;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Business:KullaniciBusiness::KullaniciSecById::Hata Oluştu.", ex);
            }
        }

        public List<Kullanici> SelectAllKullanici()
        {
            var kullaniciListesi = new List<Kullanici>();

            try
            {
                using (var repo = new KullaniciRepository())
                {
                    foreach (var kull in repo.SelectAll())
                    {
                        kullaniciListesi.Add(kull);
                    }
                }
                return kullaniciListesi;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Business:KullaniciBusiness::SelectAllKullanici::Hata Oluştu.", ex);
            }
        }

        public KullaniciBusiness()
        {
            //Auto-generated Code   
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
