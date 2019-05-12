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
    //Bu sınıf verilerimizi bilgiye dönüştürür ve onları müşterinin istediği iş kurallarıyla harmanlayıp Müşteri işlemlerini dış dünyaya açtığımız yerdir. 
    public class SirketBusiness : IDisposable
    {
        public bool SirketEkle(Sirket sirket)
        {
            try
            {
                bool isSuccess;
                using (var repo = new SirketRepository())
                {
                    isSuccess = repo.Insert(sirket);
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Business:SirketBusiness::SirketEkle::Hata Oluştu.", ex);
            }
        }

        public bool SirketGuncelle(Sirket sirket)
        {
            try
            {
                bool isSuccess;
                using (var repo = new SirketRepository())
                {
                    isSuccess = repo.Update(sirket);
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Business:SirketBusiness::SirketGuncelle::Hata Oluştu.", ex);
            }
        }

        public bool SirketSilById(int sirketID)
        {
            try
            {
                bool isSuccess;
                using (var repo = new SirketRepository())
                {
                    isSuccess = repo.DeletedById(sirketID);
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Business:SirketBusiness::SirketSilById::Hata Oluştu.", ex);
            }
        }

        public Sirket SirketSecById(int sirketID)
        {
            try
            {
                Sirket secilenSirket;
                using (var repo = new SirketRepository())
                {
                    secilenSirket = repo.SelectedById(sirketID);
                    if (secilenSirket == null)
                        throw new NullReferenceException("Girilen SirketID bulunamadi!");
                }
                return secilenSirket;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Business:SirketBusiness::SirketSecById::Hata Oluştu.", ex);
            }
        }

        public List<Sirket> SelectAllSirket()
        {
            var sirketListesi = new List<Sirket>();

            try
            {
                using (var repo = new SirketRepository())
                {
                    foreach (var sirket in repo.SelectAll())
                    {
                        sirketListesi.Add(sirket);
                    }
                }
                return sirketListesi;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Business:SirketBusiness::SelectAllSirket::Hata Oluştu.", ex);
            }
        }

        public SirketBusiness()
        {
            //Auto-generated Code   
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
