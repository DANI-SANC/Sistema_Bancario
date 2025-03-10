using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Bancario.Dominio
{
    public static class PoliciesMaster
    {
        public const string DEPOSITO = nameof(DEPOSITO);

        public const string RETIRO = nameof(RETIRO);

        public const string LEER_DEPOSITO = nameof(LEER_DEPOSITO);

        public const string LEER_RETIRO = nameof(LEER_RETIRO);

        public const string REGISTRAR_USUARIO = nameof(REGISTRAR_USUARIO);

        public const string MODIFICAR_USUARIO = nameof(MODIFICAR_USUARIO);

        public const string ELIMINAR_USUARIO = nameof(ELIMINAR_USUARIO);
        
        public const string LEER_USUARIO = nameof(LEER_USUARIO);

        public const string AGREGAR_CLIENTE = nameof(AGREGAR_CLIENTE);

        public const string MODIFICAR_CLIENTE = nameof(MODIFICAR_CLIENTE);

        public const string ELIMINAR_CLIENTE = nameof(ELIMINAR_CLIENTE);

        public const string LEER_CLIENTE = nameof(LEER_CLIENTE);

        public const string REGISTRAR_ROL = nameof(REGISTRAR_ROL);

        public const string MODIFICAR_ROL = nameof(MODIFICAR_ROL);

        public const string ELIMINAR_ROL = nameof(ELIMINAR_ROL);

        public const string LEER_ROL = nameof(LEER_ROL);

        public const string REGISTRAR_CUENTA = nameof(REGISTRAR_CUENTA);

        public const string LEER_CUENTA = nameof(LEER_CUENTA);

    }
}
