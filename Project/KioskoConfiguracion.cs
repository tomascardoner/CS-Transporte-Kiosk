using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CardonerSistemas.Database.ADO;

namespace CSTransporteKiosko
{
    public class KioskoConfiguracion
    {
        #region Entity definition properties

        private const string EntityDBName = "KioskoConfiguracion";

        private const string EntityFieldNameIdKioskoConfiguracion = "IDKioskoConfiguracion";
        private const string EntityFieldNameNombre = "Nombre";

        private const bool EntityDisplayNameIsFemale = true;
        private const string EntityDisplayName = "Configuración del Kiosko";

        private string EntityLoadErrorMessage;
        private string EntityLoadPropertiesErrorMessage;

        private string EntityLoadRelatedKioskoConfiguracionValorErrorMessage = String.Format("Error al cargar los valores de {0} {1} por Id.", EntityDisplayNameIsFemale ? " la " : " el ", EntityDisplayName);

        // Media
        private string IdValorCompaniaSoftwareLogotipo = "CompaniaSoftwareLogotipo";
        private string IdValorEmpresaLogotipo = "EmpresaLogotipo";
        private string IdValorVideo = "Video";

        // Apariencia
        private string IdValorScreenBackColor = "ScreenBackColor";
        private string IdValorInformacionLeyendaFont = "InformacionLeyendaFont";
        private string IdValorInformacionLeyendaForeColor = "InformacionLeyendaForeColor";
        private string IdValorInformacionPrincipalFont = "InformacionPrincipalFont";
        private string IdValorInformacionPrincipalForeColor = "InformacionPrincipalForeColor";
        private string IdValorInformacionSecundariaFont = "InformacionSecundariaFont";
        private string IdValorInformacionSecundariaForeColor = "InformacionSecundariaForeColor";

        // Botón anterior
        private string IdValorButtonPreviousFont = "ButtonPreviousFont";
        private string IdValorButtonPreviousBackColor = "ButtonPreviousBackColor";
        private string IdValorButtonPreviousForeColor = "ButtonPreviousForeColor";

        // Botón siguiente
        private string IdValorButtonNextFont = "ButtonNextFont";
        private string IdValorButtonNextBackColor = "ButtonNextBackColor";
        private string IdValorButtonNextForeColor = "ButtonNextForeColor";

        // Mesage box
        private string IdValorMessageBoxFont = "MessageBoxFont";
        private string IdValorMessageBoxBackColor = "MessageBoxBackColor";
        private string IdValorMessageBoxForeColor = "MessageBoxForeColor";
        private string IdValorMessageBoxButtonFont = "MessageBoxButtonFont";
        private string IdValorMessageBoxButtonBackColor = "MessageBoxButtonBackColor";
        private string IdValorMessageBoxButtonForeColor = "MessageBoxButtonForeColor";

        // Numeric Keyborad
        private string IdValorKeyboardNumericNumberFont = "KeyboardNumericNumberFont";
        private string IdValorKeyboardNumericSpecialFont = "KeyboardNumericSpecialFont";

        // POS Printer
        private string IdValorPOSPrinterClaimTimeoutSeconds = "POSPrinterClaimTimeoutSeconds";
        private string IdValorPOSPrinterReleaseTimeoutSeconds = "POSPrinterReleaseTimeoutSeconds";

        // Timeouts
        private string IdValorInactivityTimeoutSeconds = "InactivityTimeoutSeconds";
        private string IdValorLugarDuracionPreviaMaximaMinutos = "LugarDuracionPreviaMaximaMinutos";
        private string IdValorLugarDuracionPreviaMinimaMinutos = "LugarDuracionPreviaMinimaMinutos";

        public KioskoConfiguracion()
        {
            EntityLoadErrorMessage = CardonerSistemas.Database.Framework.Lite.GetEntityLoadErrorMessage(EntityDisplayName, EntityDisplayNameIsFemale);
            EntityLoadPropertiesErrorMessage = CardonerSistemas.Database.Framework.Lite.GetEntityLoadPropertiesErrorMessage(EntityDisplayName, EntityDisplayNameIsFemale);
        }

        #endregion

        #region Object private properties

        private byte _IdKioskoConfiguracion;
        private string _Nombre;

        private bool _IsFound = false;

        #endregion

        #region Object public properties

        public byte IdKioskoConfiguracion { get => _IdKioskoConfiguracion; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }

        public bool IsFound { get => _IsFound; }

        #endregion

        #region Related entities

        private List<KioskoConfiguracionValor> _KioskoConfiguracionValores = new List<KioskoConfiguracionValor>();

        public List<KioskoConfiguracionValor> KioskoConfiguracionValores { get => _KioskoConfiguracionValores; }

        // Media
        public short? ValorCompaniaSoftwareLogotipoIdImagen { get => GetValorIdImagen(IdValorCompaniaSoftwareLogotipo); }
        public Image ValorCompaniaSoftwareLogotipo { get => GetValorImagenDataAsBitmap(IdValorCompaniaSoftwareLogotipo); }
        public short? ValorEmpresaLogotipoIdImagen { get => GetValorIdImagen(IdValorEmpresaLogotipo); }
        public Image ValorEmpresaLogotipo { get => GetValorImagenDataAsBitmap(IdValorEmpresaLogotipo); }
        public string ValorVideo { get => GetValorString(IdValorVideo); }

        // Apariencia
        public int? ValorScreenBackColorAsInteger { get => GetValorNumeroEnteroAsInteger(IdValorScreenBackColor); }
        public Color? ValorScreenBackColor { get => GetValorColor(IdValorScreenBackColor); }

        public string ValorInformacionLeyendaFontString { get => GetValorString(IdValorInformacionLeyendaFont); }
        public Font ValorInformacionLeyendaFont { get => GetValorFont(IdValorInformacionLeyendaFont); }
        public int? ValorInformacionLeyendaForeColorAsInteger { get => GetValorNumeroEnteroAsInteger(IdValorInformacionLeyendaForeColor); }
        public Color? ValorInformacionLeyendaForeColor { get => GetValorColor(IdValorInformacionLeyendaForeColor); }

        public string ValorInformacionPrincipalFontString { get => GetValorString(IdValorInformacionPrincipalFont); }
        public Font ValorInformacionPrincipalFont { get => GetValorFont(IdValorInformacionPrincipalFont); }
        public int? ValorInformacionPrincipalForeColorAsInteger { get => GetValorNumeroEnteroAsInteger(IdValorInformacionPrincipalForeColor); }
        public Color? ValorInformacionPrincipalForeColor { get => GetValorColor(IdValorInformacionPrincipalForeColor); }

        public string ValorInformacionSecundariaFontString { get => GetValorString(IdValorInformacionSecundariaFont); }
        public Font ValorInformacionSecundariaFont { get => GetValorFont(IdValorInformacionSecundariaFont); }
        public int? ValorInformacionSecundariaForeColorAsInteger { get => GetValorNumeroEnteroAsInteger(IdValorInformacionSecundariaForeColor); }
        public Color? ValorInformacionSecundariaForeColor { get => GetValorColor(IdValorInformacionSecundariaForeColor); }

        // Botón anterior
        public string ValorButtonPreviousFontString { get => GetValorString(IdValorButtonPreviousFont); }
        public Font ValorButtonPreviousFont { get => GetValorFont(IdValorButtonPreviousFont); }
        public int? ValorButtonPreviousBackColorAsInteger { get => GetValorNumeroEnteroAsInteger(IdValorButtonPreviousBackColor); }
        public Color? ValorButtonPreviousBackColor { get => GetValorColor(IdValorButtonPreviousBackColor);  }
        public int? ValorButtonPreviousForeColorAsInteger { get => GetValorNumeroEnteroAsInteger(IdValorButtonPreviousForeColor); }
        public Color? ValorButtonPreviousForeColor { get => GetValorColor(IdValorButtonPreviousForeColor); }

        // Botón siguiente
        public string ValorButtonNextFontString { get => GetValorString(IdValorButtonNextFont); }
        public Font ValorButtonNextFont { get => GetValorFont(IdValorButtonNextFont); }
        public int? ValorButtonNextBackColorAsInteger { get => GetValorNumeroEnteroAsInteger(IdValorButtonNextBackColor); }
        public Color? ValorButtonNextBackColor { get => GetValorColor(IdValorButtonNextBackColor); }
        public int? ValorButtonNextForeColorAsInteger { get => GetValorNumeroEnteroAsInteger(IdValorButtonNextForeColor); }
        public Color? ValorButtonNextForeColor { get => GetValorColor(IdValorButtonNextForeColor); }

        // Mesage box
        public string ValorMessageBoxFontString { get => GetValorString(IdValorMessageBoxFont); }
        public Font ValorMessageBoxFont { get => GetValorFont(IdValorMessageBoxFont); }
        public int? ValorMessageBoxBackColorAsInteger { get => GetValorNumeroEnteroAsInteger(IdValorMessageBoxBackColor); }
        public Color? ValorMessageBoxBackColor { get => GetValorColor(IdValorMessageBoxBackColor); }
        public int? ValorMessageBoxForeColorAsInteger { get => GetValorNumeroEnteroAsInteger(IdValorMessageBoxForeColor); }
        public Color? ValorMessageBoxForeColor { get => GetValorColor(IdValorMessageBoxForeColor); }

        public string ValorMessageBoxButtonFontString { get => GetValorString(IdValorMessageBoxButtonFont); }
        public Font ValorMessageBoxButtonFont { get => GetValorFont(IdValorMessageBoxButtonFont); }
        public int? ValorMessageBoxButtonBackColorAsInteger { get => GetValorNumeroEnteroAsInteger(IdValorMessageBoxButtonBackColor); }
        public Color? ValorMessageBoxButtonBackColor { get => GetValorColor(IdValorMessageBoxButtonBackColor); }
        public int? ValorMessageBoxButtonForeColorAsInteger { get => GetValorNumeroEnteroAsInteger(IdValorMessageBoxButtonForeColor); }
        public Color? ValorMessageBoxButtonForeColor { get => GetValorColor(IdValorMessageBoxButtonForeColor); }

        // Numeric Keyborad
        public string ValorKeyboardNumericNumberFontString { get => GetValorString(IdValorKeyboardNumericNumberFont); }
        public Font ValorKeyboardNumericNumberFont { get => GetValorFont(IdValorKeyboardNumericNumberFont); }
        public string ValorKeyboardNumericSpecialFontString { get => GetValorString(IdValorKeyboardNumericSpecialFont); }
        public Font ValorKeyboardNumericSpecialFont { get => GetValorFont(IdValorKeyboardNumericSpecialFont); }

        // POS Printer
        public int ValorPOSPrinterClaimTimeoutSeconds { get => GetValorNumeroEnteroAsInteger(IdValorPOSPrinterClaimTimeoutSeconds, 2); }
        public int ValorPOSPrinterReleaseTimeoutSeconds { get => GetValorNumeroEnteroAsInteger(IdValorPOSPrinterReleaseTimeoutSeconds, 5); }

        // Timeouts
        public int ValorInactivityTimeoutSeconds { get => GetValorNumeroEnteroAsInteger(IdValorInactivityTimeoutSeconds, 60); }
        public short ValorLugarDuracionPreviaMaximaMinutos { get => GetValorNumeroEnteroAsShort(IdValorLugarDuracionPreviaMaximaMinutos, 0); }
        public short ValorLugarDuracionPreviaMinimaMinutos { get => GetValorNumeroEnteroAsShort(IdValorLugarDuracionPreviaMinimaMinutos, 0); }

        public bool KioskoConfiguracionValoresCargar(SqlConnection connection)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_KioskoConfiguracion_ObtenerValores", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDKioskoConfiguracion", _IdKioskoConfiguracion);

                SqlDataReader dataReader;
                dataReader = command.ExecuteReader(CommandBehavior.SingleResult);
                command.Dispose();
                command = null;

                _KioskoConfiguracionValores.Clear();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        KioskoConfiguracionValor valor = new KioskoConfiguracionValor();

                        valor.CargarPropiedades(dataReader);
                        _KioskoConfiguracionValores.Add(valor);

                        valor = null;
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

        public bool CargarPorID(SqlConnection connection, byte idKioskoConfiguracion)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_KioskoConfiguracion_ObtenerPorID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDKioskoConfiguracion", idKioskoConfiguracion);

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

        private bool CargarPropiedades(SqlDataReader dataReader)
        {
            try
            {
                _IdKioskoConfiguracion = SQLServer.DataReaderGetByte(dataReader, EntityFieldNameIdKioskoConfiguracion);
                _Nombre = SQLServer.DataReaderGetString(dataReader, EntityFieldNameNombre);
                return true;
            }
            catch (Exception ex)
            {
                CardonerSistemas.Error.ProcessError(ex, EntityLoadPropertiesErrorMessage);
                return false;
            }
        }

        #endregion

        #region Buscar valores

        private KioskoConfiguracionValor GetValor(string idValor)
        {
            return _KioskoConfiguracionValores.Find(kcv => kcv.IdValor == idValor);
        }

        private string GetValorString(string idValor)
        {
            KioskoConfiguracionValor valor = GetValor(idValor);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ValorTexto;
            }
        }

        private Font GetValorFont(string idValor)
        {
            KioskoConfiguracionValor valor = GetValor(idValor);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ValorFont;
            }
        }

        private int? GetValorNumeroEnteroAsInteger(string idValor)
        {
            KioskoConfiguracionValor valor = GetValor(idValor);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ValorNumeroEnteroAsInteger;
            }
        }

        private int GetValorNumeroEnteroAsInteger(string idValor, int valorPredeterminado)
        {
            int? valor = GetValorNumeroEnteroAsInteger(idValor);
            if (valor.HasValue)
            {
                return valor.Value;
            }
            else
            {
                return valorPredeterminado;
            }
        }

        private short? GetValorNumeroEnteroAsShort(string idValor)
        {
            KioskoConfiguracionValor valor = GetValor(idValor);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ValorNumeroEnteroAsShort;
            }
        }

        private short GetValorNumeroEnteroAsShort(string idValor, short valorPredeterminado)
        {
            short? valor = GetValorNumeroEnteroAsShort(idValor);
            if (valor.HasValue)
            {
                return valor.Value;
            }
            else
            {
                return valorPredeterminado;
            }
        }

        private byte? GetValorNumeroEnteroAsByte(string idValor)
        {
            KioskoConfiguracionValor valor = GetValor(idValor);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ValorNumeroEnteroAsByte;
            }
        }

        private byte GetValorNumeroEnteroAsByte(string idValor, byte valorPredeterminado)
        {
            byte? valor = GetValorNumeroEnteroAsByte(idValor);
            if (valor.HasValue)
            {
                return valor.Value;
            }
            else
            {
                return valorPredeterminado;
            }
        }

        private Color? GetValorColor(string idValor)
        {
            KioskoConfiguracionValor valor = GetValor(idValor);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ValorColor;
            }
        }

        private decimal? GetValorNumeroDecimal(string idValor)
        {
            KioskoConfiguracionValor valor = GetValor(idValor);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ValorNumeroDecimal;
            }
        }

        private DateTime? GetValorFechaHora(string idValor)
        {
            KioskoConfiguracionValor valor = GetValor(idValor);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ValorFechaHora;
            }
        }

        private bool? GetValorSiNo(string idValor)
        {
            KioskoConfiguracionValor valor = GetValor(idValor);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ValorSiNo;
            }
        }

        private short? GetValorIdImagen(string idValor)
        {
            KioskoConfiguracionValor valor = GetValor(idValor);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ValorIdImagen;
            }
        }

        private Image GetValorImagenDataAsBitmap(string idValor)
        {
            KioskoConfiguracionValor valor = GetValor(idValor);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ValorImagenDataAsBitmap;
            }
        }

        #endregion
    }
}