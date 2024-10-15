﻿using LojaDoSeuManoel.Domain.Entites;
using LojaDoSeuManoel.Domain.Interfaces.Repositories;
using LojaDoSeuManoel.Infra.Data.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Infra.Data.SqlServer.Repositories
{
    public class DimensaoRepository : BaseRepository<Dimensao, int>, IDimensaoRepository
    {
        public DimensaoRepository(DataContext context) : base(context)
        {
        }
    }
}
