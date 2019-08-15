﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CardonerSistemas.Database.ADO;

namespace CSTransporteKiosko
{
    class KioskoConfiguracionValor
    {
        #region Propiedades

        // Entity definition properties

        private const string EntityDBName = "KioskoConfiguracionValor";

        private const string EntityFieldNameIdKioskoConfiguracion = "IDKioskoConfiguracionValor";
        private const string EntityFieldNameIdValor = "IDValor";
        private const string EntityFieldNameValorTexto = "ValorTexto";
        private const string EntityFieldNameValorNumeroEntero = "ValorNumeroEntero";
        private const string EntityFieldNameValorNumeroDecimal = "ValorNumeroDecimal";
        private const string EntityFieldNameValorFechaHora = "ValorFechaHora";
        private const string EntityFieldNameValorSiNo = "ValorSiNo";

        private const bool EntityDisplayNameIsFemale = false;
        private const string EntityDisplayName = "Valor de Configuración del Kiosko";

        private string EntityLoadErrorMessage = String.Format("Error al cargar {0} {1} por Id.", EntityDisplayNameIsFemale ? " la " : " el ", EntityDisplayName);
        private string EntityLoadPropertiesErrorMessage = String.Format("Error al cargar las propiedades de {0} {1} por Id.", EntityDisplayNameIsFemale ? " la " : " el ", EntityDisplayName);

        // Object internal properties

        private byte _IdKioskoConfiguracion;
        private string _IdValor;

        private bool _IsFound = false;

        // Public properties

        public byte IdKioskoConfiguracion { get => _IdKioskoConfiguracion; }
        public string IdValor { get => _IdValor; }
        public string ValorTexto { get; set; }
        public int? ValorNumeroEntero { get; set; }
        public decimal? ValorNumeroDecimal { get; set; }
        public DateTime? ValorFechaHora { get; set; }
        public bool? ValorSiNo { get; set; }

        public bool IsFound { get => _IsFound; }

        #endregion

        #region Carga de datos desde la base

        public bool CargarPorID(SqlConnection connection, byte idKioskoConfiguracion, string IdValor)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_KioskoConfiguracionValor_ObtenerPorID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDKioskoConfiguracion", idKioskoConfiguracion);
                command.Parameters.AddWithValue("@IDValor", IdValor);

                Cursor.Current = Cursors.Default;
                return CargarComun(command, EntityLoadErrorMessage);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CardonerSistemas.Error.ProcessError(ex, EntityLoadErrorMessage);
                return false;
            }
        }

        private bool CargarComun(SqlCommand command, string errorMessage)
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

        private bool CargarPropiedades(SqlDataReader dataReader)
        {
            try
            {
                _IdKioskoConfiguracion = dataReader.GetByte(dataReader.GetOrdinal(EntityFieldNameIdKioskoConfiguracion));
                _IdValor = dataReader.GetString(dataReader.GetOrdinal(EntityFieldNameIdValor));
                ValorTexto = SQLServer.DataReaderGetStringSafeAsNull(dataReader, EntityFieldNameValorTexto);
                ValorNumeroEntero = SQLServer.DataReaderGetIntegerSafeAsNull(dataReader, EntityFieldNameValorNumeroEntero);
                ValorNumeroDecimal = SQLServer.DataReaderGetDecimalSafeAsNull(dataReader, EntityFieldNameValorNumeroDecimal);
                ValorFechaHora = SQLServer.DataReaderGetDateTimeSafeAsNull(dataReader, EntityFieldNameValorFechaHora);
                ValorSiNo = SQLServer.DataReaderGetBooleanSafeAsNull(dataReader, EntityFieldNameValorSiNo);
                return true;
            }
            catch (Exception ex)
            {
                CardonerSistemas.Error.ProcessError(ex, EntityLoadPropertiesErrorMessage);
                return false;
            }
        }

        public bool CargarDesdeArray(object[] values)
        {
            try
            {
                _IdKioskoConfiguracion = SQLServer.ObjectGetByte(values[0]).Value;
                _IdValor = SQLServer.ObjectGetString(values[1]).TrimEnd();
                ValorTexto = SQLServer.ObjectGetString(values[2]);
                ValorNumeroEntero = SQLServer.ObjectGetInteger(values[3]);
                ValorNumeroDecimal = SQLServer.ObjectGetDecimal(values[4]);
                ValorFechaHora = SQLServer.ObjectGetDateTime(values[5]);
                ValorSiNo = SQLServer.ObjectGetBoolean(values[6]);
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