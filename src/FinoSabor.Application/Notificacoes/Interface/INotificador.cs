using System.Collections.Generic;

namespace FinoSabor.Application.Notificacoes.Interface
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
