using System;
using System.Data;
using System.Data.SqlClient;
using CardonerSistemas.Database.ADO;

namespace CSTransporteKiosk
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

        private string _tipo;

        public string tipo
        {
            get => _tipo;
            set
            {
                if (value == TipoInformacion | value == TipoAviso | value == TipoError | value == TipoLoginExitoso | value == TipoLoginFallido)
                {
                    _tipo = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("El Tipo debe ser: I->Informacion, A->Aviso, E->Error, S->Login exitoso o F->Login fallido.");
                }
            }
        }
        public byte idKiosko { get; set; }
        public string mensaje { get; set; }
        public string notas { get; set; }

        public bool Agregar(SQLServer database)
        {
            try
            {
                SqlCommand command = new SqlCommand("usp_EventLog_Agregar", database.connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Tipo", tipo);
                command.Parameters.AddWithValue("@IDKiosko", idKiosko);
                command.Parameters.AddWithValue("@Mensaje", mensaje);
                command.Parameters.AddWithValue("@Notas", notas);

                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                CardonerSistemas.Error.ProcessError(ex, "Error al agregar el log del evento.");
                return false;
            }
        }
    }
}
