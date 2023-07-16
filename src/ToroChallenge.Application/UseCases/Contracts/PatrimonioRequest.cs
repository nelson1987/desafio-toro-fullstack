using Swashbuckle.AspNetCore.Annotations;
using ToroChallenge.Application.UseCases.Patrimonios;

namespace ToroChallenge.Application.UseCases.Contracts
{
    [SwaggerSchema(Required = new[] { "Description" })]
    public class PatrimonioRequest
    {
        /// <summary>
        /// Nome do Usuário
        /// </summary>
        /// <example>
        /// PATRICIA.A401
        /// </example>
        [SwaggerSchema("The product identifier", ReadOnly = true)]
        public string Name { get; set; }
        internal PatrimonioCommand ToDocument()
        {
            throw new NotImplementedException();
        }
    }
}