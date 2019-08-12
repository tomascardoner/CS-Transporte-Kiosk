using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CSTransporteKiosko
{
    class EventLog
    {
        public const string TipoInformacion = "I";
        public const string TipoAviso = "A";
        public const string TipoError = "E";
        public const string TipoLoginExitoso = "S";
        public const string TipoLoginFallido = "F";

        public const string MensajeLoginExitoso = "La terminal ha iniciado sesión correctamente.";
        public const string MensajeLoginFallido = "La terminal falló al intentar iniciar sesión.";

        private string _Tipo;

        public string Tipo
        {
            get => _Tipo;
            set
            {
                if (value == TipoInformacion | value == TipoAviso | value == TipoError | value == TipoLoginExitoso | value == TipoLoginFallido)
                {
                    _Tipo = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("El Tipo debe ser: I->Informacion, A->Aviso, E->Error, S->Login exitoso o F->Login fallido.");
                }
            }
        }
        public byte IdKiosko { get; set; }
        public string Mensaje { get; set; }
        public string Notas { get; set; }

        public bool Agregar(SqlConnection connection)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_EventLog_Agregar", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Tipo", Tipo);
                if (IdKiosko == 0)
                {
                    command.Parameters.AddWithValue("@IDKiosko", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@IDKiosko", IdKiosko);
                }
                command.Parameters.AddWithValue("@Mensaje", Mensaje);
                command.Parameters.AddWithValue("@Notas", Notas);

                command.ExecuteNonQuery();

                command.Dispose();
                command = null;

                Cursor.Current = Cursors.Default;
                return true;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CardonerSistemas.Error.ProcessError(ex, "Error al agregar el log del evento.");
                return false;
            }
        }
    }
}
