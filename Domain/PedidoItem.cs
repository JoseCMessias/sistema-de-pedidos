namespace Sistema_Pedidos.Domain
{
   public class PedidoItem
    {
        public int Id { get; set; } 
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public double Desconto { get; set; }
        public double Valor { get; set; } 
        public object ProdutoId { get; set; }  
    }
}