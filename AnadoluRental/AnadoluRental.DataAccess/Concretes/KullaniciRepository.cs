using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnadoluRental.CrossCutting.Concretes.Data;
using AnadoluRental.CrossCutting.Concretes.Helper;
using AnadoluRental.CrossCutting.Concretes.Logger;
using AnadoluRental.DataAccess.Abstractions;
using AnadoluRental.Models.Models;

namespace AnadoluRental.DataAccess.Concretes
{
    public class KullaniciRepository : IRepository<Kullanici>, IDisposable
    {
        private string _connectionString;
        private string _dbProviderName;
        private DbProviderFactory _dbProviderFactory;
        private int _rowsAffected, _errorCode;
        private bool _bDisposed;

        public KullaniciRepository()
        {
            _connectionString = DBHelper.GetConnectionString();
            _dbProviderName = DBHelper.GetConnectionProvider();
            _dbProviderFactory = DbProviderFactories.GetFactory(_dbProviderName);
        }

        public bool DeletedById(int id)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("DELETE ");
                query.Append("FROM [dbo].[Kullanici] ");
                query.Append("WHERE ");
                query.Append("[kullaniciID] = @id ");
                query.Append("SELECT @intErrorCode=@@ERROR; ");

                var commandText = query.ToString();
                query.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException(
                                "dbCommand" + " The db SelectById command for entity [Kullanici] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        DBHelper.AddParameter(dbCommand, "@id", CsType.Int, ParameterDirection.Input, id);

                        //Output Parameters
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();
                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception(
                                "Deleting Error for entity [Kullanici] reported the Database ErrorCode: " + _errorCode);
                    }
                }
                //sonuclari getirir
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("KullaniciRepository::Insert:Error occured.", ex);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool bDisposing)
        {
            // Check the Dispose method called before.
            if (!_bDisposed)
            {
                if (bDisposing)
                {
                    // Clean the resources used.
                    _dbProviderFactory = null;
                }

                _bDisposed = true;
            }
        }

        public bool Insert(Kullanici entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("INSERT [dbo].[Kullanici] ");
                query.Append(" ( [kullAdi], [kullSifre], [kullRolID], [kullSirketID], [Ad], [Soyad], [TelNo], [Adres] ) ");
                query.Append("VALUES ");
                query.Append(
                    "( @kullAdi, @kullSifre, @kullRolID, @kullSirketID, @Ad, @Soyad, @TelNo, @Adres ) ");
                query.Append("SELECT @intErrorCode=@@ERROR;");

                var commandText = query.ToString();
                query.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [Kullanici] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@kullAdi", CsType.String, ParameterDirection.Input, entity.kullAdi);
                        DBHelper.AddParameter(dbCommand, "@kullSifre", CsType.String, ParameterDirection.Input, entity.kullSifre);
                        DBHelper.AddParameter(dbCommand, "@kullRolID", CsType.Int, ParameterDirection.Input, entity.kullRolID);
                        DBHelper.AddParameter(dbCommand, "@kullSirketID", CsType.Int, ParameterDirection.Input, entity.kullSirketID);
                        DBHelper.AddParameter(dbCommand, "@Ad", CsType.String, ParameterDirection.Input, entity.Ad);
                        DBHelper.AddParameter(dbCommand, "@Soyad", CsType.String, ParameterDirection.Input, entity.Soyad);
                        DBHelper.AddParameter(dbCommand, "@TelNo", CsType.String, ParameterDirection.Input, entity.TelNo);
                        DBHelper.AddParameter(dbCommand, "@Adres", CsType.String, ParameterDirection.Input, entity.Adres);

                        //Output Params
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception("Inserting Error for entity [Kullanici] reported the Database ErrorCode: " + _errorCode);
                    }
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("KullaniciRepository::Insert:Error occured.", ex);
            }
        }

        public IList<Kullanici> SelectAll()
        {
            _errorCode = 0;
            _rowsAffected = 0;

            IList<Kullanici> kullaniciListesi = new List<Kullanici>();

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[kullaniciID], [kullAdi], [kullSifre], [kullRolID], [kullSirketID], [Ad], [Soyad], [TelNo], [Adres] ");
                query.Append("FROM [dbo].[Kullanici] ");
                query.Append("SELECT @intErrorCode=@@ERROR; ");

                var commandText = query.ToString();
                query.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException(
                                "dbCommand" + " The db SelectById command for entity [Kullanici] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters - None

                        //Output Parameters
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int,
                            ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query.
                        using (var reader = dbCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var entity = new Kullanici();
                                    entity.kullaniciID = reader.GetInt32(0);
                                    entity.kullAdi = reader.GetString(1);
                                    entity.kullSifre = reader.GetString(2);
                                    entity.kullRolID = reader.GetInt32(3);
                                    entity.kullSirketID = reader.GetInt32(4);
                                    entity.Ad = reader.GetString(5);
                                    entity.Soyad = reader.GetString(6);
                                    entity.TelNo = reader.GetString(7);
                                    entity.Adres = reader.GetString(8);

                                    entity.Kiralik = new KiralikRepository().SelectAll().Where(kira => kira.kiralayanKulID.Equals(entity.kullaniciID)).ToList();
                                    foreach (Kiralik temp in entity.Kiralik)
                                    {
                                        temp.Arac = null;
                                        temp.Kullanici = null;
                                    }
                                    entity.Rol = new RolRepository().SelectedById(entity.kullRolID);
                                    entity.Rol.Kullanici = null;

                                    kullaniciListesi.Add(entity);
                                }
                            }

                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting All Error for entity [Kullanici] reported the Database ErrorCode: " + _errorCode);

                        }
                    }
                }
                // Return list
                return kullaniciListesi;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("KullaniciRepository::SelectAll:Error occured.", ex);
            }
        }

        public Kullanici SelectedById(int id)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            Kullanici kull = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[kullaniciID], [kullAdi], [kullSifre], [kullRolID], [kullSirketID], [Ad], [Soyad], [TelNo], [Adres] ");
                query.Append("FROM [dbo].[Kullanici] ");
                query.Append("WHERE ");
                query.Append("[kullaniciID] = @id ");
                query.Append("SELECT @intErrorCode=@@ERROR; ");

                var commandText = query.ToString();
                query.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException(
                                "dbCommand" + " The db SelectById command for entity [Kullanici] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        DBHelper.AddParameter(dbCommand, "@id", CsType.Int, ParameterDirection.Input, id);

                        //Output Parameters
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query.
                        using (var reader = dbCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var entity = new Kullanici();
                                    entity.kullaniciID = reader.GetInt32(0);
                                    entity.kullAdi = reader.GetString(1);
                                    entity.kullSifre = reader.GetString(2);
                                    entity.kullRolID = reader.GetInt32(3);
                                    entity.kullSirketID = reader.GetInt32(4);
                                    entity.Ad = reader.GetString(5);
                                    entity.Soyad = reader.GetString(6);
                                    entity.TelNo = reader.GetString(7);
                                    entity.Adres = reader.GetString(8);

                                    kull = entity;
                                    break;
                                }
                            }
                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting Error for entity [Kullanici] reported the Database ErrorCode: " + _errorCode);
                        }
                    }
                }

                return kull;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("KullaniciRepository::SelectById:Error occured.", ex);
            }
        }

        public bool Update(Kullanici entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append(" UPDATE [dbo].[Kullanici] ");
                query.Append(" SET [kullAdi] = @kullAdi, [kullSifre] = @kullSifre, [kullRolID] =  @kullRolID, [kullSirketID] =  @kullSirketID, [Ad] =  @Ad, [Soyad] =  @Soyad, [TelNo] =  @TelNo, [Adres] =  @Adres ");
                query.Append(" WHERE ");
                query.Append(" [kullaniciID] = @kullaniciID ");
                query.Append(" SELECT @intErrorCode = @@ERROR; ");

                var commandText = query.ToString();
                query.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [Kullanici] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@kullaniciID", CsType.Int, ParameterDirection.Input, entity.kullaniciID);
                        DBHelper.AddParameter(dbCommand, "@kullAdi", CsType.String, ParameterDirection.Input, entity.kullAdi);
                        DBHelper.AddParameter(dbCommand, "@kullSifre", CsType.String, ParameterDirection.Input, entity.kullSifre);
                        DBHelper.AddParameter(dbCommand, "@kullRolID", CsType.Int, ParameterDirection.Input, entity.kullRolID);
                        DBHelper.AddParameter(dbCommand, "@kullSirketID", CsType.Int, ParameterDirection.Input, entity.kullSirketID);
                        DBHelper.AddParameter(dbCommand, "@Ad", CsType.String, ParameterDirection.Input, entity.Ad);
                        DBHelper.AddParameter(dbCommand, "@Soyad", CsType.String, ParameterDirection.Input, entity.Soyad);
                        DBHelper.AddParameter(dbCommand, "@TelNo", CsType.String, ParameterDirection.Input, entity.TelNo);
                        DBHelper.AddParameter(dbCommand, "@Adres", CsType.String, ParameterDirection.Input, entity.Adres);

                        //Output Params
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception("Updating Error for entity [Kullanici] reported the Database ErrorCode: " + _errorCode);
                    }
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("KullaniciRepository::Update:Error occured.", ex);
            }
        }
    }
}
