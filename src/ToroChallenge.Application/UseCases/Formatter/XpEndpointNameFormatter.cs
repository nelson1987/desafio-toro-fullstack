using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToroChallenge.Application.UseCases.Formatter
{
    public class XpEndpointNameFormatter : SnakeCaseEndpointNameFormatter
    {
        public XpEndpointNameFormatter() : base('-', string.Empty, true) { }
        public override string SanitizeName(string name)
        {
            return base.SanitizeName(name).Replace(SnakeCaseSeparator, '-');
        }
    }
}
