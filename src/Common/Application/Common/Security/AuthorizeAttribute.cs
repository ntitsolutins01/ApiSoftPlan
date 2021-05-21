using System;

namespace Application.Common.Security
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class AuthorizeAttribute : Attribute
    {
        /// <summary>
        /// Inicializa uma nova inst�ncia da classe <see cref="AuthorizeAttribute"/>. 
        /// </summary>
        public AuthorizeAttribute() { }

        /// <summary>
        /// Obt�m ou define uma lista delimitada por v�rgulas que t�m permiss�o para acessar o recurso.
        /// </summary>
        public string Roles { get; set; }
    }
}
