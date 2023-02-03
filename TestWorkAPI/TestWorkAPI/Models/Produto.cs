using System;
using System.Collections.Generic;

namespace TestWorkAPI.Models;

public partial class Produto
{
    public int Id { get; set; }

    public string? ProdutoNome { get; set; }

    public decimal? Valor { get; set; }

    public string? Descricao { get; set; }

    public double? Desconto { get; set; }
}
