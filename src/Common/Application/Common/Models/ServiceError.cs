using System;

namespace Application.Common.Models
{
    /// <summary>
    /// Todos os erros contidos em objetos ServiceResult devem retornar um erro deste tipo
    /// Os c�digos de erro permitem que o chamador identifique facilmente o erro recebido e execute uma a��o.
    /// Mensagens de erro permitem que o chamador mostre facilmente mensagens de erro ao usu�rio final.
    /// </summary>
    [Serializable]
    public class ServiceError
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public ServiceError(string message, int code)
        {
            this.Message = message;
            this.Code = code;
        }

        public ServiceError() { }

        /// <summary>
        /// Mensagem de erro leg�vel por usu�rios
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// C�digo de erro leg�vel por aplica��o
        /// </summary>
        public int Code { get; }

        /// <summary>
        /// Erro padr�o para quando recebemos uma exce��o
        /// </summary>
        public static ServiceError DefaultError => new ServiceError("Ocorreu uma exce��o.", 999);

        /// <summary>
        /// Erro de valida��o padr�o. Use isso para par�metros inv�lidos em a��es do controlador e m�todos de servi�o.
        /// </summary>
        public static ServiceError ModelStateError(string validationError)
        {
            return new ServiceError(validationError, 998);
        }

        /// <summary>
        /// ServiceError para respostas n�o autorizadas.
        /// </summary>
        public static ServiceError ForbiddenError => new ServiceError("Voc� n�o est� autorizado a chamar esta a��o.", 998);

        /// <summary>
        /// Use para enviar uma mensagem de erro personalizada
        /// </summary>
        public static ServiceError CustomMessage(string errorMessage)
        {
            return new ServiceError(errorMessage, 997);
        }

        public static ServiceError UserNotFound => new ServiceError("O usu�rio com este id n�o existe", 996);

        public static ServiceError UserFailedToCreate => new ServiceError("Falha ao criar usu�rio.", 995);

        public static ServiceError Canceled => new ServiceError("O pedido foi cancelado com sucesso!", 994);

        public static ServiceError NotFount => new ServiceError("O recurso especificado n�o foi encontrado.", 990);

        public static ServiceError ValidationFormat => new ServiceError("O formato do objeto de solicita��o � inv�lido.", 901);
        
        public static ServiceError Validation => new ServiceError("Ocorreram um ou mais erros de valida��o.", 900);

        public static ServiceError SearchAtLeastOneCharacter => new ServiceError("O par�metro de pesquisa deve ter pelo menos um caractere!", 898);

        /// <summary>
        /// Erro padr�o para quando recebemos uma exce��o
        /// </summary>
        public static ServiceError ServiceProviderNotFound => new ServiceError("O provedor de servi�os com este nome n�o existe.", 700);

        public static ServiceError ServiceProvider => new ServiceError("O provedor de servi�os n�o retornou conforme o esperado.", 600);

        public static ServiceError DateTimeFormatError => new ServiceError("O formato da data n�o � inv�lido. O formato da data deve ser dd/MM/yyyy (06/03/2021)", 500);

        #region Override Operador Equals

        /// <summary>
        /// Use isto para comparar se dois erros s�o iguais
        /// </summary>
        public override bool Equals(object obj)
        {
            // Se o par�metro n�o puder ser convertido em ServiceError ou for nulo, retorne falso.
            var error = obj as ServiceError;

            // Retorna verdadeiro se os c�digos de erro corresponderem. Falso se o objeto com o qual estamos comparando for nulo
            // ou se tiver um c�digo diferente.
            return Code == error?.Code;
        }

        public bool Equals(ServiceError error)
        {
            // Retorna verdadeiro se os c�digos de erro corresponderem. Falso se o objeto com o qual estamos comparando for nulo
            // ou se tiver um c�digo diferente.
            return Code == error?.Code;
        }

        public override int GetHashCode()
        {
            return Code;
        }

        public static bool operator ==(ServiceError a, ServiceError b)
        {
            // Se ambos forem nulos, ou ambos forem a mesma inst�ncia, retorna verdadeiro.
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            // Se um for nulo, mas n�o ambos, retorna falso.
            if ((object)a == null || (object)b == null)
            {
                return false;
            }

            // Retorna verdadeiro se os campos corresponderem:
            return a.Equals(b);
        }

        public static bool operator !=(ServiceError a, ServiceError b)
        {
            return !(a == b);
        }

        #endregion
    }

}
