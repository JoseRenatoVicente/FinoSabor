using System.Collections.Generic;

namespace SistemaERP.Application.Notificacoes.Interface
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
