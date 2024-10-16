﻿using LojaDoSeuManoel.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Interfaces.Repositories
{
    public interface IEmpacotamentoServico
    {
        List<Caixa> Empacotar(List<Produto> produtos);
    }
}
