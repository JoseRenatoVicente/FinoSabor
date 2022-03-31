namespace FinoSabor.Domain.Entities.Enums
{
    public enum StatusPedido
    {
        EmAndamento = 0,//Acabou de ser adicionado
        Preparando = 1,//Confirmado pelo empresa
        EmRota = 2,//Saindo para entrega
        Entregue = 3//Entregue
    }
}
