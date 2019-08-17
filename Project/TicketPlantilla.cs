using CardonerSistemas.Database.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CSTransporteKiosko
{
    public class TicketPlantilla
    {
        #region Entity definition properties

        private const string EntityDBName = "TicketPlantilla";

        private const string EntityFieldNameIdTicketPlantilla = "IDTicketPlantilla";
        private const string EntityFieldNameNombre = "Nombre";
        private const string EntityFieldNameActivo = "Activo";

        private const bool EntityDisplayNameIsFemale = true;
        private const string EntityDisplayName = "Plantilla del Ticket";

        private string EntityLoadErrorMessage;
        private string EntityLoadPropertiesErrorMessage;

        private string EntityLoadRelatedKioskoConfiguracionValorErrorMessage = String.Format("Error al cargar los valores de {0} {1} por Id.", EntityDisplayNameIsFemale ? " la " : " el ", EntityDisplayName);

        public TicketPlantilla()
        {
            EntityLoadErrorMessage = CardonerSistemas.Database.Framework.Lite.GetEntityLoadErrorMessage(EntityDisplayName, EntityDisplayNameIsFemale);
            EntityLoadPropertiesErrorMessage = CardonerSistemas.Database.Framework.Lite.GetEntityLoadPropertiesErrorMessage(EntityDisplayName, EntityDisplayNameIsFemale);
        }

        #endregion

        #region Object private properties

        private byte _IdTicketPlantilla;
        private string _Nombre;
        private bool _Activo;

        private bool _IsFound = false;

        #endregion

        #region Object public properties

        public byte IdTicketPlantilla { get => _IdTicketPlantilla; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public bool Activo { get => _Activo; set => _Activo = value; }

        public bool IsFound { get => _IsFound; }

        #endregion

        #region Related entities

        private List<TicketPlantillaComando> _TicketPlantillaComandos = new List<TicketPlantillaComando>();

        public List<TicketPlantillaComando> TicketPlantillaComandos { get => _TicketPlantillaComandos; }

        public bool TicketPlantillaComandosCargar(SqlConnection connection)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_TicketPlantilla_ObtenerComandos", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDTicketPlantilla", _IdTicketPlantilla);

                SqlDataReader dataReader;
                dataReader = command.ExecuteReader(CommandBehavior.SingleResult);
                command.Dispose();
                command = null;

                _TicketPlantillaComandos.Clear();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        TicketPlantillaComando comando = new TicketPlantillaComando();

                        comando.CargarPropiedades(dataReader);
                        _TicketPlantillaComandos.Add(comando);

                        comando = null;
                    }
                }

                dataReader.Close();
                dataReader = null;
                Cursor.Current = Cursors.Default;
                return true;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CardonerSistemas.Error.ProcessError(ex, EntityLoadRelatedKioskoConfiguracionValorErrorMessage);
                return false;
            }
        }

        #endregion

        #region Load data from database

        public bool CargarPorID(SqlConnection connection, byte idTicketPlantilla)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_TicketPlantilla_ObtenerPorID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDTicketPlantilla", idTicketPlantilla);

                Cursor.Current = Cursors.Default;
                return CargarEjecutar(command, EntityLoadErrorMessage);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CardonerSistemas.Error.ProcessError(ex, EntityLoadErrorMessage);
                return false;
            }
        }

        private bool CargarEjecutar(SqlCommand command, string errorMessage)
        {
            try
            {
                SqlDataReader dataReader;
                dataReader = command.ExecuteReader(CommandBehavior.SingleRow);
                command.Dispose();
                command = null;

                _IsFound = dataReader.HasRows;

                if (IsFound)
                {
                    dataReader.Read();

                    if (CargarPropiedades(dataReader))
                    {
                        dataReader.Close();
                        dataReader = null;
                        return true;
                    }
                    else
                    {
                        dataReader.Close();
                        dataReader = null;
                        return false;
                    }
                }
                else
                {
                    dataReader.Close();
                    dataReader = null;
                    return true;
                }
            }
            catch (Exception ex)
            {
                CardonerSistemas.Error.ProcessError(ex, errorMessage);
                return false;
            }
        }

        public bool CargarPropiedades(SqlDataReader dataReader)
        {
            try
            {
                _IdTicketPlantilla = SQLServer.DataReaderGetByte(dataReader, EntityFieldNameIdTicketPlantilla);
                _Nombre = SQLServer.DataReaderGetString(dataReader, EntityFieldNameNombre);
                _Activo = SQLServer.DataReaderGetBoolean(dataReader, EntityFieldNameActivo);
                return true;
            }
            catch (Exception ex)
            {
                CardonerSistemas.Error.ProcessError(ex, EntityLoadPropertiesErrorMessage);
                return false;
            }
        }

        #endregion
    }
}