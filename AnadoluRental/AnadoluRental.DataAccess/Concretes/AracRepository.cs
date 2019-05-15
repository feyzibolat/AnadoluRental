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
    public class AracRepository : IRepository<Arac>, IDisposable
    {
        private string _connectionString;
        private string _dbProviderName;
        private DbProviderFactory _dbProviderFactory;
        private int _rowsAffected, _errorCode;
        private bool _bDisposed;

        public AracRepository()
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
                query.Append("FROM [dbo].[Arac] ");
                query.Append("WHERE ");
                query.Append("[aracID] = @id ");
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
                                "dbCommand" + " The db SelectById command for entity [Arac] can't be null. ");

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
                                "Deleting Error for entity [Arac] reported the Database ErrorCode: " + _errorCode);
                    }
                }
                //sonuclari getirir
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("AracRepository::Insert:Error occured.", ex);
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

        public bool Insert(Arac entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("INSERT [dbo].[Arac] ");
                query.Append("( [aracMarka], [aracModel], [gerekenEhliyetYasi], [minYasSiniri], [gunlukSinirKM], [aracKM], [airBagSayisi], [bagacHacmi], [koltukSayisi], [gunlukKiralikFiyati], [aitOlduguSirketID] ) ");
                query.Append("VALUES ");
                query.Append(
                    "( @aracMarka, @aracModel, @gerekenEhliyetYasi, @minYasSiniri, @gunlukSinirKM, @aracKM, @airBagSayisi, @bagacHacmi, @koltukSayisi, @gunlukKiralikFiyati, @aitOlduguSirketID ) ");
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
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [Arac] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@aracMarka", CsType.String, ParameterDirection.Input, entity.aracMarka);
                        DBHelper.AddParameter(dbCommand, "@aracModel", CsType.String, ParameterDirection.Input, entity.aracModel);
                        DBHelper.AddParameter(dbCommand, "@gerekenEhliyetYasi", CsType.Int, ParameterDirection.Input, entity.gerekenEhliyetYasi);
                        DBHelper.AddParameter(dbCommand, "@minYasSiniri", CsType.Int, ParameterDirection.Input, entity.minYasSiniri);
                        DBHelper.AddParameter(dbCommand, "@gunlukSinirKM", CsType.Int, ParameterDirection.Input, entity.gunlukSinirKM);
                        DBHelper.AddParameter(dbCommand, "@aracKM", CsType.Int, ParameterDirection.Input, entity.aracKM);
                        DBHelper.AddParameter(dbCommand, "@airBagSayisi", CsType.Int, ParameterDirection.Input, entity.airBagSayisi);
                        DBHelper.AddParameter(dbCommand, "@bagacHacmi", CsType.Int, ParameterDirection.Input, entity.bagacHacmi);
                        DBHelper.AddParameter(dbCommand, "@koltukSayisi", CsType.Int, ParameterDirection.Input, entity.koltukSayisi);
                        DBHelper.AddParameter(dbCommand, "@gunlukKiralikFiyati", CsType.Int, ParameterDirection.Input, entity.gunlukKiralikFiyati);
                        DBHelper.AddParameter(dbCommand, "@aitOlduguSirketID", CsType.Int, ParameterDirection.Input, entity.aitOlduguSirketID);

                        //Output Params
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception("Inserting Error for entity [Arac] reported the Database ErrorCode: " + _errorCode);
                    }
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("AracRepository::Insert:Error occured.", ex);
            }
        }

        public IList<Arac> SelectAll()
        {
            _errorCode = 0;
            _rowsAffected = 0;

            IList<Arac> aracListesi = new List<Arac>();

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[aracID], [aracMarka], [aracModel], [gerekenEhliyetYasi], [minYasSiniri], [gunlukSinirKM], [aracKM], [airBagSayisi], [bagacHacmi], [koltukSayisi], [gunlukKiralikFiyati], [aitOlduguSirketID] ");
                query.Append("FROM [Arac] ");
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
                                "dbCommand" + " The db SelectById command for entity [Arac] can't be null. ");

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
                                    var entity = new Arac();
                                    entity.aracID = reader.GetInt32(0);
                                    entity.aracMarka = reader.GetString(1);
                                    entity.aracModel = reader.GetString(2);
                                    entity.gerekenEhliyetYasi = reader.GetInt32(3);
                                    entity.minYasSiniri = reader.GetInt32(4);
                                    entity.gunlukSinirKM = reader.GetInt32(5);
                                    entity.aracKM = reader.GetInt32(6);
                                    entity.airBagSayisi = reader.GetInt32(7);
                                    entity.bagacHacmi = reader.GetInt32(8);
                                    entity.koltukSayisi = reader.GetInt32(9);
                                    entity.gunlukKiralikFiyati = reader.GetInt32(10);
                                    entity.aitOlduguSirketID = reader.GetInt32(11);

                                    entity.Kiralik = new KiralikRepository().SelectAllForJSON().Where(kira => kira.kiralananAracID.Equals(entity.aracID)).ToList();
                                    entity.Sirket = new SirketRepository().SelectedById(entity.aitOlduguSirketID);
                                    entity.Sirket.Arac = null;

                                    aracListesi.Add(entity);
                                }
                            }

                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting All Error for entity [Arac] reported the Database ErrorCode: " + _errorCode);

                        }
                    }
                }
                // Return list
                return aracListesi;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("AracRepository::SelectAll:Error occured.", ex);
            }
        }

        public IList<Arac> SelectAllForJSON()
        {
            _errorCode = 0;
            _rowsAffected = 0;

            IList<Arac> aracListesi = new List<Arac>();

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[aracID], [aracMarka], [aracModel], [gerekenEhliyetYasi], [minYasSiniri], [gunlukSinirKM], [aracKM], [airBagSayisi], [bagacHacmi], [koltukSayisi], [gunlukKiralikFiyati], [aitOlduguSirketID] ");
                query.Append("FROM [Arac] ");
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
                                "dbCommand" + " The db SelectById command for entity [Arac] can't be null. ");

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
                                    var entity = new Arac();
                                    entity.aracID = reader.GetInt32(0);
                                    entity.aracMarka = reader.GetString(1);
                                    entity.aracModel = reader.GetString(2);
                                    entity.gerekenEhliyetYasi = reader.GetInt32(3);
                                    entity.minYasSiniri = reader.GetInt32(4);
                                    entity.gunlukSinirKM = reader.GetInt32(5);
                                    entity.aracKM = reader.GetInt32(6);
                                    entity.airBagSayisi = reader.GetInt32(7);
                                    entity.bagacHacmi = reader.GetInt32(8);
                                    entity.koltukSayisi = reader.GetInt32(9);
                                    entity.gunlukKiralikFiyati = reader.GetInt32(10);
                                    entity.aitOlduguSirketID = reader.GetInt32(11);

                                    aracListesi.Add(entity);
                                }
                            }

                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting All Error for entity [Arac] reported the Database ErrorCode: " + _errorCode);

                        }
                    }
                }
                // Return list
                return aracListesi;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("AracRepository::SelectAll:Error occured.", ex);
            }
        }

        public Arac SelectedById(int id)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            Arac arac = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[aracID], [aracMarka], [aracModel], [gerekenEhliyetYasi], [minYasSiniri], [gunlukSinirKM], [aracKM], [airBagSayisi], [bagacHacmi], [koltukSayisi], [gunlukKiralikFiyati], [aitOlduguSirketID] ");
                query.Append("FROM [dbo].[Arac] ");
                query.Append("WHERE ");
                query.Append("[aracID] = @id ");
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
                                "dbCommand" + " The db SelectById command for entity [Arac] can't be null. ");

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
                                    var entity = new Arac();
                                    entity.aracID = reader.GetInt32(0);
                                    entity.aracMarka = reader.GetString(1);
                                    entity.aracModel = reader.GetString(2);
                                    entity.gerekenEhliyetYasi = reader.GetInt32(3);
                                    entity.minYasSiniri = reader.GetInt32(4);
                                    entity.gunlukSinirKM = reader.GetInt32(5);
                                    entity.aracKM = reader.GetInt32(6);
                                    entity.airBagSayisi = reader.GetInt32(7);
                                    entity.bagacHacmi = reader.GetInt32(8);
                                    entity.koltukSayisi = reader.GetInt32(9);
                                    entity.gunlukKiralikFiyati = reader.GetInt32(10);
                                    entity.aitOlduguSirketID = reader.GetInt32(11);

                                    arac = entity;
                                    break;
                                }
                            }
                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting Error for entity [Arac] reported the Database ErrorCode: " + _errorCode);
                        }
                    }
                }

                arac.Kiralik = new KiralikRepository().SelectAllForJSON().Where(kira => kira.kiralananAracID.Equals(id)).ToList();
                arac.Sirket = new SirketRepository().SelectedById(arac.aitOlduguSirketID);
                arac.Sirket.Arac = null;

                return arac;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("AracRepository::SelectById:Error occured.", ex);
            }
        }

        public bool Update(Arac entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append(" UPDATE [dbo].[Arac] ");
                query.Append(" SET [aracMarka] = @aracMarka, [aracModel] = @aracModel, [gerekenEhliyetYasi] =  @gerekenEhliyetYasi, [minYasSiniri] = @minYasSiniri, [gunlukSinirKM] = @gunlukSinirKM, [aracKM] = @aracKM , [airBagSayisi] = @airBagSayisi , [bagacHacmi] = @bagacHacmi , [koltukSayisi] = @koltukSayisi , [gunlukKiralikFiyati] = @gunlukKiralikFiyati , [aitOlduguSirketID] = @aitOlduguSirketID ");
                query.Append(" WHERE ");
                query.Append(" [aracID] = @aracID ");
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
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [Arac] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@aracID", CsType.Int, ParameterDirection.Input, entity.aracID);
                        DBHelper.AddParameter(dbCommand, "@aracMarka", CsType.String, ParameterDirection.Input, entity.aracMarka);
                        DBHelper.AddParameter(dbCommand, "@aracModel", CsType.String, ParameterDirection.Input, entity.aracModel);
                        DBHelper.AddParameter(dbCommand, "@gerekenEhliyetYasi", CsType.Int, ParameterDirection.Input, entity.gerekenEhliyetYasi);
                        DBHelper.AddParameter(dbCommand, "@minYasSiniri", CsType.Int, ParameterDirection.Input, entity.minYasSiniri);
                        DBHelper.AddParameter(dbCommand, "@gunlukSinirKM", CsType.Int, ParameterDirection.Input, entity.gunlukSinirKM);
                        DBHelper.AddParameter(dbCommand, "@aracKM", CsType.Int, ParameterDirection.Input, entity.aracKM);
                        DBHelper.AddParameter(dbCommand, "@airBagSayisi", CsType.Int, ParameterDirection.Input, entity.airBagSayisi);
                        DBHelper.AddParameter(dbCommand, "@bagacHacmi", CsType.Int, ParameterDirection.Input, entity.bagacHacmi);
                        DBHelper.AddParameter(dbCommand, "@koltukSayisi", CsType.Int, ParameterDirection.Input, entity.koltukSayisi);
                        DBHelper.AddParameter(dbCommand, "@gunlukKiralikFiyati", CsType.Int, ParameterDirection.Input, entity.gunlukKiralikFiyati);
                        DBHelper.AddParameter(dbCommand, "@aitOlduguSirketID", CsType.Int, ParameterDirection.Input, entity.aitOlduguSirketID);

                        //Output Params
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception("Updating Error for entity [Arac] reported the Database ErrorCode: " + _errorCode);
                    }
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("AracRepository::Update:Error occured.", ex);
            }
        }
    }
}
