using MediatR;

namespace ToroChallenge.Application.UseCases.Patrimonios
{
    public class PatrimonioCommand : IRequest<PatrimonioResponse>
    {
        public string LoginUsuario { get; set; }
    }
}
